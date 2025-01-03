namespace Start;

public class Start : GameState
{
    private static void Main()
    {
        GameState n = new();
        n.PrintBoard();

    }

    private void DisplayBoard(GameState gameState)
    {
        
        
        Console.WriteLine();
        Console.WriteLine();
    }

}