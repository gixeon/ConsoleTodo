namespace ConsoleTODO;

public class Driver
{

    public static void Main()
    {

        var view = new ConsoleView();
        var taskManager = new TaskManager();

        view.Start();

    }

}