using System.Security;

namespace Start;

public class Player
{
    private int _verticalWin;
    private int _horizontalWin;
    private int _diagonalWin ;
    
    public Player()
    {
        _verticalWin = 0;
        _horizontalWin = 0;
        _diagonalWin = 0;
    }

    public bool AddScore(int lane)
    {
        
        if (lane == 1)
        {
            _verticalWin += 1;
        }

        if (lane == 2)
        {
            _horizontalWin += 1;
        }

        if (lane == 3)
        {
            _diagonalWin += 1;
        }

        if (_verticalWin == 3 || _horizontalWin == 3 || _diagonalWin == 3)
        {
            return  true;
        }
        
        

        return false;
    }

    public void ResetScore()
    {
        _verticalWin = 0;
        _horizontalWin = 0;
        _diagonalWin = 0;
    }
    
}