using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame
{
    class RetrieveFromFile
    {
        public static List<Question> GetQuestions()
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
    }
}
