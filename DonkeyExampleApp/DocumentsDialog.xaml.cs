using DonkeyWebApp.API.Models;
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
    /// Interaction logic for DocumentsDialog.xaml
    /// </summary>
    public partial class DocumentsDialog : Window
    {
        public DocumentsDialog(Document[] documents)
        {
            InitializeComponent();

            DataContext = documents;
        }

        private async void DocumentsListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var doc = DocumentsListView.SelectedItem as Document;
            if (doc == null)
                return;

            if (doc.ValidUntil < DateTime.Now)
            {
                MessageBox.Show("This document link has expired.  Please fetch document list again.", "Expired", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var sfd = new SaveFileDialog()
            {
                CheckPathExists = true,
                OverwritePrompt = true,
                Title = "Save document...",
                FileName = Path.GetFileName(doc.Path),
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
            };

            if (!sfd.ShowDialog().GetValueOrDefault())
                return;

            try
            {
                await AppModel.Current.DownloadDocumentAsync(doc.FileKey, doc.Fluff, sfd.FileName);
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error downloading document", MessageBoxButton.OK, MessageBoxImage.Error);                
            }
        }
    }
}