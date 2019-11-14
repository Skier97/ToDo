using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace ToDo
{
    class FileToDo:IToDo
    {
        List<Tasks> tasks = null;

        public FileToDo()
        {
            tasks = ReadTasksFromFile();
        }

        public void AddTask(Tasks task)
        {
            tasks.Add(task);
            UpdateDbTasks();
        }

        public void CompletedTask(Tasks task)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].Id == task.Id)
                {
                    tasks[i].MarkTask = true;
                }  
            }

            UpdateDbTasks();
        }

        private List<Tasks> ReadTasksFromFile()
        {
            var colTasks = new List<Tasks>();
            using (var sr = new StreamReader("./fileTasks.txt"))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    colTasks = JsonConvert.DeserializeObject<List<Tasks>>(line);
                }
            }
            return colTasks;
        }

        public List<Tasks> GetAllTasks()
        {
            return tasks;
        }

        private void UpdateDbTasks()
        {
            string jsonTasks = JsonConvert.SerializeObject(tasks);
            using (StreamWriter sw = new StreamWriter($"./fileTasks.txt", false, System.Text.Encoding.Default))
            {
                sw.WriteLine(jsonTasks);
            }
        }
    }
}
