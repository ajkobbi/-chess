using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Leaders{
    public partial class LeaderBoard : Form{
        private SortedDictionary<int, string> names_and_counts = new SortedDictionary<int, string>();

        public void Store(string name, uint score){
            if (!File.Exists("leaderboard.txt"))
                File.Create("leaderboard.txt");

            int prevScore = 0;

            string[] lines = File.ReadAllLines("leaderboard.txt");
            for (var i = 0; i < lines.Length; ++i)
            {
                string[] parts = lines[i].Split(' ');
                try { if (parts.Length > 1) names_and_counts.Add(int.Parse(parts[1]), parts[0]); }
                catch
                {
                    if (parts[0] == name)
                    {
                        prevScore = int.Parse(parts[1]);
                        break;
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter("leaderboard.txt", true)){
                if (prevScore >= score) writer.WriteLine("a" + name.Trim() + " " + score);
                else if (prevScore == 0) writer.WriteLine(name.Trim() + " " + score);
            }
        }

        public void UpdateTable(){
            if (File.Exists("leaderboard.txt")){
                string[] lines = File.ReadAllLines("leaderboard.txt");
                for (var i = 0; i < lines.Length; ++i)
                {
                    string[] parts = lines[i].Split(' ');
                    if (parts.Length > 1) { try { names_and_counts.Add(int.Parse(parts[1]), parts[0]); } catch { }; }
                }

                List<string> updated = new List<string>();
                
                foreach (var i in names_and_counts)
                {
                    if (i.Value[0] == 'a')
                    {
                        string temp = i.Value.Remove(0, 1);
                        updated.Add(temp.Trim());
                        board.Text += $"\n{temp.Trim()}";

                        int adder = -2;
                        if (temp.Length >= 8) adder = temp.Length - 7;

                        for (var t = 0; t < 24 - (temp.Length + i.Key.ToString().Length + adder); ++t)
                            board.Text += " ";

                        board.Text += $"{i.Key}";
                    }
                    else
                    {
                        string temp = updated.Find(p => p == i.Value);
                        if (temp != i.Value)
                        {
                            board.Text += $"\n{i.Value}";
                            int adder = -2;
                            if (i.Value.Length >= 8) adder = i.Value.Length - 7;
                            
                            for (var t = 0; t < 24 - (i.Value.Length + i.Key.ToString().Length + adder); ++t)
                                board.Text += " ";

                            board.Text += $"{i.Key}";
                        }
                    }
                }
            }
        }
        
        public LeaderBoard()
        {
            InitializeComponent();
            UpdateTable();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

