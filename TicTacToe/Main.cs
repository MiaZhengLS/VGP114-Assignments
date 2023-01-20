namespace TicTacToe;

public class Program
{
    public static void Main()
    {
        /*
         * Test: Player X wins the game.
         */
        ITicTacToe ticTacToe1 = new TicTacToe(Player.O);
        ticTacToe1.Move(0, 0);
        ticTacToe1.Move(0, 1);
        ticTacToe1.Move(1, 0);
        ticTacToe1.Move(2, 0);
        ticTacToe1.Move(0, 2);
        ticTacToe1.Move(1, 1);
        ticTacToe1.Move(1, 2);
        ticTacToe1.Move(2, 1);
        
        /*
         * Test: Stalemate.
         */
        ITicTacToe ticTacToe2 = new TicTacToe(Player.X);
        ticTacToe2.Move(0, 0);
        ticTacToe2.Move(0, 1);
        ticTacToe2.Move(1, 0);
        ticTacToe2.Move(2, 0);
        ticTacToe2.Move(0, 2);
        ticTacToe2.Move(1, 1);
        ticTacToe2.Move(2, 1);
        ticTacToe2.Move(2, 2);
        ticTacToe2.Move(1, 2);
    }
}