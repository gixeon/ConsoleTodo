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
                [4] Quit program

                What would you like to do today?
                """);
            Console.WriteLine("\n");

        }

        public void ViewTask(List<Task> tasks)
        {

            Console.WriteLine("These are your tasks:");

            foreach (Task task in tasks)
            {
                Console.WriteLine(task.ToString());
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

        public void PromptTaskInfo()
        {

            Console.WriteLine("Task description: ");

        }

        public void PromptTaskTags()
        {

            Console.WriteLine("Tags: ");

        }

        public void PromptTaskDueDate()
        {

            Console.WriteLine("Due date: ");

        }

        public void SaveTasks()
        {

            Console.WriteLine("Saving tasks to a .csv file in desktop...");

        }

        public void Quit()
        {

            Console.WriteLine("Saving tasks... Closing program...");
        }


    }

}
