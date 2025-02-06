using System.ComponentModel;
using System.Diagnostics;

namespace Start;

public class Start : GameState
{
    private static void Main()
    {
        while (true)
        {
            Console.Clear();
            int mainMenu = SelectionTemplate("Welcome to TicTacToe",
                ["Start Game", "Rules (How do you not know this already??", "Exit"]);
            
            if (mainMenu == 1)
            {
                Enum result = StartGame();
                
                switch (result)
                {
                    case GameResult.Win1:
                        if (GameResultTemplate("has a Winner!!", "Player1 (X)")) continue;
                        return;
                    case GameResult.Win2:
                        if (GameResultTemplate("has a Winner!!", "Player2 (O)")) continue;
                        return;
                    case GameResult.Tie:
                        if (GameResultTemplate("is a Tie!!", "no one!")) continue;
                        return;
                    case GameResult.Backspace:
                        continue;
                }
            }
            
            if (mainMenu == 2)
            {
                Console.Clear();
                Console.WriteLine("you are weird!!");
            }
            break;
        }
    }


    private static bool GameResultTemplate(string formattedResult, string who)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($" >> The game {formattedResult} <<");
            Console.WriteLine($" >> Congratulations to {who}");
            Console.WriteLine();
            Console.Write("Do you want to play again? (y/n): ");
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) continue;
            if (input.Equals("y", StringComparison.CurrentCultureIgnoreCase)) return true;
            if (input.Equals("n", StringComparison.CurrentCultureIgnoreCase)) return false;
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

    private static Enum StartGame()
    {
        Console.Clear();
        GameState board = new();
        Player player1 = new();
        Player player2 = new();
        int rCount = 0;

        while (true)
        {
            bool selTurn1 = PlayerTurn(board, player1, 1);
            if (!selTurn1) return GameResult.Backspace;
            if (board.AllChecks(player1, player2)) return GameResult.Win1;
            rCount++;
            if (rCount == 9) break;
            bool selTurn2 = PlayerTurn(board, player2, 2);
            if (!selTurn2) return GameResult.Backspace;
            if (board.AllChecks(player1, player2)) return GameResult.Win2;
            rCount++;
        }

        return GameResult.Tie;
    }

    private static bool PlayerTurn(GameState board, Player player, int playerNumber)
    {
        int updatedX = 2;
        int updatedY = 2;

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Turn: Player {playerNumber}");
            board.PrintBoardSelected(updatedX, updatedY);

            Console.WriteLine("Control the Selection with either arrow keys or [WASD] and confirm with [ENTER]");
            Console.WriteLine("Press [Backspace] to abort the game.");
            ConsoleKeyInfo key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.Enter:
                    if (!board.ExecuteTurn(updatedX, updatedY, playerNumber)) continue;
                    board.PrintBoardSelected(updatedX, updatedY);
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

    private enum GameResult
    {
        Win1,
        Win2,
        Tie,
        Backspace,
    }


    private static void Turn(GameState board, Player p)
    {
    }
}