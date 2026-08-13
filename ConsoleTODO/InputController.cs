using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;

namespace ConsoleTODO;

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

            // should fr encapsulate this considering its used a lot
            string rawInput = Console.ReadLine();

            if (!int.TryParse(rawInput, out int input))
            {

                Console.WriteLine("Invalid input!");

            }
            // up to here

            if (input != (int)MainInputs.Quit)
            {

                if (input == (int)MainInputs.ViewTasks)
                {

                    while (!terminateSub)
                    {

                        console.ViewTask(model.GetTasks());

                        rawInput = Console.ReadLine();

                        if (!int.TryParse(rawInput, out input))
                        {

                            Console.WriteLine("Invalid input!");

                        }

                        if (input != (int)TaskInputs.MainMenu)
                        {

                            if (input == (int)TaskInputs.CompleteTask)
                            {

                                CompleteTask();

                            } else if (input == (int)TaskInputs.EditTask)
                            {

                                Console.WriteLine("Sorry! Not implemented yet");

                            } else if (input == (int)TaskInputs.DeleteTask)
                            {

                                DeleteTask();

                            }
                            else
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

                    CreateTask();

                } else if (input == (int) MainInputs.SaveList)
                {

                    SaveList();

                } else
                {

                    Console.WriteLine("Invalid input!");

                }

            } else
            {

                // before closing the program, it will save the file just in case you forgot to save it
                // todo: add a "should i save the list or nah?" confirmation thing
                SaveList();
                terminateMain = true;

            }

        }

    }

    private void SaveList()
    {

        console.SaveTasks();
        model.WriteTasks();

    }

    private void DeleteTask()
    {

        Console.WriteLine("Which task would you like to be deleted? ");
        string index = Console.ReadLine();

        if (!int.TryParse(index, out int i))
        {

            Console.WriteLine("Invalid input! No changes have been made");

        }
        else
        {

            model.DeleteTask(i);

        }

    }

    private void CompleteTask()
    {

        Console.WriteLine("Which task has been completed? ");
        string index = Console.ReadLine();

        if (!int.TryParse(index, out int i))
        {

            Console.WriteLine("Invalid input! No changes have been made");

        }
        else
        {

            model.CompleteTask(i);

        }

    }

    private void CreateTask()
    {

        console.PromptTaskInfo();
        string taskInfo = Console.ReadLine();

        console.PromptTaskPriority();
        string taskPriority = Console.ReadLine();

        if (!int.TryParse(taskPriority, out int priority))
        {

            Console.WriteLine("Invalid priority, defaulting to 0");

        }

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

        Task newTask = new Task(taskInfo, priority, taskTags);
        model.AddTask(newTask);

    }

}
