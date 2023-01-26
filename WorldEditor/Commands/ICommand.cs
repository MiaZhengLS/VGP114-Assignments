namespace WorldEditor;

public interface ICommand
{
    void Execute();
    void Undo();
    void Redo();
}