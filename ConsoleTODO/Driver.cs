namespace ConsoleTODO;

public class Driver
{

    public static void Main()
    {

        var view = new ConsoleView();
        var inputController = new InputController(view);
        var taskModel = new TaskModel();

        view.Start();

    }

}