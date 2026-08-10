using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTODO
{

    public class Task
    {

        private string taskInfo;

        public string TaskInfo
        {
            get;
            set;
        }

        private string due;

        public string Due
        {
            get;
            set;
        }

        private List<string> tags;

        public List<string> Tags
        {
            get;
            set;
        }
        

    }

}
