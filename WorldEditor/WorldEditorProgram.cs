namespace WorldEditor;

public class WorldEditorProgram
{
    private readonly HistoryManager historyManager;

    public WorldEditorProgram()
    {
        historyManager = new HistoryManager();
    }

    public void Run()
    {
        //Test examples
        historyManager.ExecuteCmd(new CreateCommand(eEntityType.GoblinLaboratory, 5, 3));
        historyManager.ExecuteCmd(new CreateCommand(eEntityType.GoldMine, 5, 3));
        historyManager.ExecuteCmd(new PlaceCommand(5, 3, 2, 1));
        historyManager.UndoCmd();
        historyManager.UndoCmd();
        historyManager.RedoCmd();
        historyManager.RedoCmd();
        historyManager.ExecuteCmd(new DeleteCommand(5, 3));
        historyManager.UndoCmd();
        historyManager.ExecuteCmd(new DeleteCommand(5, 3));
    }
}