using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonkeyApiClient
{
    public class ApiUploadSettings : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string apiKey = "YOUR_API_KEY_HERE";
        private string baseUrl = "YOUR_API_URL_HERE";
        private bool trialRun = true;
        private string reportFormat = "HTML";

        public string ReportFormat
        {
            get { return reportFormat; }

            set
            {
                if (reportFormat != value)
                {
                    reportFormat = value;
                    OnPropertyChanged("ReportFormat");
                }
            }
        }

        public bool TrialRun
        {
            get { return trialRun; }

            set
            {
                if (trialRun != value)
                {
                    trialRun = value;
                    OnPropertyChanged("TrialRun");
                }
            }
        }

        public string BaseUrl
        {
            get { return baseUrl; }

            set
            {
                if (baseUrl != value)
                {
                    baseUrl = value;
                    OnPropertyChanged("BaseUrl");
                }
            }
        }

        public string ApiKey
        {
            get { return apiKey; }

            set
            {
                if (apiKey != value)
                {
                    apiKey = value;
                    OnPropertyChanged("ApiKey");
                }
            }
        }

        public string Uri => $"{baseUrl}Api.aspx?Command=DataImport&ApiKey={apiKey}&TrialRun={(trialRun ? "true" : "false")}&ReportFormat={reportFormat}";

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                PropertyChanged(this, new PropertyChangedEventArgs("Uri"));                
            }
        }
    }
}