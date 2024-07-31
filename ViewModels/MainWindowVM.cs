using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace WPF_JCastro_TaskManager.ViewModels
{
    public static class MainWindowVM
    {
        private static Button selectedButton = null;
        public static void Button_Click(object sender)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                // Restablecer el color del botón previamente seleccionado
                if (selectedButton != null && selectedButton != clickedButton)
                {
                    selectedButton.Background = new SolidColorBrush(Colors.Transparent);
                }

                // Mantener el color del botón clicado
                clickedButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#831A61"));
                
                // Actualizar el botón seleccionado
                selectedButton = clickedButton;
            }
        }

        public static void Button_Hover(Object sender)
        {
            Button hoveredButton = sender as Button;

            if (hoveredButton != null && hoveredButton != selectedButton)
            {
                // Creo la animación para cambiar el color del fondo
                ColorAnimation colorAnimation = new ColorAnimation
                {
                    From = Colors.Transparent,
                    To = (Color)ColorConverter.ConvertFromString("#831A61"),
                    Duration = new Duration(TimeSpan.FromSeconds(0.3))
                };

                // Aplico la animacion al fondo del botón
                SolidColorBrush brush = new SolidColorBrush();
                hoveredButton.Background = brush;
                brush.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);

            }
        }

        public static void Button_Leave(Object sender)
        {
            Button hoveredButton = sender as Button;

            if (hoveredButton != null && hoveredButton != selectedButton)
            {
                // Crear una animacion para volver al fondo transparente
                ColorAnimation colorAnimation = new ColorAnimation
                {
                    From = (Color)ColorConverter.ConvertFromString("#831A61"),
                    To = Colors.Transparent,
                    Duration = new Duration(TimeSpan.FromSeconds(0.3))
                };

                // Aplicar la animación al fondo del botón
                SolidColorBrush brush = hoveredButton.Background as SolidColorBrush;

                if (brush != null)
                {
                    brush.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);
                }
            }

        }

    }
}
