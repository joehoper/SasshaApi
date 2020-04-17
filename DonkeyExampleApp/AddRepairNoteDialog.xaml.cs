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
using System.Windows.Shapes;

namespace DonkeyExampleApp
{
    /// <summary>
    /// Interaction logic for AddRepairNoteDialog.xaml
    /// </summary>
    public partial class AddRepairNoteDialog : Window
    {
        public AddRepairNoteDialog(RepairNote repairNote)
        {
            InitializeComponent();

            DataContext = repairNote;
        }

        private void AddRepairNote_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}