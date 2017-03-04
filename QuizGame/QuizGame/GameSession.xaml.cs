using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QuizGame
{
    /// <summary>
    /// Interaction logic for GameSession.xaml
    /// </summary>
    public partial class GameSession : Window
    {
        Question Question;
        Game Game;
        public GameSession()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string gameType = (string)Application.Current.Properties["GameType"];
            MainWindow Main = this.Owner as MainWindow;

            switch (gameType)
            {
                case "Challenge":
                    Game = new ChallengeGame(Main.User);
                    break;
                case "Endless":
                    Game = new EndlessGame(Main.User);
                    break;
                default:
                    Game = new SessionGame(Main.User);
                    break;
            }
            PlayRound();
        }

        private void PlayRound()
        {
            lblPoints.Content = "Score: " + Game.ShowPoints();
            Question = Game.GenerateQuestion();
            DisplayQuestion(Question);
        }

        private void Answer(string answer)
        {
            Game.InterpretAnswer(Question,answer);
            PlayRound();
        }

        private void DisplayQuestion(Question question)
        {
            lblQuestion.Text = question.QuestionToAsk;
            btnA.Content = question.AnswerA;
            btnB.Content = question.AnswerB;
            btnC.Content = question.AnswerC;
            btnD.Content = question.AnswerD;
        }

        private void btnAnswer_Click(object sender, RoutedEventArgs e)
        {
            Button clicked = sender as Button;
            string temp = clicked.Name;
            string answer=temp[temp.Length-1].ToString();
            Answer(answer);
        }
    }
}
