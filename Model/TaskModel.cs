using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Enuns;

namespace Tasks.Model
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Concluded { get; set; }
        public PriorityEnum Priority { get; set; }
    }
}
