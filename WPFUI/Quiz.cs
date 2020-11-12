using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MathsQuiz
{
    public class Quiz
    {
        public double Percent
        {
            get { return (Convert.ToDouble(Score) / Convert.ToDouble(Length)) * 100d; }
            private set { }
        }

        public char Grade
        {
            get
            {
                if (Percent >= 90d) return 'A';
                else if (Percent >= 80d) return 'B';
                else if (Percent >= 70d) return 'C';
                else if (Percent >= 60d) return 'D';
                else if (Percent >= 50d) return 'E';
                else return 'F';
            }
        }

        public int Score { get; private set; }

        // Add any operators you want here
        public char[] Operators { get; private set; } = { '+', '-', '*', '/', '%' };
        public Dictionary<string, string> Questions { get; private set; } = new Dictionary<string, string>();

        public int Length
        {
            get => Questions.Count();
            private set { }
        }

        public Quiz(int questionAmount, int maxOperandValue)
        {
            for (int i = 1; i < questionAmount + 1; i++)
            {
                (string question, double answer) = GenerateQuestion(maxOperandValue, Questions.Keys.ToList());
                Questions.Add($"{question}", Convert.ToString(answer));
            }
        }


        private (string, double) GenerateQuestion(int maxOperandValue, List<string> preexistingQuestions)
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
            } while (Convert.ToString(answer).Length > Convert.ToString(maxOperandValue ^ 2 + 3).Length
                    || preexistingQuestions.Contains(question));
            return (question, answer);
        }
    }
}