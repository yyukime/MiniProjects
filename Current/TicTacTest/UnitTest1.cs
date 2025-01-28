using System.Data;
using System.Reflection.Emit;
using Start;

namespace TicTacToeTest;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        int[][] board =
        [
            [0, 0, 1, 0],
            [0, 2, 0, 1],
            [1, 0, 1, 0],
            [0, 1, 0, 2]
        ];

        Player p1 = new Player();
        Player p2 = new Player();

        Enum ok = CheckDiag(board, p1, p2);
        Assert.Equal(GameState.Result.WinPlayer1, ok);
    }
    

    Enum CheckDiag(int[][] board, Player p1, Player p2)
    {
        
        for (int row = 0; row < board.Length; row++)
        {
            for (int col = 0; col < board[row].Length; col++)
            {
                if (board[row][col] == 1)
                {
                    if (p1.AddScore(3)) return GameState.Result.WinPlayer1;
                    if (BranchRight(col, row, board, p1, p2)) return GameState.Result.WinPlayer1;
                    if (BranchLeft(col, row, board, p1, p2)) return GameState.Result.WinPlayer1;
                }

                if (board[row][col] == 2)
                {
                    if (p2.AddScore(3)) return GameState.Result.WinPlayer2;
                    if (BranchRight(col, row, board, p1, p2)) return GameState.Result.WinPlayer2;
                    if (BranchLeft(col, row, board, p1, p2)) return GameState.Result.WinPlayer2;
                }
                
            }
        }


        return GameState.Result.NoResult;
    }


    bool BranchRight(int col, int row, int[][] board, Player p1, Player p2)
    {
        while (board[row][col] == 1 && row < board.Length - 2 && col < board[1].Length - 2)
        {
            col++;
            row++;

            if (board[row][col] == 1)
            {
                if (p1.AddScore(3)) return true;
            }
        }
        return false;
    }

    bool BranchLeft(int col, int row, int[][] board, Player p1, Player p2)
    {
        while (board[row][col] == 1 && row > 0 && col > 0)
        {
            col--;
            row--;

            if (board[row][col] == 1)
            {
                if (p1.AddScore(3)) return true;
            }
        }
        return false;
    }
}