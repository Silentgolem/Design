using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame
{
    public class Player
    {
        public string Name { get; set; }
        public int Points { get; set; }

        public Player()
        {

        }

        public Player(string Name)
        {
            if (Name != "")
            {
                this.Name = Name;
            }
            else
            {
                this.Name = "Nameless Fuckwit";
            }

            CheckNames();
        }

        public Player(string Name,int Points)
        {
            this.Name = Name;
            this.Points = Points;
        }
        public void CheckNames()
        {
            List<Player> Players = new List<Player>();
            string filePath = "users.txt";
            string[] details = new string[File.ReadAllLines(filePath).Count()];

            details = File.ReadAllLines(filePath);
            foreach (string line in details)
            {
                string[] playerDetails = line.Split(',');
                Player newP = new Player(playerDetails[0], Int32.Parse(playerDetails[1]));
                Players.Add(newP);
            }
            foreach (Player p in Players)
            {
                if (this.Name==p.Name)
                {
                    this.Points = p.Points;
                    break;
                }
                else
                {
                    this.Points = 1000;
                }
            }

        }
    }
}
