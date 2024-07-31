using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using WPF_JCastro_TaskManager.Models;
using TaskModel = WPF_JCastro_TaskManager.Models.Task;

namespace WPF_JCastro_TaskManager.Views
{
    public partial class ViewTasks : UserControl
    {
        // Colección observable que almacena las tareas
        private static ObservableCollection<TaskModel> tasks = new ObservableCollection<TaskModel>();

        private static bool isSubscribed = false;

        public ViewTasks()
        {
            InitializeComponent();

            // Vincular la colección de tareas al ListBox
            TasksListBox.ItemsSource = tasks;

            // Suscribirse al evento solo si aún no está suscrito
            SubscribeToTaskAdded();
        }

        private void SubscribeToTaskAdded()
        {
            if (!isSubscribed)
            {
                AddTasks.TaskAdded += OnTaskAdded;
                isSubscribed = true;
            }
        }

        private void UnsubscribeFromTaskAdded()
        {
            if (isSubscribed)
            {
                AddTasks.TaskAdded -= OnTaskAdded;
                isSubscribed = false;
            }
        }

        private void OnTaskAdded(TaskModel newTask)
        {
            // Añadir la nueva tarea a la colección observable
            tasks.Add(newTask);
        }

        // Desuscribirse cuando el UserControl se descarga
        private void UserControl_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            UnsubscribeFromTaskAdded();
        }

    }
}
