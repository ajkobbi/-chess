using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Instructions
{
    public partial class HowToPlay : Form
    {
        int current = 1;

        public HowToPlay()
        {
            InitializeComponent();
        }
        public List<string> guide = new List<string>(){
         @"At the beginning of the game the chessboard is laid out so that each player has the white (or light) color 
square in the bottom right-hand side. The chess pieces are then arranged the same way each time. 
The second row (or rank) is filled with pawns. The rooks go in the corners, then the knights next to them,
followed by the bishops, and finally the queen, who always goes on her own matching color (white 
queen on white, black queen on black), and the king on the remaining square.",

@"

Each of the 6 different kinds of pieces moves differently. Pieces cannot move through other pieces 
(though the knight can jump over other pieces), and can never move onto a square with one of their
own pieces. However, they can be moved to take the place of an opponent's piece which is then 
captured. Pieces are generally moved into positions where they can capture other pieces (by landing
on their square and then replacing them), defend their own pieces in case of capture, or control
important squares in the game.",

@"

The king is the most important piece, but is one of the weakest. The king can only move one square in 
any direction - up, down, to the sides, and diagonally. The king may never move himself into check 
(where he could be captured). When the king is attacked by another piece this is called ""check""."
       };

        private void HowToPlay_Load(object sender, EventArgs e)
        {
            text.Text = guide[0] + guide[1] + guide[2];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            text.Text = "";
            switch (current){
                case 1:
                    this.Close();
                    break;
                case 2:
                    text.Image = null;
                    text.Text = guide[0] + guide[1] + guide[2];
                    break;
                case 3:
                    text.Text = @"








        
    
        
    
    
                                                    
";
                    text.Image = imageList1.Images[0];
                    break;
            }
            current -= 2;
            ++current;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            text.Text = @"








        
    
        
    
    
                                                    
";
            switch (current)
            {
                case 1:
                    text.Image = imageList1.Images[0];
                    break;
                case 2:
                    text.Image = imageList1.Images[1];
                    break;
            }
            ++current;
        }
    }
}

