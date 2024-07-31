using System.Configuration;
using System.Data;
using System.Windows;
using WPF_JCastro_TaskManager.Properties;

namespace WPF_JCastro_TaskManager
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Selecciono el tema de inicio que esta guardado en Settings
            ApplyTheme(Settings.Default.SelectedTheme);

        }

        private void ApplyTheme(string theme)
        {
            ResourceDictionary resourceDictionary = new ResourceDictionary();
            switch (theme)
            {
                case "Dark":
                    resourceDictionary.Source = new Uri("Themes/DarkTheme.xaml", UriKind.Relative);
                    break;
                case "Light":
                    resourceDictionary.Source = new Uri("Themes/LightTheme.xaml", UriKind.Relative);
                    break;
                default:
                    resourceDictionary.Source = new Uri("Themes/DarkTheme.xaml", UriKind.Relative);
                    break;
            }

            // Clear existing resources
            this.Resources.MergedDictionaries.Clear();
            // Add the selected theme
            this.Resources.MergedDictionaries.Add(resourceDictionary);
            // Add general styles
            this.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("Styles/GeneralStyles.xaml", UriKind.Relative)
            });
        }
    }

}
