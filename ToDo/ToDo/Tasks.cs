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

        public Tasks(string nameTask, int year, int month, int day)
        {
            this.NameTask = nameTask;
            this.DateTask = new DateTime(year, month, day);
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
