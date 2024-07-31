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

namespace WPF_JCastro_TaskManager.Views
{
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();

            string saveTheme = Properties.Settings.Default.SelectedTheme;

            foreach (ComboBoxItem item in ThemeComboBox.Items)
            {
                if (item.Tag.ToString() == saveTheme)
                {
                    ThemeComboBox.SelectedItem = item;
                    break;
                }
            }
        }

        private void ThemeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            var selectedItem = comboBox.SelectedItem as ComboBoxItem;
            var selectedTheme = selectedItem.Tag.ToString();

            // Guardo el thema seleccionado en la configuracion
            Properties.Settings.Default.SelectedTheme = selectedTheme;
            Properties.Settings.Default.Save();

            switch (selectedTheme)
            {
                case "Light":
                    ChangeToLightTheme();
                    break;
                case "Dark":
                    ChangeToDarkTheme();
                    break;
            }
        }

        private void ChangeToLightTheme()
        {
            ResourceDictionary lightTheme = new ResourceDictionary { Source = new Uri("Themes/LightTheme.xaml", UriKind.Relative) };
            ResourceDictionary appStyles = new ResourceDictionary { Source = new Uri("Styles/GeneralStyles.xaml", UriKind.Relative) };

            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(lightTheme);
            Application.Current.Resources.MergedDictionaries.Add(appStyles);

        }

        private void ChangeToDarkTheme()
        {
            ResourceDictionary darkTheme = new ResourceDictionary { Source = new Uri("Themes/DarkTheme.xaml", UriKind.Relative) };
            ResourceDictionary appStyles = new ResourceDictionary { Source = new Uri("Styles/GeneralStyles.xaml", UriKind.Relative) };

            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(darkTheme);
            Application.Current.Resources.MergedDictionaries.Add(appStyles);

        }
    }
}
