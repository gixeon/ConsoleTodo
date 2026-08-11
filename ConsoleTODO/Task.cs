using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTODO
{

    public class Task
    {

        // constructor
        public Task(string info, List<string> tags, string due)
        {

            taskInfo = info;
            taskDue = due;
            taskTags = tags;

        }

        // properties 
        private string taskInfo;

        public string TaskInfo
        {
            get;
            set;
        }

        private string taskDue;

        public string TaskDue
        {
            get;
            set;
        }

        private List<string> taskTags;

        public List<string> TaskTags
        {
            get;
            set;
        }
        

    }

}
