using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ConsoleUI
{
    public class Quiz
    {
        public Dictionary<string, double> Questions { get; private set; } = new Dictionary<string, double>();
        public Quiz(int questionAmount)
        {
            for (int i = 1; i < questionAmount + 1; i++)
            {
                (string question, double answer) = GenerateQuestion(20);
                Questions.Add(question, answer);
            }
        }
        public int Length
        {
            get => Questions.Count(); 
            private set { }
        }

        public bool AskQuestion(int questionNumber)
        {
            Console.Write($"{questionNumber}. {Questions.ElementAt(questionNumber - 1).Key} = ");
            double userAnswer = ReadAndVerifyAnswer(questionNumber);
            if (userAnswer == Questions.ElementAt(questionNumber - 1).Value) return true;
            else return false;
        }

        // Designed for ConsoleUI, need to update for WPF
        private double ReadAndVerifyAnswer(int questionNumber)
        {
            string rawInput = Console.ReadLine();
            double verifiedInput;

            while (!Double.TryParse(rawInput, out verifiedInput))
            {
                Console.WriteLine("Invalid input, answer must real number(can't be scientific notaion)");
                Console.Write($"{questionNumber}. {Questions.ElementAt(questionNumber - 1).Key} = ");
                rawInput = Console.ReadLine();
            }
            return verifiedInput;
        }

        private (string, double) GenerateQuestion(int maxOperandValue)
        {
            char[] operators = { '+', '-', '*', '/'};
            Random rnd = new Random();

            double answer;
            double operand1 = rnd.Next(maxOperandValue + 1);
            double operand2 = rnd.Next(maxOperandValue + 1);
            char operator1 = operators[rnd.Next(3)];

            if (operator1 == '+') answer = operand1 + operand2;
            else if (operator1 == '-') answer = operand1 - operand2;
            else if (operator1 == '*') answer = operand1 * operand2;
            else answer = operand1 / operand2;

            return ($"{operand1} {operator1} {operand2}", answer);
        }
    }
}
