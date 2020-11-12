using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace MathsQuiz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Quiz q { get; set; } = new Quiz(5, 10);
        public MainWindow()
        {
            InitializeComponent();
            SetQuestions();
        }
        private void SetQuestions()
        {
            lbQuestionOne.Content = q.Questions.ElementAt(0).Key;
            lbQuestionTwo.Content = q.Questions.ElementAt(1).Key;
            lbQuestionThree.Content = q.Questions.ElementAt(2).Key;
            lbQuestionFour.Content = q.Questions.ElementAt(3).Key;
            lbQuestionFive.Content = q.Questions.ElementAt(4).Key;
        }

        private void MarkAnswersButton_Click(object sender, RoutedEventArgs e)
        {
            int totalScore = 0;
            if (questionOneAnswer.Text == q.Questions.ElementAt(0).Value) { totalScore++; }
            if (questionTwoAnswer.Text == q.Questions.ElementAt(1).Value) { totalScore++; }
            if (questionThreeAnswer.Text == q.Questions.ElementAt(2).Value) { totalScore++; }
            if (questionFourAnswer.Text == q.Questions.ElementAt(3).Value) { totalScore++; }
            if (questionFiveAnswer.Text == q.Questions.ElementAt(4).Value) { totalScore++; }
            MessageBox.Show($"{totalScore} of {q.Length}");
        }
    }
}