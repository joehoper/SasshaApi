using DonkeyWebApp.API.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace DonkeyExampleApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = AppModel.Current;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!LoadConfig())
                Application.Current.Shutdown();

            await AppModel.Current.LoadRepairsAsync();
        }

        private bool LoadConfig()
        {
            var args = Environment.GetCommandLineArgs();

            // Default to "app_launch_dir\DefaultConfig.json"
            string filename = Path.Combine(Path.GetDirectoryName(args[0]), "DefaultConfig.json");

            // Use config filename for commandline/explorer drag&drop
            if (args.Length > 1)
                filename = args[1];

            if (!File.Exists(filename))
            {
                MessageBox.Show($"Config file '{filename}' does not exist.", "Failed to load config", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }

            try
            {
                AppModel.Current.LoadConfig(filename);

                return true;
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error loading config file '{filename}': {ex.Message}", "Failed to load config", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }        
    }
}