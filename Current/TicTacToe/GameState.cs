namespace Start;

public class GameState
{
    int[][] board;

    public GameState()
    {
        board =
        [
            [0, 0, 0],
            [0, 0, 0],
            [0, 0, 0]
        ];
    }

    public Enum CheckVer(PlayerScore p1, PlayerScore p2)
    {
        int col = 0;

        do
        {
            foreach (int[] row in board)
            {
                
                if (row[col] == 1)
                {
                    if (p1.AddScore(1)) return GameState.Result.WinPlayer1;
                }

                if (row[col] == 2)
                {
                    if (p2.AddScore(2)) return GameState.Result.WinPlayer2;
                }
            }

            col += 1;
            p1.ResetScore();
            p2.ResetScore();
            
        }
        while (col < board.Length);

        return GameState.Result.NoResult;
    }


    Enum CheckHor(PlayerScore p1, PlayerScore p2)
    {
        foreach (int[] row in board)
        {
            
            foreach (int col in row)
            {
                if (col == 1)
                {
                    if (p1.AddScore(1)) return GameState.Result.WinPlayer1;
                }

                if (col == 2)
                {
                    if (p2.AddScore(2)) return GameState.Result.WinPlayer2;
                }
            }
            p1.ResetScore();
            p2.ResetScore();
        }
        return GameState.Result.NoResult;
    }

    Enum CheckDiag(PlayerScore p1, PlayerScore p2)
    {
        int dIndexer = 0;

        foreach (int[] row in board)
        {
            if (row[dIndexer] == 1)
            {
                if (p1.AddScore(3)) return Result.WinPlayer1;
            }

            if (row[dIndexer] == 2)
            {
                if (p2.AddScore(3)) return Result.WinPlayer2;
            }

            dIndexer++;
        }

        return Result.NoResult;
    }

    public static void PrintBoard()
    {
        
    }
    
    public enum Result
    {
        NoResult,
        WinPlayer1,
        WinPlayer2,
    }

      
}