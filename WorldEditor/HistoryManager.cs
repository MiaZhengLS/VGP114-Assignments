namespace WorldEditor;

// HistoryManager has the following functionalities:
// 1. It records the commands that are executed.
//    It should not record the command if any exception
//    is caught when executing the command.
//    To get possible exceptions, read EntityManager.cs.
// 2. It records what commands are undone.
// 3. It abandons commands that are undone once a new command is executed.
//
//    If you need a live example to better understand expected behavior,
//    you can check out this online image editor and play with its history https://www.photopea.com/

public class HistoryManager
{
    public void ExecuteCmd(ICommand cmd)
    {
        // Put your code here...
    }

    public void UndoCmd()
    {
        // Put your code here...
    }

    public void RedoCmd()
    {
        // Put your code here...
    }
}