using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame
{
    class Question
    {
        public string QuestionToAsk { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public string CorrectAnswer { get; set; }

        public Question(string Question,string A,string B,string C,string D,string Answer)
        {
            QuestionToAsk = Question;
            AnswerA = A;
            AnswerB = B;
            AnswerC = C;
            AnswerD = D;
            CorrectAnswer = Answer;
        }
    }
}
