using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace MathsQuiz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Quiz q { get; set; } = new Quiz(20, 10);
        public List<TextBox> QuizQuestionList { get; set; } = new List<TextBox>();
        public MainWindow()
        {
            InitializeComponent();
            DefineQuizGrid();
            SetQuestions();
        }
        private void SetQuestions()
        {
            //lbQuestionOne.Content = q.Questions.ElementAt(0).Key;
            //lbQuestionTwo.Content = q.Questions.ElementAt(1).Key;
            //lbQuestionThree.Content = q.Questions.ElementAt(2).Key;
            //lbQuestionFour.Content = q.Questions.ElementAt(3).Key;
            //lbQuestionFive.Content = q.Questions.ElementAt(4).Key;
        }
        private void DefineQuizGrid()
        {
            for (int i = 0; i < q.QuestionAmount; i++)
            {
                Grid questionGrid = new Grid();
                questionGrid.ColumnDefinitions.Add(new ColumnDefinition 
                { 
                    Width = GridLength.Auto,
                    MinWidth = 70
                });
                questionGrid.ColumnDefinitions.Add(new ColumnDefinition());
                questionGrid.ColumnDefinitions.Add(new ColumnDefinition());

                Label questionNumber = new Label
                {
                    Content = $"{i + 1})",
                    Margin = new Thickness(0, 0, 40, 0),
                    FontWeight = FontWeights.Bold,
                    Foreground = new SolidColorBrush(Colors.SlateGray),
                };
                questionNumber.SetValue(Grid.ColumnProperty, 0);

                Label questionContent = new Label
                {
                    Content = q.Questions.ElementAt(i).Key,
                    FontWeight = FontWeights.Bold,
                    Foreground = new SolidColorBrush(Colors.Black)
                };
                questionContent.SetValue(Grid.ColumnProperty, 1);

                TextBox answerBox = new TextBox();
                QuizQuestionList.Add(answerBox);

                answerBox.SetValue(Grid.ColumnProperty, 2);

                questionGrid.Children.Add(answerBox);
                questionGrid.Children.Add(questionNumber);
                questionGrid.Children.Add(questionContent);
                QuestionStack.Children.Add(questionGrid);
            }
        }
        private void MarkAnswersButton_Click(object sender, RoutedEventArgs e)
        {
            q.Score = 0;
            for (int i = 0; i < q.QuestionAmount; i++)
            {
                if (QuizQuestionList[i].Text == q.Questions.ElementAt(i).Value)
                {
                    q.Score++;
                }
            }
            //int totalScore = 0;
            //int totalScore = 0;
            //if (questionOneAnswer.Text == q.Questions.ElementAt(0).Value) { totalScore++; }
            //if (questionTwoAnswer.Text == q.Questions.ElementAt(1).Value) { totalScore++; }
            //if (questionThreeAnswer.Text == q.Questions.ElementAt(2).Value) { totalScore++; }
            //if (questionFourAnswer.Text == q.Questions.ElementAt(3).Value) { totalScore++; }
            //if (questionFiveAnswer.Text == q.Questions.ElementAt(4).Value) { totalScore++; }
            MessageBox.Show($"{q.Score} of {q.QuestionAmount}\nThis is {q.Percent}% giving you a {q.Grade}");
        }
    }
}