using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace QuizGame
{
    abstract class Game
    {
        protected Player User { get; set; }
        static protected int QuestionsAsked { get; set; }
        List<Question> Questions { get; set; }
        static Random random = new Random();

        public Game(Player User)
        {
            this.User = User;
            Questions = GetQuestions();
            QuestionsAsked = 0;
        }

        private List<Question> GetQuestions()
        {
            List<Question> Output = RetrieveFromFile.GetQuestions();
            return Output;
        }

        public Question GenerateQuestion()
        {
            QuestionsAsked++;
            return Questions[random.Next(0,Questions.Count)];
        }

        public abstract void InterpretAnswer(Question question, string answer);

        public abstract string ShowPoints();

        public abstract void EndGame();
    }
     class ChallengeGame : Game
    {
        public ChallengeGame(Player User) : base(User)
        {
            User.Points = 0;
        }

        public override void EndGame()
        {
            User.UpdateUsers("ChallengeHighScores.txt");
        }

        public override void InterpretAnswer(Question question, string answer)
        {
            if (question.CorrectAnswer==answer)
            {
                User.Points++;
            }
        }
        public override string ShowPoints()
        {
            return User.Points.ToString();
        }
    }

    class EndlessGame : Game
    {
        public EndlessGame(Player User) : base(User)
        {
            User.CheckNames();
        }

        public override void EndGame()
        {
            User.UpdateUsers("users.txt");
        }
        public override void InterpretAnswer(Question question, string answer)
        {
            if (question.CorrectAnswer == answer)
            {
                User.Points += 50;
            }
        }
        public override string ShowPoints()
        {
            return User.Points.ToString();
        }
    }

    class SessionGame : Game
    {
        double PercentCorrect { get; set; }
        int QuestionsCorrect { get; set; }
        public SessionGame(Player User) : base(User)
        {
            PercentCorrect = 0;
            QuestionsCorrect = 0;
        }
        public override void EndGame()
        {
            User.UpdateUsers("SessionHighScores.txt");
        }
        public override void InterpretAnswer(Question question, string answer)
        {
            if (question.CorrectAnswer == answer)
            {
                QuestionsCorrect++;
            }
            PercentCorrect = (double)QuestionsCorrect / QuestionsAsked * 100;
        }
        public override string ShowPoints()
        {
            User.Points = Convert.ToInt32(PercentCorrect);
            return User.Points + "%";
        }
    }
}
