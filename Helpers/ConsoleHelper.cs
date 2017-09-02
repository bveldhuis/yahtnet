using System;

namespace Yahtnet.Helpers
{
    public static class ConsoleHelper
    {
        public static string ToPointsString(this int? points)
        {
            if (points == null)
            {
                return "   ";
            }
            if (points == 0)
            {
                return "  X";
            }
            return ToPointsString(points.Value);
        }

        public static string ToPointsString(this int points)
        {
            return points.ToString().PadLeft(3, ' ');
        }

        public static string GetDiceSpriteRow(this int diceValue, int rowNumber)
        {
            switch (rowNumber)
            {
                case 0:
                    return "┌─────┐";
                case 1:
                    return $"|{(diceValue >1 ? "0" : " ")}   {(diceValue >3 ? "0" : " ")}|";
                case 2:
                    return $"|{(diceValue ==6 ? "0" : " ")} {(diceValue%2==1 ? "0" : " ")} {(diceValue ==6 ? "0" : " ")}|";
                case 3:
                    return $"|{(diceValue >3 ? "0" : " ")}   {(diceValue >1 ? "0" : " ")}|";
                case 4:
                    return "└─────┘";
                default: 
                    throw new InvalidOperationException($"RowNumber {rowNumber} is not available");
            }
        }
    }
}