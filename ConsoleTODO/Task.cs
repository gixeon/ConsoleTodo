using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTODO
{

    public class Task
    {

        // new task constructor
        public Task(string info, int priority, List<string> tags)
        {

            _taskInfo = info;
            _priority = priority;
            _taskTags = tags;
            _taskCompleted = false;

        }

        // read task constructor
        public Task(string info, int priority, List<string> tags, bool completion)
        {

            _taskInfo = info;
            _priority = priority;
            _taskTags = tags;
            _taskCompleted = completion;

        }

        // properties 
        private string _taskInfo;

        public string TaskInfo
        {
            get;
            set;
        }

        private int _priority;

        public int Priority
        {
            get;
            set;
        }

        private List<string> _taskTags;

        public List<string> TaskTags
        {
            get;
            set;
        }

        private bool _taskCompleted;

        public bool TaskCompleted
        {
            get;
            set;
        }

        public string ToSaveString()
        {

            string readableTags = "";

            for (int i = 0; i < _taskTags.Count; ++i)
            {
                
                if (i == _taskTags.Count - 1)
                {

                    string tag = _taskTags[i];
                    readableTags += tag;

                }
                else
                {

                    string tag = _taskTags[i];
                    readableTags += tag + ",";

                }
                
            }

            return $"{_taskInfo}|{_priority}|{readableTags}|{_taskCompleted}";
        
        }

        public override string ToString()
        {

            string readableTags = "";

            for (int i = 0; i < _taskTags.Count; ++i)
            {

                if (i == _taskTags.Count - 1)
                {

                    string tag = _taskTags[i];
                    readableTags += tag;

                }
                else
                {

                    string tag = _taskTags[i];
                    readableTags += tag + ",";

                }

            }

            return $"{_taskInfo}, {_priority}, \"{readableTags}\", {_taskCompleted}";

        }


    }

}
