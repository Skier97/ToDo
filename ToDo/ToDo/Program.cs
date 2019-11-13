using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo
{
    class Program
    {
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
                        Tasks task = new Tasks(nameTask, yearTask, monthTask, dayTask);

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
                            if (dataBase.CompletedTask(compTask) == (int)ResultStart.allGood)
                            {
                                Menu.ShowMessage("This task has been successfully completed!");
                            }
                            else
                            {
                                Menu.ShowMessage("This task is already completed!!!");
                            }
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
