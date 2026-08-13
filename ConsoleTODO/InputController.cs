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

        while (!terminateMain)
        {

            console.MainMenu();
            int input = ParseInput();

            if (input == (int)MainInputs.Quit)
            {

                // before closing the program, it will save the file just in case you forgot to save it
                // todo: add a "should i save the list or nah?" confirmation thing
                SaveList();
                break;

            }

            if (input == (int)MainInputs.ViewTasks)
            {

                ViewTasks();

            } else if (input == (int)MainInputs.CreateTask)
            {

                CreateTask();

            } else if (input == (int) MainInputs.SaveList)
            {

                SaveList();

            } else
            {

                console.InvalidInput();

            }

        }

    }

    private void ViewTasks()
    {

        int input;

        while (true)
        {

            console.ViewTask(model.GetTasks());
            input = ParseInput();

            // early exit where if its main menu itll just leave the branch and not do anything
            if (input == (int)TaskInputs.MainMenu)
            {

                break;

            }
                
            if (input == (int)TaskInputs.CompleteTask)
            {

                CompleteTask();

            }
            else if (input == (int)TaskInputs.EditTask)
            {

                Console.WriteLine("Sorry! Not implemented yet");

            }
            else if (input == (int)TaskInputs.DeleteTask)
            {

                DeleteTask();

            }
            else
            {

                console.InvalidInput();

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

            console.InvalidInput("No changes have been made!");

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

            console.InvalidInput("No changes have been made!");

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

            console.InvalidInput("Defaulting to 0");

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

    public int ParseInput()
    {

        string rawInput = Console.ReadLine();

        if (!int.TryParse(rawInput, out int input))
        {

            console.InvalidInput();

        }

        return input;

    }

}
