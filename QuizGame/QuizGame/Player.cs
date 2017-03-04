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

        public override string ToString()
        {
            return Name + "," + Points;
        }
        public void CheckNames()
        {
            List<Player> Players=GetList("users.txt");
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

        private List<Player> GetList(string filePath)
        {
            List<Player> Players = new List<Player>();
            if (File.Exists(filePath))
            {
                string[] details = new string[File.ReadAllLines(filePath).Count()];

                details = File.ReadAllLines(filePath);
                foreach (string line in details)
                {
                    string[] playerDetails = line.Split(',');
                    Player newP = new Player(playerDetails[0], Int32.Parse(playerDetails[1]));
                    Players.Add(newP);
                } 
            }
            return Players;
        }

        public void UpdateUsers(string file)
        {
            List<Player> Players = GetList(file);
            if (file == "users.txt")
            {
                foreach (Player p in Players)
                {
                    if (p.Name == this.Name)
                    {
                        Players.Remove(p);
                        break;
                    }
                } 
            }
            Players.Add(this);

            Players=Players.OrderBy(o => o.Points).ToList();
            Players.Reverse();

            string[] details = new string[Players.Count];
            for (int i = 0; i < Players.Count; i++)
            {
                details[i] = Players[i].ToString();
            }
            File.WriteAllLines(file, details);
        }
    }
}
