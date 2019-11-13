using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo
{
    class TestToDo : IToDo
    {
        List<Tasks> tasks;

        public TestToDo()
        {
            tasks = new List<Tasks>() { new Tasks("Put a christmas tree", new DateTime(2019, 12, 30)), new Tasks("Celebrate birthday", new DateTime(2019, 12, 17)),
                    new Tasks("Go to Sochi", new DateTime(2019, 11, 21)) };
        }

        public void AddTask(Tasks task)
        {
            tasks.Add(task);
        }

        public int CompletedTask(Tasks task)
        {
            if (task == null)
            {
                return (int)ResultStart.error;
            }

            if (task.MarkTask == false)
            {
                task.MarkTask = true;
                return (int)ResultStart.allGood;
            }
            else
            {
                return (int)ResultStart.notAvailable;
            }
        }


        public List<Tasks> GetAllTasks()
        {
            return tasks;
        }
    }
}
