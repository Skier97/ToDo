using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo
{
    class Program
    {
        /// <summary>
        /// Добавить новый пункт меню
        /// Добавить Таск на сегодня 
        /// Создать новый класс TodayTask и унаследоваться от Таск у которого в конструкторе будет дата автоматически = сегодня
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to ToDo!");
            //TestToDo dataBase = new TestToDo();
            var dataBase = new FileToDo();
            bool flag = true;

            do
            {
                int paragraph = Menu.WriteMenu();

                switch (paragraph)
                {
                    case 1:
                        string nameTask = Menu.GetUserString("Name task: ");
                        int dayTask = Menu.GetUserInt("Day task: ");
                        int monthTask = Menu.GetUserInt("Month task: ");
                        int yearTask = Menu.GetUserInt("Year task: ");
                        var date = new DateTime(yearTask, monthTask, dayTask);
                        Tasks task = new Tasks(nameTask, date);

                        try
                        {
                            dataBase.AddTask(task);
                            Menu.ShowMessage("This task has been succesfully added!");
                        }
                        catch (Exception ex)
                        {
                            Menu.ShowError(ex.Message);
                        }

                        break;
                    case 2:
                        Menu.ShowMessage("All unfulfilled tasks of ToDo: ");
                        Menu.ShowUnfulfilledTasks(dataBase.GetAllTasks());
                        var compTask = Menu.GetTask(dataBase.GetAllTasks());

                        try
                        {
                            dataBase.CompletedTask(compTask);
                            Menu.ShowMessage("This task has been successfully completed!");
                        }
                        catch (Exception ex)
                        {
                            Menu.ShowError(ex.Message);
                        }

                        break;
                    case 3:
                        Menu.ShowMessage("All tasks on the week: ");
                        Menu.ShowTaskWeek(dataBase.GetAllTasks());
                        
                        break;
                    case 4:
                        Menu.ShowMessage("All tasks today: ");
                        Menu.ShowTasksToday(dataBase.GetAllTasks());

                        break;
                    case 5:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Error! Try again!");
                        break;
                }
            } while (flag == true);
        }
    }
}
