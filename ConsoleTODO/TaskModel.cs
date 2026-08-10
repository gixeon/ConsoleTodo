using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConsoleTODO
{
    
    public class TaskModel
    {

        // tasks that have been saved from prev session go here
        private List<Task> tasks = new List<Task>();

        // tasks that were added this session go here
        private List<Task> shortTerm = new List<Task>();

        public TaskModel()
        {

            tasks = ReadTasks();

        }

        private List<Task> ReadTasks()
        {

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            List<Task> reading = new List<Task>();

            try
            {

                using StreamReader read = new StreamReader(Path.Combine(desktopPath, "tasks.txt"));

                string line;
                
                while ((line = read.ReadLine())
                       != null)
                {

                    

                }

            }

            catch
            {

                Console.WriteLine("Was unable to read/find the task file!");

            }

            return reading;

        }

        public void WriteTasks()
        {



        }

    }

}
