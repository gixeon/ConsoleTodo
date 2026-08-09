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

        // model should read the pseudo-csv file then create a list containing the appropriate information
        // List<Task> taskList = model.readData();

        input.StartMonitoring();

    }

}