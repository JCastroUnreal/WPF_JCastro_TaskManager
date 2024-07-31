using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media;
using WPF_JCastro_TaskManager.Models;
using TaskModel = WPF_JCastro_TaskManager.Models.Task;

namespace WPF_JCastro_TaskManager.Views
{
    public partial class AddTasks : UserControl
    {
        // Evento que se invoca al añadir una nueva tarea
        public static event Action<TaskModel> TaskAdded;

        public AddTasks()
        {
            InitializeComponent();
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            // Obtener los valores ingresados por el usuario
            string name = TaskNameTextBox.Text;
            string description = TaskDescriptionTextBox.Text;
            DateTime date = TaskDatePicker.SelectedDate ?? DateTime.Now;

            // Verificar que los campos no estén vacíos
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(description))
            {
                // Crear un nuevo objeto Task
                TaskModel newTask = new TaskModel(name, description, date);

                // Disparar el evento TaskAdded y pasar el nuevo objeto como parametro
                TaskAdded?.Invoke(newTask);

                // Limpiar los campos del formulario
                TaskNameTextBox.Clear();
                TaskDescriptionTextBox.Clear();
                TaskDatePicker.SelectedDate = null;

                // Mensaje de alerta correcto
                MessageBox.Show("Tarea agregada con éxito.");
            }
            else
            {
                // mensaje de alerta de fallo por el usuario
                MessageBox.Show("Por favor, complete todos los campos.");
            }
        }

        private void Button_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Button hoveredButton = sender as Button;

            if (hoveredButton != null)
            {
                // Creo la animación para cambiar el color del fondo
                ColorAnimation colorAnimation = new ColorAnimation
                {
                    From = (Color)ColorConverter.ConvertFromString("#831A61"),
                    To = (Color)ColorConverter.ConvertFromString("#9F339F"),
                    Duration = new Duration(TimeSpan.FromSeconds(0.3))
                };

                // Aplico la animacion al fondo del botón
                SolidColorBrush brush = new SolidColorBrush();
                hoveredButton.Background = brush;
                brush.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);

            }
        }

        private void Button_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Button hoveredButton = sender as Button;

            if (hoveredButton != null)
            {
                // Crear una animacion para volver al fondo transparente
                ColorAnimation colorAnimation = new ColorAnimation
                {
                    From = (Color)ColorConverter.ConvertFromString("#9F339F"),
                    To = (Color)ColorConverter.ConvertFromString("#831A61"),
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
