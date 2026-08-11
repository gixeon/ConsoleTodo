using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConsoleTODO
{
    
    public class TaskModel
    {

        private List<Task> tasks = new List<Task>();

        public TaskModel()
        {

            tasks = ReadTasks();

        }

        public void StoreTask(Task task)
        {

            tasks.Add(task);

        }

        public List<Task> GetTasks()
        {

            return tasks;

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

                    //via commas, turn read information into Task objects
                    //do something!!!

                    //Task curr = new Task();

                    //tasks.Add(curr);

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

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);


            try
            {

                using StreamWriter write = new StreamWriter(Path.Combine(desktopPath, "tasks.txt"));

                foreach (Task task in tasks)
                {

                    write.WriteLine($"{task.TaskInfo},{task.TaskTags},{task.TaskDue}");
                
                }

            }

            catch
            {

                Console.WriteLine("Was unable to write the tasks into a file!");

            }

        }

    }

}
