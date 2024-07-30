using System;
using System.Windows;
using System.Windows.Controls;
using WPF_JCastro_TaskManager.Models;
using TaskModel = WPF_JCastro_TaskManager.Models.Task;

namespace WPF_JCastro_TaskManager.Views
{
    public partial class AddTasks : UserControl
    {
        public static event Action<TaskModel> TaskAdded;
        public AddTasks()
        {
            InitializeComponent();
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            string name = TaskNameTextBox.Text;
            string description = TaskDescriptionTextBox.Text;
            DateTime date = TaskDatePicker.SelectedDate ?? DateTime.Now;

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(description))
            {
                TaskModel newTask = new TaskModel(name, description, date);
                TaskAdded?.Invoke(newTask);

                TaskNameTextBox.Clear();
                TaskDescriptionTextBox.Clear();
                TaskDatePicker.SelectedDate = null;

                MessageBox.Show("Tarea agregada con éxito.");
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos.");
            }
        }
    }
}
