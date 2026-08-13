using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTODO;

public class Task
{

    // new task constructor
    public Task(string info, int priority, List<string> tags)
    {

        TaskInfo = info;
        Priority = priority;
        TaskTags = tags;
        TaskCompleted = false;

    }

    // read task constructor
    public Task(string info, int priority, List<string> tags, bool completion)
    {

        TaskInfo = info;
        Priority = priority;
        TaskTags = tags;
        TaskCompleted = completion;

    }

    public string TaskInfo
    {
        get;
        set;
    }

    public int Priority
    {
        get;
        set;
    }

    public List<string> TaskTags
    {
        get;
        set;
    }

    public bool TaskCompleted
    {
        get;
        set;
    }

    public string ToSaveString()
    {

        return $"{TaskInfo}|{Priority}|{readableTags()}|{TaskCompleted}";
    
    }

    public override string ToString()
    {

        return $"{TaskInfo}, {Priority}, \"{readableTags()}\", {TaskCompleted}";

    }

    // helper function to make user-friendly readable tags string
    private string readableTags()
    {

        string readableTags = "";

        for (int i = 0; i < TaskTags.Count; ++i)
        {

            if (i == TaskTags.Count - 1)
            {

                string tag = TaskTags[i];
                readableTags += tag;

            }
            else
            {

                string tag = TaskTags[i];
                readableTags += tag + ",";

            }

        }

        return readableTags;

    }

}