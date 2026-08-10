using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTODO
{

    public class ConsoleView
    {

        public ConsoleView()
        {

        }

        public void Start()
        {

            Console.WriteLine("Starting program\n");
            MainMenu();

        }

        public void MainMenu()
        {

            Console.WriteLine("""
                Welcome to your To-Do List!
                [1] View tasks
                [2] Create a task
                [3] Save to-do list
                [4] Export tasks
                [5] Quit program

                What would you like to do today?
                """);
            Console.WriteLine("\n");

        }

        public void ViewTask(List<Task> taskList)
        {

            Console.WriteLine("These are your tasks:");

            foreach (var task in taskList)
            {
                task.ToString();
            }

            Console.WriteLine("\n");
            Console.WriteLine("""
                What would you like to do?
                [1] Complete task
                [2] Edit task
                [3] Delete task
                [4] Return to main menu
                """);

            Console.WriteLine("\n");

        }

        public void CreateTask()
        {

        }

        public void PromptTaskName()
        {

        }

        public void PromptTaskTags()
        {

        }

        public void PromptTaskDueDate()
        {

        }

        public void ExportTasks()
        {

            Console.WriteLine("Exporting a .csv file to desktop...");

        }

        public void Quit()
        {

            Console.WriteLine("Saving tasks... Closing program...");
        }


    }

}
