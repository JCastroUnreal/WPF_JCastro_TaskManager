using System.Windows;
using WPF_JCastro_TaskManager.Views;

namespace WPF_JCastro_TaskManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ViewTasks_Click(object sender, RoutedEventArgs e)
        {
            MainContentControl.Content = new ViewTasks();
        }

        private void AddTasks_Click(object sender, RoutedEventArgs e)
        {
            MainContentControl.Content = new AddTasks();
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            MainContentControl.Content = new Settings();
        }
    }
}