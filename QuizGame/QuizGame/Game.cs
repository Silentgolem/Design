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
            List<Question> Output = new List<Question>();
            string filePath = "questions.txt";
            string[] details = new string[File.ReadAllLines(filePath).Count()];

            details = File.ReadAllLines(filePath);
            foreach (string line in details)
            {
                string[] questionDetails = line.Split(',');
                Question newQ = new Question(questionDetails[0], questionDetails[1], questionDetails[2], questionDetails[3], questionDetails[4], questionDetails[5]);
                Output.Add(newQ);
            }
            return Output;
        }

        public Question GenerateQuestion()
        {
            QuestionsAsked++;
            return Questions[random.Next(0,Questions.Count)];
        }

        public abstract void InterpretAnswer(Question question, string answer);

        public abstract string ShowPoints();
    }
     class ChallengeGame : Game
    {
        public ChallengeGame(Player User) : base(User)
        {
            User.Points = 0;
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
        public SessionGame(Player User) : base(User)
        {
            PercentCorrect = 0;
            User.Points = 0;
        }
        public override void InterpretAnswer(Question question, string answer)
        {
            if (question.CorrectAnswer == answer)
            {
                User.Points++;
            }
            PercentCorrect = (double)User.Points / QuestionsAsked * 100;
        }
        public override string ShowPoints()
        {
            int temp = Convert.ToInt32(PercentCorrect);
            return temp +"%";
        }
    }
}
