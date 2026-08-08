using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTODO
{

    public class ConsoleView
    {

        public ConsoleView()
        {

        }

        public void Start()
        {

            Console.WriteLine("Starting program\n");
            MainMenu();

        }

        private void MainMenu()
        {

            Console.WriteLine("""
                Welcome to your To-Do List!
                [1] View tasks
                [2] Create a task
                [3] Check statistics
                [4] Export tasks

                What would you like to do today?
                """);

        }

    }

}
