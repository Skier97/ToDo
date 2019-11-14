using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ToDo
{
    public class Tasks
    {
        public string NameTask { get; set; }
        public DateTime DateTask { get; set; }
        public bool AccomplishTask { get; set; }
        public Guid Id { get; private set; }

        public Tasks(string nameTask, DateTime date)
        {
            this.NameTask = nameTask;
            this.DateTask = date;
            this.AccomplishTask = false;
            this.Id = Guid.NewGuid();
        }

        public Tasks(string nameTask)
        {
            this.NameTask = nameTask;
            this.DateTask = DateTime.Today;
            this.AccomplishTask = false;
            this.Id = Guid.NewGuid();
        }

        [JsonConstructor]
        public Tasks(string nameTask, DateTime date, Guid id)
        {
            this.NameTask = nameTask;
            this.DateTask = date;
            this.AccomplishTask = false;
            this.Id = id;
        }
    }
}
