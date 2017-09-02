using System;
using Yahtnet.Models;
using Yahtnet.Helpers;
using System.Linq;

namespace Yahtnet
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.Unicode;

            var game = new Game();

            while (!game.GameEnded)
            {
                DrawScreen(game);
                if (game.CanRethrow) 
                {
                    WaitForKeyPress(game);
                }
                else 
                {
                    game.EndRound();
                    DrawScreen(game);
                    Console.WriteLine("I've entered the highest possible score for you.");
                    Console.WriteLine("Press any key to continue to the next round");
                    Console.ReadKey();
                    game.Throw();
                }
            }
        }

        private static void WaitForKeyPress(Game game)
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("- Press T to rethrow all dices");
            Console.WriteLine("- Press K to keep some dice(s) and rethrow the rest");
            Console.WriteLine("- Press W to write down this score");

            var supportedKeys = new [] {
                ConsoleKey.T,
                ConsoleKey.K,
                ConsoleKey.W,
            };
            
            var keyinfo = new ConsoleKeyInfo();
            while (!supportedKeys.Contains(keyinfo.Key))
            {
                keyinfo = Console.ReadKey();                
            }

            switch (keyinfo.Key)
            {
                case ConsoleKey.T:
                    foreach (var dice in game.Dices)
                    {
                        game.AddDiceToThrowingBucket(dice);
                    }
                    game.Throw();
                    break;
                case ConsoleKey.K:
                    Console.WriteLine();
                    Console.WriteLine("Press the numbers of the dice you want to rethrow and confirm with <ENTER>");
                    var numberKeyinfo = new ConsoleKeyInfo();
                    while (numberKeyinfo.Key != ConsoleKey.Enter)
                    {
                        numberKeyinfo = Console.ReadKey();
                        switch (numberKeyinfo.Key)
                        {
                            case ConsoleKey.D1:
                            case ConsoleKey.NumPad1:
                                game.AddDiceToThrowingBucket(game.Dices[0]);
                                break;
                            case ConsoleKey.D2:
                            case ConsoleKey.NumPad2:
                                game.AddDiceToThrowingBucket(game.Dices[1]);
                                break;
                            case ConsoleKey.D3:
                            case ConsoleKey.NumPad3:
                                game.AddDiceToThrowingBucket(game.Dices[2]);
                                break;
                            case ConsoleKey.D4:
                            case ConsoleKey.NumPad4:
                                game.AddDiceToThrowingBucket(game.Dices[3]);
                                break;
                            case ConsoleKey.D5:
                            case ConsoleKey.NumPad5:
                                game.AddDiceToThrowingBucket(game.Dices[4]);
                                break;
                        }
                    }
                    game.Throw();
                    break;
                case ConsoleKey.W:
                    game.EndRound();
                    DrawScreen(game);
                    Console.WriteLine("I've entered the highest possible score for you.");
                    Console.WriteLine("Press any key to continue to the next round");
                    Console.ReadKey();
                    game.Throw();
                    break;
            }
        }

        private static void DrawScreen(Game game)
        {
            Console.Clear();
            Console.WriteLine("============================================x============================================");
            Console.WriteLine("==                                                                                     ==");
            Console.WriteLine("==                                       YahtNet                                       ==");
            Console.WriteLine("==                                                                                     ==");
            Console.WriteLine("============================================x============================================");
            Console.WriteLine();
            Console.WriteLine( "╔═ Score Board ═════════╤═══════════════════════╗");
            Console.WriteLine($"║ Ones:             {game.ScoreBoard.GetPoints(ScoreType.Ones).ToPointsString()} │ Three of a kind:  {game.ScoreBoard.GetPoints(ScoreType.ThreeOfAKind).ToPointsString()} ║");
            Console.WriteLine($"║ Twos:             {game.ScoreBoard.GetPoints(ScoreType.Twos).ToPointsString()} │ Four of a kind:   {game.ScoreBoard.GetPoints(ScoreType.FourOfAKind).ToPointsString()} ║");
            Console.WriteLine($"║ Threes:           {game.ScoreBoard.GetPoints(ScoreType.Threes).ToPointsString()} │ Full house:       {game.ScoreBoard.GetPoints(ScoreType.FullHouse).ToPointsString()} ║");
            Console.WriteLine($"║ Fours:            {game.ScoreBoard.GetPoints(ScoreType.Fours).ToPointsString()} │ Small street:     {game.ScoreBoard.GetPoints(ScoreType.SmallStreet).ToPointsString()} ║");
            Console.WriteLine($"║ Fives:            {game.ScoreBoard.GetPoints(ScoreType.Fives).ToPointsString()} │ Large street:     {game.ScoreBoard.GetPoints(ScoreType.LargeStreet).ToPointsString()} ║");
            Console.WriteLine($"║ Sixes:            {game.ScoreBoard.GetPoints(ScoreType.Sixes).ToPointsString()} │ YahtNet:          {game.ScoreBoard.GetPoints(ScoreType.Yahtnet).ToPointsString()} ║");
            Console.WriteLine($"║ Bonus:            {game.ScoreBoard.GetBonusPoints().ToPointsString()} │ Chance:           {game.ScoreBoard.GetPoints(ScoreType.Chance).ToPointsString()} ║");
            Console.WriteLine($"║ Sub total left:   {game.ScoreBoard.GetTopHalfSubScore().ToPointsString()} │ Sub total right:  {game.ScoreBoard.GetLowerHalfSubScore().ToPointsString()} ║");
            Console.WriteLine($"║                       │ Sub total left:   {game.ScoreBoard.GetTopHalfSubScore().ToPointsString()} ║");
            Console.WriteLine($"║                       │ Total score:      {game.ScoreBoard.GetTotalScore().ToPointsString()} ║");
            Console.WriteLine( "╚═══════════════════════╧═══════════════════════╝");
            Console.WriteLine();
            
            for (var i = -1; i < 5; i++) 
            {
                Console.Write("  ");
                var j = 1;
                foreach (var dice in game.Dices)
                {
                    if (i < 0)
                    {
                        
                        Console.Write($"    {j++}    ");
                    }
                    else
                    {
                        Console.Write($" {dice.GetValue().GetDiceSpriteRow(i)} ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
