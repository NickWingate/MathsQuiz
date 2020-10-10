using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace ConsoleUI
{
    public class Quiz
    {
        public char[] Operators { get; private set; } = { '+', '-', '*', '/' };
        public Dictionary<string, double> Questions { get; private set; } = new Dictionary<string, double>();
        public Quiz(int questionAmount, int maxOperandValue)
        {
            for (int i = 1; i < questionAmount + 1; i++)
            {
                (string question, double answer) = GenerateQuestion(maxOperandValue);
                Questions.Add($"{i}. {question}", answer);
            }
        }
        public int Length
        {
            get => Questions.Count(); 
            private set { }
        }

        public bool AskQuestion(int questionNumber)
        {
            Console.Write($"{Questions.ElementAt(questionNumber - 1).Key} = ");
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
                Console.Write($"{Questions.ElementAt(questionNumber - 1).Key} = ");
                rawInput = Console.ReadLine();
            }
            return verifiedInput;
        }

        private (string, double) GenerateQuestion(int maxOperandValue)
        {
            Random rnd = new Random();
            double answer;
            string question;
            /* 
             * This removes any questions with answers that are
             * too long for the user to viably answer
             * e.g. 1/3 (0.3333333333333) or 6/13 (0.46153846153)
             */
            do
            {
                double operand1 = rnd.Next(1, maxOperandValue + 1);
                double operand2 = rnd.Next(1, maxOperandValue + 1);
                char operator1 = Operators[rnd.Next(Operators.Count())];
                question = $"{operand1} {operator1} {operand2}";

                DataTable dt = new DataTable();
                answer = Convert.ToDouble(dt.Compute(question, ""));
            } while (Convert.ToString(answer).Length > Convert.ToString(maxOperandValue ^ 2 + 3).Length);
            return (question, answer);
        }
    }
}
