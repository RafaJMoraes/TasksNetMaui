using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Enuns;

namespace Tasks.Model
{
    public class TaskModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Concluded { get; set; }
        public PriorityEnum Priority { get; set; }

        public string getColor() 
        {
            return Priority.GetColor();
        }
    }
}
