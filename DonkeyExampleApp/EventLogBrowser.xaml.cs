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
    /// Interaction logic for EventLogBrowser.xaml
    /// </summary>
    public partial class EventLogBrowser : UserControl
    {
        public EventLogBrowser()
        {
            InitializeComponent();
        }

        private async void FetchEventLogs_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            await AppModel.Current.PollRepairEventLogsAsync();
        }
    }
}