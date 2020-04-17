using DonkeyWebApp.API.Models;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DonkeyExampleApp
{
    /// <summary>
    /// Interaction logic for RepairsBrowser.xaml
    /// </summary>
    public partial class RepairsBrowser : UserControl
    {
        public RepairsBrowser()
        {
            InitializeComponent();
        }


        // Command handlers

        private void AddRepairNote_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = AppModel.Current.SelectedRepair != null;
            e.Handled = true;
        }

        private async void AddRepairNote_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            await AppModel.Current.LazyLoadRepairNoteTypesAsync();

            var repairNote = new RepairNote()
            {
                RepairId = AppModel.Current.SelectedRepair.Id,
                Type = AppModel.Current.RepairNoteTypes[0].Text,
            };

            var dialog = new AddRepairNoteDialog(repairNote);
            if (!dialog.ShowDialog().GetValueOrDefault())
                return;

            await AppModel.Current.AddRepairNoteAsync(repairNote);
        }

        private void UploadDocument_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = AppModel.Current.SelectedRepair != null;
            e.Handled = true;
        }

        private async void UploadDocument_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var model = new DocumentUploadModel()
            {
                Locations = AppModel.Current.GetSelectedRepairDocumentLocations(),
            };

            var dialog = new DocumentUploadDialog(model);
            if (!dialog.ShowDialog().GetValueOrDefault())
                return;

            string temp = await AppModel.Current.UploadDocumentAsync(model.SourceFilename, model.Location.Context, model.Location.Id, model.DestinationPath, model.Note);

            MessageBox.Show(temp, "Temporary upload response...");
        }

        private void ViewDocuments_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = AppModel.Current.SelectedRepair != null;
            e.Handled = true;
        }

        private async void ViewDocuments_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var documents = await AppModel.Current.GetSelectedRepairDocumentsAsync();

            new DocumentsDialog(documents).Show();
        }

        private async void LoadRepairs_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            int days = Convert.ToInt32(e.Parameter);
            DateTime from = DateTime.Now.AddDays(-days);

            await AppModel.Current.LoadRepairsAsync(from);
        }
    }
}