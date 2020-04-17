using DonkeyWebApp.API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DonkeyExampleApp
{
    public class AppModel : INotifyPropertyChanged
    {
        // Consts, static props/backing and events

        private const string DEFAULT_DATE_FROM = "2020-01-16";

        private static readonly AppModel current = new AppModel();
        public static AppModel Current => current;
        private string configFilename;

        public event PropertyChangedEventHandler PropertyChanged;


        // Bindable properties and backing

        private Repair[] repairs;
        private string status;
        private bool busy;
        private Customer[] currentCustomer;
        private Property[] currentProperty;
        private Repair selectedRepair;
        private SysCode[] repairNoteTypes;
        private RepairNote[] repairNotes;

        public RepairNote[] RepairNotes
        {
            get { return repairNotes; }

            set
            {
                if (repairNotes != value)
                {
                    repairNotes = value;
                    OnPropertyChanged("RepairNotes");
                }
            }
        }

        private Config config;

        public Config Config
        {
            get { return config; }

            private set
            {
                if (config != value)
                {
                    config = value;
                    OnPropertyChanged("Config");
                }
            }
        }

        public SysCode[] RepairNoteTypes
        {
            get { return repairNoteTypes; }

            set
            {
                if (repairNoteTypes != value)
                {
                    repairNoteTypes = value;
                    OnPropertyChanged("RepairNoteTypes");
                }
            }
        }

        public Repair SelectedRepair
        {
            get { return selectedRepair; }

            set
            {
                if (selectedRepair != value)
                {
                    selectedRepair = value;
                    OnPropertyChanged("SelectedRepair");

                    ThreadPool.QueueUserWorkItem(async cb => await LoadRepairDetailsAsync());
                }
            }
        }

        public Property[] CurrentProperty
        {
            get { return currentProperty; }

            set
            {
                if (currentProperty != value)
                {
                    currentProperty = value;
                    OnPropertyChanged("CurrentProperty");
                }
            }
        }

        public Customer[] CurrentCustomer
        {
            get { return currentCustomer; }

            set
            {
                if (currentCustomer != value)
                {
                    currentCustomer = value;
                    OnPropertyChanged("CurrentCustomer");
                }
            }
        }

        public bool Busy
        {
            get { return busy; }

            set
            {
                if (busy != value)
                {
                    busy = value;
                    OnPropertyChanged("Busy");
                }
            }
        }

        public string Status
        {
            get { return status; }

            set
            {
                if (status != value)
                {
                    status = value;
                    OnPropertyChanged("Status");
                }
            }
        }

        public Repair[] Repairs
        {
            get { return repairs; }

            set
            {
                if (repairs != value)
                {
                    repairs = value;
                    OnPropertyChanged("Repairs");
                }
            }
        }
        

        // App/supporting/UI routines

        public void LoadConfig(string filename)
        {
            string json = File.ReadAllText(filename);
            Config = JsonConvert.DeserializeObject<Config>(json);
            configFilename = filename;
        }

        private void SaveConfig()
        {
            string json = JsonConvert.SerializeObject(config);
            File.WriteAllText(configFilename, json);
        }

        private void SetBusy(string status)
        {
            Busy = true;
            Status = status;
        }

        private void SetDone(string status)
        {
            Busy = false;
            Status = status;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private HttpClient GetClient()
        {
            var http = new HttpClient();
            http.BaseAddress = new Uri(config.ApiUrl);
            http.DefaultRequestHeaders.Add("API-Key", config.ApiKey);

            return http;
        }

        public DocumentLocation[] GetSelectedRepairDocumentLocations()
        {
            var dls = new List<DocumentLocation>();

            if (!string.IsNullOrEmpty(selectedRepair.Id))
                dls.Add(new DocumentLocation("REPAIRS", selectedRepair.Id));

            if (!string.IsNullOrEmpty(selectedRepair.PropertyId))
                dls.Add(new DocumentLocation("PROPERTY", selectedRepair.PropertyId));

            if (!string.IsNullOrEmpty(selectedRepair.CustomerId))
                dls.Add(new DocumentLocation("TENANT", selectedRepair.CustomerId));

            return dls.ToArray();
        }


        // API operations

        public async Task LoadRepairsAsync(DateTime? from = null)
        {
            if (!from.HasValue)
                from = DateTime.Parse(DEFAULT_DATE_FROM);

            SetBusy($"Loading repairs from {from:yyyy-MM-dd}...");

            using (var http = GetClient())
            {
                var r0 = await http.GetAsync($"api/repair/contractor/{config.ContractorCode}?recordedAfter={from:yyyy-MM-dd}");
                if (!r0.IsSuccessStatusCode)
                {
                    SetDone($"Error loading repairs: {r0.StatusCode}: {r0.ReasonPhrase}");
                    return;
                }

                var repairs = await r0.Content.ReadAsAsync<Repair[]>();
                Repairs = repairs;
            }

            SetDone($"Loaded {repairs.Length} repairs.");
        }

        public async Task LoadRepairDetailsAsync()
        {
            CurrentCustomer = null;
            CurrentProperty = null;

            if (selectedRepair == null)
                return;

            if (!string.IsNullOrEmpty(selectedRepair.CustomerId))
            {
                SetBusy("Loading customer info...");
                using (var http = GetClient())
                {
                    var r0 = await http.GetAsync($"api/customer/{selectedRepair.CustomerId}");
                    if (!r0.IsSuccessStatusCode)
                    {
                        SetDone($"Error loading customer: {r0.StatusCode}: {r0.ReasonPhrase}");
                        return;
                    }
                    CurrentCustomer = new[] { await r0.Content.ReadAsAsync<Customer>() };
                }
                SetDone($"Loaded customer {selectedRepair.CustomerId}.");
            }

            if (!string.IsNullOrEmpty(selectedRepair.PropertyId))
            {
                SetBusy("Loading property info...");
                using (var http = GetClient())
                {
                    var r0 = await http.GetAsync($"api/property/{selectedRepair.PropertyId}");
                    if (!r0.IsSuccessStatusCode)
                    {
                        SetDone($"Error loading property: {r0.StatusCode}: {r0.ReasonPhrase}");
                        return;
                    }
                    CurrentProperty = new[] { await r0.Content.ReadAsAsync<Property>() };
                }
                SetDone($"Loaded property {selectedRepair.PropertyId}.");
            }
        }

        public async Task LazyLoadRepairNoteTypesAsync()
        {
            if (repairNoteTypes != null)
                return;

            SetBusy("Loading repair note types...");
            using (var http = GetClient())
            {
                var r0 = await http.GetAsync($"api/repairnote/types");
                if (!r0.IsSuccessStatusCode)
                {
                    SetDone($"Error loading repair note types: {r0.StatusCode}: {r0.ReasonPhrase}");
                    return;
                }
                RepairNoteTypes = await r0.Content.ReadAsAsync<SysCode[]>();
            }
            SetDone($"Loaded {repairNoteTypes.Length} repair note types.");
        }

        public async Task<Document[]> GetSelectedRepairDocumentsAsync()
        {
            SetBusy("Loading documents for selected repair...");

            var locations = GetSelectedRepairDocumentLocations();

            var documents = new List<Document>();
            using (var http = GetClient())
            {
                foreach (var location in locations)
                {
                    // Grab document list from API and add to result
                    var r0 = await http.GetAsync($"api/documents/{location.Context}/{location.Id}");
                    if (!r0.IsSuccessStatusCode)
                        continue;

                    var docs = await r0.Content.ReadAsAsync<Document[]>();
                    documents.AddRange(docs);
                }
            }

            SetDone($"Loaded {documents.Count} {(documents.Count == 1 ? "document" : "documents")}.");

            return documents.ToArray();
        }

        public async Task AddRepairNoteAsync(RepairNote repairNote)
        {
            SetBusy($"Adding note to repair {repairNote.RepairId}...");

            using (var http = GetClient())
            {
                var r0 = await http.PostAsJsonAsync($"api/repair/{repairNote.RepairId}/notes", repairNote);
                if (!r0.IsSuccessStatusCode)
                {
                    SetDone($"Error adding repair note: {r0.StatusCode}: {r0.ReasonPhrase}");
                    return;
                }

                int noteId = await r0.Content.ReadAsAsync<int>();
                SetDone($"Repair note {noteId} added to repair {repairNote.RepairId}.");
            }            
        }

        public async Task DownloadDocumentAsync(string fileKey, string fluff, string destination)
        {
            SetBusy("Downloading document...");

            using (var http = GetClient())
            {
                using (var fs = File.Create(destination))
                {
                    using (var hs = await http.GetStreamAsync($"api/document/{fileKey}/{fluff}"))
                    {
                        await hs.CopyToAsync(fs);
                    }
                }
            }

            SetDone($"Document saved to '{destination}'.");
        }

        public async Task<string> UploadDocumentAsync(string sourceFilename, string context, string id, string destinationPath, string note)
        {
            using (var fs = File.OpenRead(sourceFilename))
            {
                using (var http = GetClient())
                {
                    var form = new MultipartFormDataContent()
                    {
                        { new StringContent(destinationPath), "path" },
                        { new StringContent(note), "note" },
                    };

                    var sc = new StreamContent(fs);
                    sc.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                    {
                        Name = "file",
                        FileName = $"'{Path.GetFileName(sourceFilename)}'",
                    };
                    form.Add(sc);

                    var r0 = await http.PostAsync($"api/document/{context}/{id}", form);
                    string response = await r0.Content.ReadAsStringAsync();

                    return response;
                }
            }
        }

        public async Task PollRepairEventLogsAsync()
        {
            string fetchFrom = $"{config.LastPoll:yyyy-MM-dd HH:mm:ss}";
            DateTime newPollDate = DateTime.Now;

            SetBusy($"Fetching repair notes from {fetchFrom}...");

            using (var http = GetClient())
            {
                var r0 = await http.GetAsync($"api/repairnote/contractor/{config.ContractorCode}?recordedAfter={fetchFrom}");
                if (!r0.IsSuccessStatusCode)
                {
                    RepairNotes = null;
                    SetDone($"Failed to fetch repair notes: {r0.StatusCode}: {r0.ReasonPhrase}");

                    return;
                }

                RepairNotes = await r0.Content.ReadAsAsync<RepairNote[]>();
                config.LastPoll = newPollDate;
                SaveConfig();

                SetDone($"Fetched {repairNotes.Length} repair {(repairNotes.Length == 1 ? "note" : "notes")}.");
            }
        }
    }
}