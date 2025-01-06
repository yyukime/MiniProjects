namespace Start;

public class GameState
{
    int[][] _board;

    public GameState()
    {
        _board =
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
            foreach (int[] row in _board)
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
        } while (col < _board.Length);

        return GameState.Result.NoResult;
    }


    Enum CheckHor(PlayerScore p1, PlayerScore p2)
    {
        foreach (int[] row in _board)
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
        for (int row = 0; row < _board.Length; row++)
        {
            for (int col = 0; col < _board[row].Length; col++)
            {
                if (_board[row][col] == 1)
                {
                    if (p1.AddScore(3)) return GameState.Result.WinPlayer1;
                    if (BranchRight(col, row, p1, p2)) return GameState.Result.WinPlayer1;
                    if (BranchLeft(col, row, p1, p2)) return GameState.Result.WinPlayer1;
                }

                if (_board[row][col] == 2)
                {
                    if (p2.AddScore(3)) return GameState.Result.WinPlayer2;
                    if (BranchRight(col, row, p1, p2)) return GameState.Result.WinPlayer2;
                    if (BranchLeft(col, row, p1, p2)) return GameState.Result.WinPlayer2;
                }
            }
        }


        return GameState.Result.NoResult;
    }


    bool BranchRight(int col, int row, PlayerScore p1, PlayerScore p2)
    {
        while (_board[row][col] == 1 && row < _board.Length - 2 && col < _board[1].Length - 2)
        {
            col++;
            row++;

            if (_board[row][col] == 1)
            {
                if (p1.AddScore(3)) return true;
            }
        }

        return false;
    }

    bool BranchLeft(int col, int row, PlayerScore p1, PlayerScore p2)
    {
        while (_board[row][col] == 1 && row > 0 && col > 0)
        {
            col--;
            row--;

            if (_board[row][col] == 1)
            {
                if (p1.AddScore(3)) return true;
            }
        }

        return false;
    }

    public static void PrintBoard(int[][] board)
    {
        foreach (int[] row in board)
        {
            foreach (int col in row)
            {
                if (col == 1)
                {
                    Console.Write("X" + " " + " ");
                }

                if (col == 2)
                {
                    Console.Write("O" + " " + " ");
                }

                if (col == 0)
                {
                    Console.Write("-" + " " + " ");
                }   
            }

            Console.WriteLine();
        }
    }

    

    public enum Result
    {
        NoResult,
        WinPlayer1,
        WinPlayer2,
    }
}