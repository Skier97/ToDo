using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo
{
    interface IToDo
    {
        void AddTask(Tasks task);
        int CompletedTask(Tasks task);
        List<Tasks> GetAllTasks(); 
    }
}
