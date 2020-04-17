using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonkeyExampleApp
{
    public class DocumentUploadModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        private DocumentLocation[] locations;
        private string sourceFilename;
        private string destinationPath;
        private DocumentLocation location;
        private string note = "";

        public string Note
        {
            get { return note; }

            set
            {
                if (note != value)
                {
                    note = value;
                    OnPropertyChanged("Note");
                }
            }
        }

        public DocumentLocation Location
        {
            get { return location; }

            set
            {
                if (location != value)
                {
                    location = value;
                    OnPropertyChanged("Location");
                }
            }
        }

        public string DestinationPath
        {
            get { return destinationPath; }

            set
            {
                if (destinationPath != value)
                {
                    destinationPath = value;
                    OnPropertyChanged("DestinationPath");
                }
            }
        }

        public string SourceFilename
        {
            get { return sourceFilename; }

            set
            {
                if (sourceFilename != value)
                {
                    sourceFilename = value;
                    OnPropertyChanged("SourceFilename");
                }
            }
        }

        public DocumentLocation[] Locations
        {
            get { return locations; }

            set
            {
                if (locations != value)
                {
                    locations = value;
                    OnPropertyChanged("Locations");

                    // Default to first element in locations array
                    if (value?.Length > 0 && location == null)
                        Location = value[0];
                }
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}