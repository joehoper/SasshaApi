using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DonkeyApiClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ApiUploadSettings uploadSettings = new ApiUploadSettings();

        public MainWindow()
        {
            InitializeComponent();

            DataContext = uploadSettings;            
        }

        private void UploadOld_Click(object sender, RoutedEventArgs e)
        {
            string inputFilename = PromptForInputFilename();
            if (inputFilename == null)
                return;

            byte[] data = File.ReadAllBytes(inputFilename);

            var wc = new WebClient();
            byte[] response = wc.UploadData(uploadSettings.Uri, "POST", data);
            if (response == null || response.Length == 0)
            {
                MessageBox.Show("Empty or null response", "Unknowable error", MessageBoxButton.OK, MessageBoxImage.Question);
                return;
            }

            string outputFilename = PromptForOutputFilename();
            if (outputFilename == null)
                return;

            File.WriteAllBytes(outputFilename, response);
        }

        private async void UploadNew_Click(object sender, RoutedEventArgs e)
        {
            string inputFilename = PromptForInputFilename();
            if (inputFilename == null)
                return;

            var h = new HttpClient();
            h.BaseAddress = new Uri(uploadSettings.BaseUrl);
            h.DefaultRequestHeaders.Add("API-Key", uploadSettings.ApiKey);

            if (uploadSettings.ReportFormat == "XML")
            {
                h.DefaultRequestHeaders.Accept.Clear();
                h.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("text/xml"));
            }

            string operation = uploadSettings.TrialRun ? "trial" : "commit";

            using (var stream = File.OpenRead(inputFilename))
            {
                var response = await h.PostAsync($"api/repair/import/{operation}", new StreamContent(stream));
                if (!response.IsSuccessStatusCode)
                {
                    string errorText = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(errorText, $"HTTP error {response.StatusCode}", MessageBoxButton.OK, MessageBoxImage.Error);

                    return;
                }

                string outputFilename = PromptForOutputFilename();
                if (outputFilename != null)
                {
                    byte[] data = await response.Content.ReadAsByteArrayAsync();
                    File.WriteAllBytes(outputFilename, data);
                }
            }
        }
        
        private string PromptForInputFilename()
        {
            var ofd = new OpenFileDialog()
            {
                Filter = "Xml files (*.xml)|*.xml",
                FilterIndex = 0,
                CheckFileExists = true,
                Title = "Choose XML file to upload...",
            };

            if (!ofd.ShowDialog().GetValueOrDefault())
                return null;

            return ofd.FileName;
        }

        private string PromptForOutputFilename()
        {
            var sfd = new SaveFileDialog()
            {
                Filter = (uploadSettings.ReportFormat == "XML" ? "XML files (*.xml)|*.xml" : "HTML files (*.html)|*.html") + "|All files (*.*)|*.*",
                DefaultExt = "." + uploadSettings.ReportFormat.ToLower(),
                FilterIndex = 0,
                CheckPathExists = true,
                Title = "Save response...",
            };

            if (!sfd.ShowDialog().GetValueOrDefault())
                return null;

            return sfd.FileName;
        }





        private static async Task UploadExampleAsync()
        {
            const string INPUT_FILENAME = "InterfaceRequest_2316.xml";
            const string OUTPUT_FILENAME = "UploadReport.html";
            const string BASE_URL = "https://donkey.sassha.co.uk/";
            const string API_KEY = "fRX4ZOcM9eghg3VCpIPFyBZa";
            const string REPORT_FORMAT = "HTML";
            const bool TRIAL_RUN = true;

            var h = new HttpClient();
            h.BaseAddress = new Uri(BASE_URL);
            h.DefaultRequestHeaders.Add("API-Key", API_KEY);

            if (REPORT_FORMAT == "XML")
            {
                h.DefaultRequestHeaders.Accept.Clear();
                h.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("text/xml"));
            }

            string operation = TRIAL_RUN ? "trial" : "commit";

            using (var stream = File.OpenRead(INPUT_FILENAME))
            {
                var response = await h.PostAsync($"api/repair/import/{operation}", new StreamContent(stream));
                if (!response.IsSuccessStatusCode)
                {
                    string errorText = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(errorText, $"HTTP error {response.StatusCode}", MessageBoxButton.OK, MessageBoxImage.Error);

                    return;
                }

                byte[] data = await response.Content.ReadAsByteArrayAsync();
                File.WriteAllBytes(OUTPUT_FILENAME, data);
            }
        }

    }
}