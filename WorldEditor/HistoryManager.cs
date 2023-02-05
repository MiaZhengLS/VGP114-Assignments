namespace WorldEditor;

public class HistoryManager
{
    private readonly Stack<ICommand> exeCmdStack;
    private readonly Stack<ICommand> undoCmdStack;

    public HistoryManager()
    {
        exeCmdStack = new Stack<ICommand>();
        undoCmdStack = new Stack<ICommand>();
    }

    public void ExecuteCmd(ICommand cmd)
    {
        try
        {
            cmd.Execute();
            undoCmdStack.Clear();
            exeCmdStack.Push(cmd);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }

    public void UndoCmd()
    {
        if (exeCmdStack.Count > 0)
        {
            var cmd = exeCmdStack.Pop();
            cmd.Undo();
            undoCmdStack.Push(cmd);
        }
    }

    public void RedoCmd()
    {
        if (undoCmdStack.Count > 0)
        {
            var cmd = undoCmdStack.Pop();
            cmd.Redo();
            exeCmdStack.Push(cmd);
        }
    }
}