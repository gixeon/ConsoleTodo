using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;

namespace ConsoleTODO
{
    
    // main menu inputs
    enum MainInputs
    {

        ViewTasks = 1,
        CreateTask = 2,
        SaveList = 3,
        Quit = 4

    }

    // sub-menu task view inputs
    enum TaskInputs
    {

        CompleteTask = 1,
        EditTask = 2,
        DeleteTask = 3,
        MainMenu = 4

    }

    public class InputController
    {

        // linking the view and model to the input
        private ConsoleView console;
        private TaskModel model;

        public InputController(ConsoleView view, TaskModel info)
        {

            console = view;
            model = info;

        }

        public void StartMonitoring()
        {

            bool terminateMain = false;
            bool terminateSub = false;
            console.MainMenu();

            while (!terminateMain)
            {

                //int input = int.Parse(Console.ReadLine());
                string rawInput = Console.ReadLine();

                if (!int.TryParse(rawInput, out int input))
                {

                    Console.WriteLine("Invalid input!");

                }

                if (input != (int)MainInputs.Quit)
                {

                    if (input == (int)MainInputs.ViewTasks)
                    {

                        console.ViewTask(model.GetTasks());

                        while (!terminateSub)
                        {

                            rawInput = Console.ReadLine();

                            if (!int.TryParse(rawInput, out input))
                            {

                                Console.WriteLine("Invalid input!");

                            }

                            if (input != (int)TaskInputs.MainMenu)
                            {

                                if (input == (int)TaskInputs.CompleteTask)
                                {



                                } else if (input == (int)TaskInputs.EditTask)
                                {



                                } else if (input == (int)TaskInputs.DeleteTask)
                                {



                                } else
                                {

                                    Console.WriteLine("Invalid input!");

                                }

                            } else
                            {

                                terminateSub = true;

                            }

                        }

                        terminateSub = false;


                    } else if (input == (int)MainInputs.CreateTask)
                    {



                    } else if (input == (int) MainInputs.SaveList)
                    {



                    } else
                    {

                        Console.WriteLine("Invalid input!");

                    }

                } else
                {

                    terminateMain = true;

                }

            }

        }

        private void MainMenu()
        {

        }

        private void TaskMenu()
        {

        }

        private void CreateTask()
        {

        }

    }

}
