using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DonkeyExampleApp
{
    /// <summary>
    /// Interaction logic for DocumentUploadDialog.xaml
    /// </summary>
    public partial class DocumentUploadDialog : Window
    {
        private readonly DocumentUploadModel model;

        public DocumentUploadDialog(DocumentUploadModel model)
        {
            InitializeComponent();

            DataContext = this.model = model;
        }

        private void UploadDocument_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true; // Validation!!!
            e.Handled = true;
        }

        private void UploadDocument_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new OpenFileDialog()
            {
                Title = "Choose document to upload...",
                Filter = "All files (*.*)|*.*",
                FilterIndex = 0,
                CheckFileExists = true,
            };

            if (string.IsNullOrEmpty(model.SourceFilename))
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            else
                ofd.FileName = model.SourceFilename;

            if (!ofd.ShowDialog().GetValueOrDefault())
                return;

            model.SourceFilename = ofd.FileName;
            model.DestinationPath = Path.Combine(AppModel.Current.Config.ContractorCode, Path.GetFileName(ofd.FileName)).Replace('\\', '/');
        }
    }
}