using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_JCastro_TaskManager.Models
{
    public class Task
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public Task(string name, string description, DateTime date)
        {
            Name = name;
            Description = description;
            Date = date;
        }

    }
}
