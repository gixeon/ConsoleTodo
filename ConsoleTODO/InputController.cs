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

            while (!terminateMain)
            {

                console.MainMenu();
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

                        console.PromptTaskInfo();
                        string taskInfo = Console.ReadLine();
                        
                        console.PromptTaskTags();
                        string rawTaskTags = Console.ReadLine();
                        List<string> taskTags = new List<string>();
                        int storeIndex = 0;

                        for (int i = 0; i < rawTaskTags.Length; ++i)
                        {

                            char c = rawTaskTags[i];

                            if (c == ',' || i == rawTaskTags.Length - 1)
                            {

                                if (i == rawTaskTags.Length - 1)
                                {

                                    ++i;

                                }

                                taskTags.Add(rawTaskTags.Substring(storeIndex, i - storeIndex));
                                storeIndex = i + 1; // +1 to prevent comma; assumes no spaces

                            }

                        }

                        console.PromptTaskDueDate();
                        string taskDueDate = Console.ReadLine();

                        Task newTask = new Task(taskInfo, taskTags, taskDueDate);
                        model.StoreTask(newTask);

                    } else if (input == (int) MainInputs.SaveList)
                    {

                        console.SaveTasks();
                        model.WriteTasks();

                    } else
                    {

                        Console.WriteLine("Invalid input!");

                    }

                } else
                {

                    console.SaveTasks();
                    model.WriteTasks();
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
