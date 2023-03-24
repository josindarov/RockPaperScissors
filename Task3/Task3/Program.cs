using System;
using System.Linq;
using Task3;

public class Program
{
    static void Main(string[] args)
    {
        int userMove;
        string computerMove = "", myMove;
        Table table = new();
        int indexComputer = 0;
        
        if(args.Length < 3)
            Console.WriteLine("Minimum length of arguments should be 3");
        else if (args.Length % 2 == 0)
            Console.WriteLine("Number of your arguments should be odd");
        else if (args.Distinct().Count() != args.Count())
            Console.WriteLine("Your arguments should not be repeated");
        else
        {
            Hash hash = new();
            int indexOfComputer = new Random().Next(args.Length);
            computerMove = args[indexOfComputer];
            string hmacMove = hash.ComputeHMAC(computerMove);
            indexComputer = indexOfComputer;
            Console.WriteLine("HMAC : " + hmacMove);
            while (true)
            {
                Menu(args);
                Console.Write("What's your move: ");
                myMove = Console.ReadLine();
                if (myMove == "?" || int.Parse(myMove) <= args.Length)
                    break;
            }

            if (myMove == "?")
            {
                Console.WriteLine("This is a table");
                table.ShowTable(args);
            }
            
            else if(myMove == "0")
                Console.WriteLine("Thanks for your game");
            else
            {
                Console.WriteLine("Your move: " + args[int.Parse(myMove)-1]);
                Console.WriteLine("Computer move: " + computerMove);
                FindWinner(args, int.Parse(myMove)-1,indexComputer);
                string keyHmac = hash.GetOriginalKey();
                Console.WriteLine("HMAC Key: " + keyHmac);
            }
        }
    }
    

    static void Menu(string[] args)
    {
        Console.WriteLine("Available moves:");
        for (int i = 1; i <= args.Length; i++)
        {
            Console.WriteLine(i + "-" + args[i-1]);
        }
        
        Console.WriteLine("0 - exit");
        Console.WriteLine("? - help");      
    }

    static void FindWinner(string[] args,int myMove, int computerMove)
    {
        int result, averageLength;
        averageLength = (args.Length - 1) / 2;
        if(myMove == computerMove)
            Console.WriteLine("Game over with draw");
        
        else if (myMove > computerMove)
        {
            result = computerMove + averageLength;
            if (result >= myMove)
                Console.WriteLine("Computer is Winner");
            else
                Console.WriteLine("User is winner");
        }
        else
        {
            result = myMove + averageLength;
            if (computerMove <= result)
                Console.WriteLine("User is Winner");
            else
                Console.WriteLine("Computer is winner");
        }

    }
}
