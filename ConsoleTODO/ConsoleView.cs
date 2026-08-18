using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTODO
{

    public class ConsoleView
    {

        public ConsoleView() { }

        public void Start()
        {

            Console.Clear();
            Console.WriteLine("Starting program\n");
            MainMenu();

        }

        public void MainMenu()
        {

            Console.Clear();
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

            Console.Clear();
            Console.WriteLine("These are your tasks:");

            int longestInfo = 0;
            int longestTag = 0;
            foreach (var task in tasks)
            {

                if (task.TaskInfo.Length > longestInfo) { longestInfo = task.TaskInfo.Length; }
                if (task.ReadableTags().Length > longestTag) { longestTag = task.ReadableTags().Length; }

            }

            // first row showing column names
            string headRow = $"{"i",-2} | {"Info".PadRight(longestInfo)} | {"Tags".PadRight(longestTag)} | {"Priority",-2} ";
            Console.WriteLine(headRow);
            for (int i = 0; i < headRow.Length; ++i) { Console.Write("-"); }
            Console.WriteLine();
            
            for (int i = 0; i < tasks.Count; ++i)
            {
                
                Console.WriteLine($"{i,-2} | {tasks[i].TaskInfo.PadRight(longestInfo)} | {tasks[i].ReadableTags().PadRight(longestTag)} | {tasks[i].Priority,-2}");

            }

            Console.WriteLine("\n");
            Console.WriteLine("""
                What would you like to do?
                [1] Complete task
                [2] Delete task
                [3] Return to main menu
                """);

            Console.WriteLine("\n");

        }

        public void PromptTaskInfo()
        {

            Console.WriteLine("Task description: ");

        }

        public void PromptTaskTags()
        {

            Console.WriteLine("Tags (separated by commas, no spaces): ");

        }

        public void PromptTaskPriority()
        {

            Console.WriteLine("Priority (1-4): ");

        }

        public void SaveTasks()
        {

            Console.Clear();
            Console.WriteLine("Saving tasks to a .csv file in desktop...");

        }

        public void Quit()
        {

            Console.Clear();
            Console.WriteLine("Saving tasks... Closing program...");

        }

        public void InvalidInput(string extra = "")
        {

            Console.WriteLine($"Invalid input! {extra}");

        }


    }

}
