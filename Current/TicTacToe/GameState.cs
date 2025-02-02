namespace Start;

public class GameState
{
    private int[][] _board;

    public GameState()
    {
        _board =
        [
            [0, 0, 0],
            [0, 0, 0],
            [0, 0, 0]
        ];
    }

    private Enum CheckVer(Player p1, Player p2)
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

    private Enum CheckHor(Player p1, Player p2)
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

    private Enum CheckDiag(Player p1, Player p2)
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


    bool BranchRight(int col, int row, Player p1, Player p2)
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

    bool BranchLeft(int col, int row, Player p1, Player p2)
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

    public void PrintBoardSelected(int? rowx, int? coly)
    {
        if (rowx != null && coly != null)
        {
            for (int row = 0; row < _board.Length; row++)
            {
                if (row == rowx)
                {
                    for (int col = 0; col < _board[row].Length; col++)
                    {
                        if (col == coly)
                        {
                            if (col == 0)
                            {
                                if (_board[row][col] == 1)
                                {
                                    Console.Write("(1)" + " ");
                                }

                                if (_board[row][col] == 2)
                                {
                                    Console.Write("(2)" + " ");
                                }

                                if (_board[row][col] == 0)
                                {
                                    Console.Write("(O)" + " ");
                                }
                            }

                            if (col > 0 && col < _board[row].Length - 1)
                            {
                                if (_board[row][col] == 1)
                                {
                                    Console.Write("(1)" + " ");
                                }

                                if (_board[row][col] == 2)
                                {
                                    Console.Write("(2)" + " ");
                                }

                                if (_board[row][col] == 0)
                                {
                                    Console.Write("(O)" + " " );
                                }
                            }

                            if (col == _board[0].Length - 1)
                            {
                                if (_board[row][col] == 1)
                                {
                                    Console.Write("(1)" + " ");
                                }

                                if (_board[row][col] == 2)
                                {
                                    Console.Write("(2)" + " ");
                                }

                                if (_board[row][col] == 0)
                                {
                                    Console.Write("(O)" + " " );
                                }
                            }

                        }
                        else
                        {
                            if (_board[row][col] == 1)
                            {
                                Console.Write(" " + "1" + " " + " ");
                            }

                            if (_board[row][col] == 2)
                            {
                                Console.Write(" " + "2" + " " + " ");
                            }

                            if (_board[row][col] == 0)
                            {
                                Console.Write(" " + "O" + " " + " ");
                            }
                        }

                       
                    }
                    Console.WriteLine();
                }
                else
                {
                    for (int col = 0; col < _board[row].Length; col++)
                    {
                        if (_board[row][col] == 1)
                        {
                            Console.Write(" " + "1" + " " + " ");
                        }

                        if (_board[row][col] == 2)
                        {
                            Console.Write(" " + "2" + " " + " ");
                        }

                        if (_board[row][col] == 0)
                        {
                            Console.Write(" " + "O" + " " + " ");
                        }
                    }

                    Console.WriteLine();
                }
            }
        }
        else
        {
            for (int row = 0; row < _board.Length; row++)
            {
                for (int col = 0; col < _board[row].Length; col++)
                {
                    if (_board[row][col] == 1)
                    {
                        Console.Write(" " + "1" + " " + " ");
                    }

                    if (_board[row][col] == 2)
                    {
                        Console.Write(" " + "2" + " " + " ");
                    }

                    if (_board[row][col] == 0)
                    {
                        Console.Write(" " + "O" + " " + " ");
                    }
                }

                Console.WriteLine();
            }
        }
    }

    void PrintBoard()
    {
        foreach (int[] row in _board)
        {
            foreach (int col in row)
            {
                if (col == 1)
                {
                    Console.Write(" " + "X" + " " + " ");
                }

                if (col == 2)
                {
                    Console.Write(" " + "O" + " " + " ");
                }

                if (col == 0)
                {
                    Console.Write(" " + "-" + " " + " ");
                }
            }
        }
    }


    public bool ExecuteTurn(int row, int col, int value)
    {
        if (row > _board.Length - 1 && col > _board[0].Length - 1) return false;
        if (_board[row][col] != 0) return false;
        _board[row][col] = value;
        return true;
    }

    public int ReturnLengthRowMinus1()
    {
        return _board.Length - 1;
    }

    public int ReturnLengthColMinus1()
    {
        return _board[0].Length - 1;
    }

    public bool AllChecks(Player p1, Player p2)
    {
        if (CheckDiag(p1, p1) != (Enum)Result.NoResult) return true;
        if (CheckHor(p1, p2) != (Enum)Result.NoResult) return true;
        if (CheckVer(p1, p2) != (Enum)Result.NoResult) return true;
        return false;
    }
    
     

    public enum Result
    {
        NoResult,
        WinPlayer1,
        WinPlayer2,
    }
}