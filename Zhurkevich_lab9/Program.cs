using System.Diagnostics;
using Zhurkevich_lab9;



TaskManager.PrintTasks();
ArrowsMenu arrowsMenu = new ArrowsMenu(3, TaskManager.Processes.Length + 2);
Process process = null;
while (true)
{
    Key key = arrowsMenu.ReadKey();
    if (process == null)
    {
        switch (key)
        {
            case Key.UpArrow:
                arrowsMenu.Up();
                break;
            case Key.DownArrow:
                arrowsMenu.Down();
                break;
            case Key.Enter:
                process = TaskManager.Processes[arrowsMenu.Current];
                TaskManager.PrintTaskInfo(process);
                arrowsMenu = new ArrowsMenu(3, 9);
                break;
            case Key.Unused:
                break;
        }
    }
    else
    {
        switch (key)
        {
            case Key.Backspace:
                TaskManager.PrintTasks();
                process = null;
                arrowsMenu = new ArrowsMenu(3, TaskManager.Processes.Length + 2);
                break;
            case Key.D:
                if (TaskManager.EndProcess(process))
                {
                    TaskManager.PrintTasks();
                    process = null;
                    arrowsMenu = new ArrowsMenu(3, TaskManager.Processes.Length + 2);
                }
                break;
            case Key.Del:
                if (TaskManager.EndProcesses(process))
                {
                    TaskManager.PrintTasks();
                    process = null;
                    arrowsMenu = new ArrowsMenu(3, TaskManager.Processes.Length + 2);
                }
                break;
            case Key.Unused:
                break;
        }
    }

}