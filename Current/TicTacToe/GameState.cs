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

    bool CheckVer(WinCon p1, WinCon p2)
    {
        int lfI = -1;

        foreach (int[] row in board)
        {
            for (int i = 0; i < row.Length; i++)
            {
                if (lfI != -1)
                {
                    if (row[lfI] == 1)
                    {
                        if (p1.WinAdd(1)) return true;
                    }

                    if (row[lfI] == 2)
                    {
                        if (p2.WinAdd(1)) return true;
                    }
                }

                if (i == lfI) continue;

                if (row[i] == 1)
                {
                    lfI = i;
                    if (p1.WinAdd(1)) return true;
                }

                if (row[i] == 2)
                {
                    lfI = i;
                    if (p2.WinAdd(1)) return true;
                }
            }
        }

        return false;
    }


    bool CheckHor(WinCon p1, WinCon p2)
    {
        foreach (int[] row in board)
        {
            for (int i = 0; i < row.Length; i++)
            {
                if (row[i] == 1)
                {
                    if (p1.WinAdd(2)) return true;
                }

                if (row[i] == 2)
                {
                    if (p2.WinAdd(2)) return true;
                }
            }
        }

        return false;
    }

    bool CheckDiag(WinCon p1, WinCon p2)
    {
        int dIndexer = 0;

        foreach (int[] row in board)
        {
            if (row[dIndexer] == 1)
            {
                if (p1.WinAdd(3)) return true;
            }

            if (row[dIndexer] == 2)
            {
                if (p2.WinAdd(3)) return true;
            }

            dIndexer++;
        }

        return false;
    }

    public void PrintBoard()
    {
        int retard = 1;
            
            foreach (int[] row in board)
            {
                string s;
                if (retard == 2 || retard == 3)
                {
                    Console.WriteLine("-----");
                } 
                
                s = $"{row[0]} {row[1]} {row[2]}";
                retard++;
                Console.WriteLine(s);
            }
        
    }
}