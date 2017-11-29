using System;
using System.Windows.Forms;

namespace Chess
{
    public partial class MainMenu : Form
    {
        public MainMenu(){
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e){
        }

        private void newGameButton_Click(object sender, EventArgs e){
            var playerVPlayer = new PlayerGame.PlayerGame();
            playerVPlayer.ShowDialog();
        }

        private void InstructionsButton_Click(object sender, EventArgs e)
        {
            var instructions = new Instructions.HowToPlay();
            instructions.ShowDialog();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Leaders_button_Click(object sender, EventArgs e)
        {
            var Leaders = new Leaders.LeaderBoard();
            Leaders.ShowDialog();
        }
    }
}

