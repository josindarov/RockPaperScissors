using System;

namespace Task3;

public class Table
{
    public void ShowTable(string[] args)
    {
        Console.Write("Player: ");
        foreach (var arg in args)
            Console.Write("  " + arg);
        
        Console.WriteLine();
        for (int i = 0; i < args.Length; i++)
        {
            Console.Write(args[i] + ": ");
            for (int j = 0; j < args.Length; j++)
            {
                FindWinner(args, i, j);
            }

            Console.WriteLine();
        }
        
    }

    static void FindWinner(string[] args,int myMove, int computerMove)
    {
        int result, averageLength;
        averageLength = (args.Length - 1) / 2;
        if(myMove == computerMove)
            Console.Write("  Draw  ");
        
        else if (myMove > computerMove)
        {
            result = computerMove + averageLength;
            if (result >= myMove)
                Console.Write("  Lose  ");
            else
                Console.Write("  Winner  ");
        }
        else
        {
            result = myMove + averageLength;
            if (computerMove <= result)
                Console.Write("  Winner  ");
            else
                Console.Write("  Lose  ");
        }

    }
}