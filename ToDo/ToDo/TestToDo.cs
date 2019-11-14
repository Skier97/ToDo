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

        public void CompletedTask(Tasks task)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].Id == task.Id)
                {
                    tasks[i].AccomplishTask = true;
                }
            }
        }


        public List<Tasks> GetAllTasks()
        {
            return tasks;
        }
    }
}
