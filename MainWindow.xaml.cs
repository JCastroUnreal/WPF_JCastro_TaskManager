using System.Windows;
using System.Windows.Media;
using WPF_JCastro_TaskManager.Views;
using WPF_JCastro_TaskManager.ViewModels;

using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace WPF_JCastro_TaskManager
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainContentControl.Content = new ViewTasks();
            MainWindowVM.Button_Click(ViewTasks_Button);
        }

        private void ViewTasks_Click(object sender, RoutedEventArgs e)
        {
            MainContentControl.Content = new ViewTasks();

            MainWindowVM.Button_Click(sender);
        }

        private void AddTasks_Click(object sender, RoutedEventArgs e)
        {
            MainContentControl.Content = new AddTasks();

            MainWindowVM.Button_Click(sender);

        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            MainContentControl.Content = new Settings();

            MainWindowVM.Button_Click(sender);

        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void GenericButton_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            MainWindowVM.Button_Hover(sender);

        }

        private void GenericButton_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            MainWindowVM.Button_Leave(sender);

        }
    }
}