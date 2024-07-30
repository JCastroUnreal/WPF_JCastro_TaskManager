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
        private static ObservableCollection<TaskModel> tasks = new ObservableCollection<TaskModel>();

        public ViewTasks()
        {
            InitializeComponent();
            TasksListBox.ItemsSource = tasks;
            AddTasks.TaskAdded += OnTaskAdded;
        }

        private void OnTaskAdded(TaskModel newTask)
        {
            tasks.Add(newTask);
        }
    }
}
