using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo
{
    static class Menu
    {
        public static void WriteMenu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1- Add task");
            Console.WriteLine("2 - Mark task completed");
            Console.WriteLine("3 - Show tasks on the week");
            Console.WriteLine("4 - Show tasks today");
            Console.WriteLine("5 - Add task on today");
            Console.WriteLine("6 - Exit");
        }

        public static string GetUserString(string text)
        {
            string retText = "";
            do
            {
                try
                {
                    Console.Write(text);
                    retText = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    ShowError(ex.Message);
                    ShowMessage("Try again!\n");
                }
            } while (retText == "");
            return retText;
        }

        public static int GetUserInt(string text)
        {
            int retValue;
            ShowMessage(text);
            string inputUser = Console.ReadLine();
            while (!Int32.TryParse(inputUser, out retValue))
            {
                ShowMessage("Error! Try again!\n");
                ShowMessage(text);
                inputUser = Console.ReadLine();
            }
            return retValue;
        }

        public static void ShowMessage(string text)
        {
            Console.WriteLine(text);
        }

        public static void ShowError(string text)
        {
            Console.WriteLine($"Error!!!: {text}");
        }

        public static void ShowTaskWeek(List<Tasks> tasks)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                var diffDays = DaysUntillToday(tasks[i].DateTask);
                if ((tasks[i].AccomplishTask == false) && (diffDays < 7) && (diffDays >= 0))
                {
                    ShowTask(i, tasks[i]);
                }
            }

            Console.WriteLine();
        }
        
        public static void ShowTasksToday(List<Tasks> tasks)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                var diffDays = DaysUntillToday(tasks[i].DateTask);
                if ((tasks[i].AccomplishTask == false) && (diffDays == 0))
                {
                    ShowTask(i, tasks[i]); 
                }
            }

            Console.WriteLine();
        }

        private static void ShowTask(int i, Tasks task)
        {
            Console.Write($"\n{i + 1} - Name: {task.NameTask}, Date: {task.DateTask}");
        }

        public static void ShowUnfulfilledTasks(List<Tasks> tasks)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                if ((tasks[i].AccomplishTask == false))
                {
                    Console.Write($"\n{i + 1} - Name: {tasks[i].NameTask}, Date: {tasks[i].DateTask}");
                }
            }

            Console.WriteLine();
        }

        public static Tasks GetTask(List<Tasks> colTasks)
        {
            int userInput = GetUserInt("Input number: ");
            while ((userInput > colTasks.Count) || (userInput < 1))
            {
                ShowMessage("Error range tasks! Try again!\n");
                userInput = GetUserInt("Input number: ");
            }
            return colTasks[userInput - 1]; 
        }

        private static double DaysUntillToday(DateTime dayTask)
        {
            return (dayTask - DateTime.Today).TotalDays;
        }

        public static int CheckDays(int day)
        {
            while ((day < 1) || (day > 31))
            {
                ShowError("Error range days!");
                day = int.Parse(Console.ReadLine());
            }
            return day;
        }

        public static int CheckMonth(int month)
        {
            while ((month < 1) || (month > 12))
            {
                ShowError("Error range month!");
                month = int.Parse(Console.ReadLine());
            }
            return month;
        }

        public static int CheckYear(int year)
        {
            while (year < DateTime.Now.Year)
            {
                ShowError("Error range year!");
                year = int.Parse(Console.ReadLine());
            }
            return year;
        }
    }
}

