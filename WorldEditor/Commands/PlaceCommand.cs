namespace WorldEditor;

public class PlaceCommand : ICommand
{
    private readonly Position newPos;
    private readonly Position oldPos;

    public PlaceCommand(int oldPosX, int oldPosY, int x, int y)
    {
        oldPos = new Position(oldPosX, oldPosY);
        newPos = new Position(x, y);
    }

    public void Execute()
    {
        EntityManager.GetInstance.MoveEntity(oldPos, newPos);
    }

    public void Undo()
    {
        EntityManager.GetInstance.MoveEntity(newPos, oldPos);
    }

    public void Redo()
    {
        Execute();
    }
}