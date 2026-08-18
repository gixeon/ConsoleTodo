namespace ConsoleTODO;

public class Driver
{

    public static void Main()
    {

        var view = new ConsoleView();
        var taskModel = new TaskModel();
        var inputController = new InputController(view, taskModel);

        inputController.StartProgram();

    }

}