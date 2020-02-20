using System;
using System.Collections.Generic;
public class Program
{
    static List<List<string>> board;
    public static void Main()
    {
        Console.WriteLine("Please enter an odd number between 2 and 10 000:");
        var number = ReadWidth();
        var dashes = "-";
        var stars = "*";

        board = new List<List<string>>();


        Func<int, int, bool> p1 = (row, col) => {
            int startX = number - 1 - row;
            return (col > startX && col <= (startX + number));
        };
        Func<int, int, bool> p2 = (row, col) => {
            int startX = number - 1 + row;
            return (col > startX && col <= (startX + number));
        };
        Func<int, int, bool> p3 = (row, col) => {
            int startX = (3 * number) - 1 - row;
            return (col > startX && col <= (startX + number));
        };
        Func<int, int, bool> p4 = (row, col) => {
            int startX = (3 * number) - 1 + row;
            return (col > startX && col <= (startX + number));
        };
        Func<int, int, bool> p5 = (row, col) => {
            int startX = (6 * number) - 1 - row;
            return (col > startX && col <= (startX + number));
        };
        Func<int, int, bool> p6 = (row, col) => {
            int startX = (6 * number) - 1 + row;
            return (col > startX && col <= (startX + number));
        };
        Func<int, int, bool> p7 = (row, col) => {
            int startX = (8 * number) - 1 - row;
            return (col > startX && col <= (startX + number));
        };
        Func<int, int, bool> p8 = (row, col) => {
            int startX = (8 * number) - 1 + row;
            return (col > startX && col <= (startX + number));
        };


        for (int row = 0; row <= number; row++)
        {
            var rowChars = new List<string>();
            for (int col = 0; col < (number * 10); col++)
            {
                rowChars.Add((p1(row, col) || p2(row, col) || p3(row, col) || p4(row, col) || p5(row, col) || p6(row, col) || p7(row, col) || p8(row, col)) ? stars : dashes);

            }
            board.Add(rowChars);
        }

        ShowOutput();
    }
    public static int ReadWidth()
    {
        
        var widthString = Console.ReadLine();
        int number = 0;
        if (!int.TryParse(widthString, out number) || number < 2 || number > 10000 || number % 2 == 0)
        {
            Console.WriteLine("The number you entered does not meet the requirements, please try again.");
            ReadWidth();
        }
        return number;
    }
    public static void ShowOutput()
    {
        var sb = new System.Text.StringBuilder();
        foreach (List<string> row in board)
            sb.AppendLine(string.Join("", row.ToArray()));

        Console.Write(sb.ToString());
    }
}