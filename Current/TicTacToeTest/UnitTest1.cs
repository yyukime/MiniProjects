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
            [1, 0, 0],
            [0, 1, 0],
            [0, 0, 1]
        ];

        PlayerScore p1 = new PlayerScore();
        PlayerScore p2 = new PlayerScore();

        Enum ok = CheckDiag(board, p1, p2);
        Assert.Equal(GameState.Result.NoResult, ok);
    }

    Enum CheckDiag(int[][] board, PlayerScore p1, PlayerScore p2)
    {
        for (int row = 0; row < board.Length; row++)
        {
            for (int col = 0; col < board[row].Length; col++)
            {
                if (board[row][col] == 1)
                {
                    if (p1.AddScore(1)) return GameState.Result.WinPlayer1;
                    if (BranchCheckerRight(col, row, board, p1, p2)) return GameState.Result.WinPlayer1;

                }
            }
        }
        
        
        
        return GameState.Result.NoResult;
    }


    bool BranchCheckerRight(int col, int row, int[][] board, PlayerScore p1, PlayerScore p2)
    {
        do
        {
            col++;
            row++;
            
            if (board[row][col] == 1)
            {
                if (p1.AddScore(3)) return true;
            }
        } 
        while (board[row][col] == 1 && row < board.Length - 1 && row < board[1].Length - 1);
        return false;
    }
}
