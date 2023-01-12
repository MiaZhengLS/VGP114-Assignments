namespace TicTacToe;

public class TicTacToe : ITicTacToe
{
    public void Move(int r, int c)
    {
        throw new NotImplementedException();
    }

    public Player GetTurn()
    {
        throw new NotImplementedException();
    }

    public bool IsGameOver()
    {
        throw new NotImplementedException();
    }

    public Player GetWinner()
    {
        throw new NotImplementedException();
    }

    public Player[][] GetBoard()
    {
        throw new NotImplementedException();
    }

    public Player GetMarkAt(int r, int c)
    {
        throw new NotImplementedException();
    }

    // add your implementation here
    public override string ToString()
    {
        var rows = new List<string>();
        foreach (var row in GetBoard())
        {
            var rowStrings = new List<string>();
            foreach (var p in row)
                if (p == Player.None)
                    rowStrings.Add(" ");
                else
                    rowStrings.Add(p.ToString());
            rows.Add(" " + string.Join(" | ", rowStrings));
        }

        return string.Join("\n-----------\n", rows);
    }
}