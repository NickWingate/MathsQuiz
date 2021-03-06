﻿using System;

namespace ConsoleUI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            do
            {
                Quiz q = new Quiz(GetQuizData("Amount of questions: "), GetQuizData("Max operand value: "));

                for (int i = 1; i <= q.Length; i++)
                {
                    q.AskQuestion(i);
                }
                Console.WriteLine($"You got {q.Score} / {q.Length} ({Math.Round(q.Percent, 1)}%), giving you a grade {q.Grade}");
            } while (QuizAgain());
            Console.WriteLine("Goodbye");
        }

        private static bool QuizAgain()
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

        private static int GetQuizData(string prompt)
        {
            Console.Write(prompt);
            string rawInput = Console.ReadLine();
            uint verifiedInput;

            while (!UInt32.TryParse(rawInput, out verifiedInput) || verifiedInput == 0)
            {
                Console.WriteLine("Must be positive integer");
                Console.Write(prompt);
                rawInput = Console.ReadLine();
            }
            return (int)verifiedInput;
        }
    }
}