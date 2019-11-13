using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ToDo
{
    public class Tasks
    {
        public string NameTask { get; set; }
        public DateTime DateTask { get; set; }
        public bool MarkTask { get; set; }
        public Guid Id { get; private set; }

        public Tasks(string nameTask, DateTime date)
        {
            this.NameTask = nameTask;
            this.DateTask = date;
            this.MarkTask = false;
            this.Id = Guid.NewGuid();
        }

        [JsonConstructor]
        public Tasks(string nameTask, DateTime date, Guid id)
        {
            this.NameTask = nameTask;
            this.DateTask = date;
            this.MarkTask = false;
            this.Id = id;
        }
    }
}
