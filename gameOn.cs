using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOn
{
    public partial class GameOn : Form
    {
        public GameOn()
        {
            InitializeComponent();          
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {           
        }

        private void LoadGame(int progressValue)
        {
            var play = new PlayerVPlayer.PlayerVPlayer();
            if (progressValue == progressBar1.Maximum)
            {
                timer1.Enabled = false;
                Hide();
                play.ShowDialog();
                Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
            if(progressBar1.Value == progressBar1.Maximum)LoadGame(progressBar1.Value);
        }
    }
}

