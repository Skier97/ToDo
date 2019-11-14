using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo
{
    static class Menu
    {
        public static int WriteMenu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1- Add task");
            Console.WriteLine("2 - Mark task completed");
            Console.WriteLine("3 - Show tasks on the week");
            Console.WriteLine("4 - Show tasks today");
            Console.WriteLine("5 - Add task on today");
            Console.WriteLine("6 - Exit");
            //Console.Write("Input number:");

            return GetUserInt("Input number: ");
        }

        public static string GetUserString(string text)
        {
            while(true)
            {
                try
                {
                    Console.Write(text);
                    string retText = Console.ReadLine();
                    if (retText != "")
                    {                        
                        return retText;
                    }   
                }
                catch (Exception ex)
                {
                    Menu.ShowError(ex.Message);
                    Menu.ShowMessage("Try again!\n");
                }
            }
        }

        public static int GetUserInt(string text)
        {
            while (true)
            {
                try
                {
                    Console.Write(text);
                    return int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Menu.ShowError(ex.Message);
                    Menu.ShowMessage("Try again!\n");
                }
            }
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
                var diffDays = (tasks[i].DateTask - DateTime.Today).TotalDays;
                if ((tasks[i].MarkTask == false) && (diffDays < 7) && (diffDays >= 0))
                {
                    Console.Write($"\n{i + 1} - Name: {tasks[i].NameTask}, Date: {tasks[i].DateTask}");
                }
            }

            Console.WriteLine();
        }
        
        public static void ShowTasksToday(List<Tasks> tasks)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                var diffDays = (tasks[i].DateTask - DateTime.Today).TotalDays;
                if ((tasks[i].MarkTask == false) && (diffDays == 0))
                {
                    Console.Write($"\n{i + 1} - Name: {tasks[i].NameTask}, Date: {tasks[i].DateTask}");
                }
            }

            Console.WriteLine();
        }

        public static void ShowUnfulfilledTasks(List<Tasks> tasks)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                if ((tasks[i].MarkTask == false))
                {
                    Console.Write($"\n{i + 1} - Name: {tasks[i].NameTask}, Date: {tasks[i].DateTask}");
                }
            }

            Console.WriteLine();
        }

        public static Tasks GetTask(List<Tasks> colTasks)
        {
            int userInput = Menu.GetUserInt("Input number: ");
            return colTasks[userInput - 1];
        }
    }
}

