using System;
using System.Net;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                int score = 0;
                Quiz q = new Quiz(GetQuestionAmount());

                for (int i = 1; i <= q.Length; i++)
                {
                    bool correct = q.AskQuestion(i);
                    score += correct ? 1 : 0;
                }
                Console.WriteLine($"You got {score} / {q.Length}");
            } while (QuizAgain());
            Console.WriteLine("Goodbye");
        }
        
        static bool QuizAgain()
        {
            string response;
            do
            {
                Console.WriteLine("New Quiz?(y/n)");
                response = Console.ReadLine().ToLower();
            } while (response != "y" && response != "n");

            if (response == "y") return true;
            else return false;
        }
        static int GetQuestionAmount()
        {
            Console.Write("How many question on your quiz? ");
            string rawInput = Console.ReadLine();
            uint verifiedInput;

            while (!UInt32.TryParse(rawInput, out verifiedInput))
            {
                Console.WriteLine("Must be positive integer");
                Console.Write("How many question on your quiz? ");
                rawInput = Console.ReadLine();
            }
            return (int)verifiedInput;
        }
    }
}
