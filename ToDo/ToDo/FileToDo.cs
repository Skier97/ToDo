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
            tasks = GetAllTasks();
        }

        public void AddTask(Tasks task)
        {
            tasks.Add(task);
            UpdateDbTasks();
        }

        public int CompletedTask(Tasks task)
        {
            bool flagTask = false;

            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].Id == task.Id)
                {
                    tasks.Remove(tasks[i]);
                    flagTask = true;
                }
            }

            UpdateDbTasks();

            if (flagTask == false)
            {
                return (int)ResultStart.error;
            }

            return (int)ResultStart.allGood;
        }

        public List<Tasks> GetAllTasks()
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
