using static System.ConsoleKey;

namespace Start;

public class Start : GameState
{
    private static void Main()
    {
        int MainMenu = SelectionTemplate("Welcome to TicTacToe",
            ["Start Game", "Rules (How do you not know this already??", "Exit"]);

        GameState board = new();
        
        if (MainMenu == 1)
        {
            PlayerTurn(board, 2);
        }
    }

    private static int SelectionTemplate(string title, List<string> options)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"-- {title} --");
            Console.WriteLine();

            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {options[i]}");
            }

            Console.Write("Please Select an option:");
            string? input = Console.ReadLine();
            if (!int.TryParse(input, out int result)) continue;
            if (result > options.Count || result <= 0) continue;

            return result;
        }
    }

    private static void StartGame()
    {
            
    }

    private static bool PlayerTurn(GameState board, int player)
    {
        int updatedX = 2;
        int updatedY = 2;

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Turn: Player {player}");
            Console.WriteLine();
            board.PrintBoardSelected(updatedX, updatedY);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Control the Selection with either arrow keys or [WASD] and confirm with [ENTER]");
            Console.WriteLine("Press [Backspace] to abort the game.");
            ConsoleKeyInfo key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.Enter:
                    if (board.ExecuteTurn(updatedX, updatedY, player) == false) continue;
                    return true;
                    break;
                case ConsoleKey.Backspace:
                    return false;
                    break;
                case ConsoleKey.W:
                    if (updatedX - 1 >= 0) updatedX--;
                    continue;
                case ConsoleKey.A:
                    if (updatedY - 1 >= 0) updatedY--;
                    continue;
                case ConsoleKey.S:
                    if (updatedX + 1 <= board.ReturnLengthRowMinus1()) updatedX++;
                    continue;
                case ConsoleKey.D:
                    if (updatedY + 1 <= board.ReturnLengthColMinus1()) updatedY++;
                    continue;
                case ConsoleKey.UpArrow:
                    if (updatedX - 1 > 0) updatedX--;
                    continue;
                case ConsoleKey.DownArrow:
                    if (updatedX + 1 != board.ReturnLengthRowMinus1()) updatedY++;
                    continue;
                case ConsoleKey.LeftArrow:
                    if (updatedY - 1 > 0) updatedY--;
                    continue;
                case ConsoleKey.RightArrow:
                    if (updatedY + 1 != board.ReturnLengthColMinus1()) updatedY++;
                    continue;
            }
        }
    }


    private static void Turn(GameState board, Player p)
    {
    }
}