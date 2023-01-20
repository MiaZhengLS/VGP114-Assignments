namespace TicTacToe;

public class TicTacToe : ITicTacToe
{
    private const int ROW_NUM = 3;
    private const int COL_NUM = 3;
    private const int WIN_NUM = 3;
    private readonly Player[][] board;
    private Player currentPlayer;
    private bool isGameOver;
    private Player winner;

    public TicTacToe(Player firstPlayer)
    {
        if (firstPlayer == Player.None)
        {
            throw new ArgumentException("first player should be either X or O.");
        }
        board = new Player[ROW_NUM][];
        for (var i = 0; i < ROW_NUM; ++i) board[i] = new Player[COL_NUM];
        currentPlayer = firstPlayer;
        isGameOver = false;
        winner = Player.None;
    }

    public void Move(int r, int c)
    {
        if (isGameOver)
        {
            Console.WriteLine("Game is over! Move is invalid.");
            return;
        }

        if (!checkValidPos(r, ROW_NUM) || !checkValidPos(c, COL_NUM))
        {
            Console.WriteLine($"({r},{c})invalid pos.");
            return;
        }
        Console.WriteLine($"Current player is {currentPlayer}");
        board[r][c] = currentPlayer;
        CheckGameStatus();
        if (!isGameOver)
            switchPlayer();
        else
            currentPlayer = Player.None;
    }


    public Player GetTurn()
    {
        return currentPlayer;
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public Player GetWinner()
    {
        return winner;
    }

    public Player[][] GetBoard()
    {
        var ret = new Player[ROW_NUM][];
        for (var i = 0; i < ROW_NUM; ++i) ret[i] = new Player[COL_NUM];

        for (var i = 0; i < ROW_NUM; ++i)
        for (var j = 0; j < COL_NUM; j++)
            ret[i][j] = board[i][j];

        return ret;
    }

    public Player GetMarkAt(int r, int c)
    {
        if (!checkValidPos(r, ROW_NUM) || !checkValidPos(c, COL_NUM))
        {
            Console.WriteLine($"({r},{c})invalid pos.");
            return Player.None;
        }

        return board[r][c];
    }

    private void switchPlayer()
    {
        if (currentPlayer == Player.O)
            currentPlayer = Player.X;
        else
            currentPlayer = Player.O;
    }

    private void CheckGameStatus()
    {
        var hasEmptySlot = false;
        for (var i = 0; i < ROW_NUM; ++i)
        for (var j = 0; j < COL_NUM; ++j)
        {
            var curCheckPlayer = board[i][j];
            if (curCheckPlayer == Player.None)
            {
                hasEmptySlot = true;
                continue;
            }

            var win = false;
            int passedNum;
            int k;
            //check col
            passedNum = 1;
            k = 1;
            while (j + k < COL_NUM)
            {
                if (board[i][j + k] == curCheckPlayer)
                {
                    passedNum++;
                    k++;
                }
                else
                {
                    break;
                }

                if (passedNum == WIN_NUM)
                {
                    win = true;
                    break;
                }
            }

            if (win)
            {
                isGameOver = true;
                winner = curCheckPlayer;
                return;
            }

            //check row
            passedNum = 1;
            k = 1;
            while (i + k < ROW_NUM)
            {
                if (board[i + k][j] == curCheckPlayer)
                {
                    passedNum++;
                    k++;
                }
                else
                {
                    break;
                }

                if (passedNum == WIN_NUM)
                {
                    win = true;
                    break;
                }
            }

            if (win)
            {
                isGameOver = true;
                winner = curCheckPlayer;
                return;
            }

            //check diagonal
            passedNum = 1;
            k = 1;
            while (i + k < ROW_NUM && j + k < COL_NUM)
            {
                if (board[i + k][j + k] == curCheckPlayer)
                {
                    passedNum++;
                    k++;
                }
                else
                {
                    break;
                }

                if (passedNum == WIN_NUM)
                {
                    win = true;
                    break;
                }
            }

            if (win)
            {
                isGameOver = true;
                winner = curCheckPlayer;
                return;
            }

            //check back-diagonal
            passedNum = 1;
            k = 1;
            while (i + k < ROW_NUM && j - k >= 0)
            {
                if (board[i + k][j - k] == curCheckPlayer)
                {
                    passedNum++;
                    k++;
                }
                else
                {
                    break;
                }

                if (passedNum == WIN_NUM)
                {
                    win = true;
                    break;
                }
            }

            if (win)
            {
                isGameOver = true;
                winner = curCheckPlayer;
                return;
            }
        }

        if (!hasEmptySlot) isGameOver = true;
    }

    private bool checkValidPos(int pos, int maxNum)
    {
        return pos >= 0 && pos < maxNum;
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