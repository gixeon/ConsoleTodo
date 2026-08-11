namespace ConsoleTODO;

public class Driver
{

    public static void Main()
    {

        var view = new ConsoleView();
        var inputController = new InputController(view);
        var taskModel = new TaskModel();

        Start(inputController, taskModel);

    }

    private static void Start(InputController input, TaskModel model)
    {

        input.StartMonitoring();

    }

}