using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConsoleTODO
{
    
    public class TaskModel
    {

        private List<Task> tasks = new List<Task>();

        private readonly string saveFileDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "tasks.txt");

        public TaskModel()
        {

            tasks = ReadTasks();

        }

        public void AddTask(Task task)
        {

            tasks.Add(task);

        }

        public List<Task> GetTasks()
        {

            return tasks;

        }

        public void CompleteTask(int index)
        {

            Task curr = tasks[index];
            curr.TaskCompleted = true;

        }

        public void DeleteTask(int index)
        {

            tasks.RemoveAt(index);

        }

        private List<Task> ReadTasks()
        {

            List<Task> reading = new List<Task>();

            try
            {

                using StreamReader read = new StreamReader(saveFileDir);

                string line;
                
                while ((line = read.ReadLine())
                       != null)
                {

                    string[] taskRead = line.Split('|');
                    
                    string taskInfo = taskRead[0];
                    int priority = int.Parse(taskRead[1]);
                    
                    List<string> tags = new List<string>();
                    string[] readableTags = taskRead[2].Split(',');
                    foreach (string tag in readableTags)
                    {

                        tags.Add(tag);

                    }

                    bool complete = bool.Parse(taskRead[3]);

                    Task newTask = new Task(taskInfo, priority, tags, complete);
                    reading.Add(newTask);

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

            try
            {

                using StreamWriter write = new StreamWriter(saveFileDir);

                foreach (Task task in tasks)
                {

                    write.WriteLine(task.ToSaveString());
                
                }

            }

            catch
            {

                Console.WriteLine("Was unable to write the tasks into a file!");

            }

        }

    }

}
