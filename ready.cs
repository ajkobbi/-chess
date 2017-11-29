using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerGame
{
    public partial class PlayerGame : Form
    {
        public static string player1Name, player2Name;

        public PlayerGame()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            var mainMenu = new Chess.MainMenu();
            Hide();
            mainMenu.ShowDialog();
            Close();
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            var loadScreen = new GameOn.GameOn();
            Hide();
            loadScreen.ShowDialog();
            Close();
        }

        private void Player1Label_Click(object sender, EventArgs e){}

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (StartButton.ForeColor == Color.Black)
            {
                StartButton.ForeColor = Color.White;
                Player1Ready.ForeColor = Color.Red;
                player1Name = firstBox.Text;
            }
            else if (StartButton.ForeColor == Color.White)
            {
                Player2Ready.ForeColor = Color.Red;
                PlayButton.Enabled = true;
                player2Name = secondBox.Text;
                StartButton.Text = "HIT PLAY";
            }
        }
    }
}

