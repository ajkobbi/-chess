using System;
using System.Drawing;
using System.Windows.Forms;

namespace PlayerVPlayer
{
    public partial class PlayerVPlayer : Form
    {
        // Game mode.
        bool Computer = false;
        // Colors.
        public readonly Color selectedColor = Color.Aqua, normalColor = Color.Transparent, clickColor = Color.Gold, dangerColor = Color.IndianRed, checkingColor = Color.Wheat;

        public int timerValue = 0;
        private uint blackCount = 0, whiteCount = 0;

        public PlayerVPlayer() { InitializeComponent(); }

        PictureBox[,] board = new PictureBox[8, 8];

        public bool BlackTurn = true, WhiteTurn = false, Moving = false;
        public int[] Mover = new int[2];

        // Contains board and sets some spaces.tags to null.
        private void PlayerVPlayer_Load(object sender, EventArgs e)
        {
            board = new PictureBox[8, 8]
            {
                { space0, space1, space2, space3, space4, space5, space6, space7 },             //      7       15      23      31      39      47      55      63
                { space8, space9, space10, space11, space12, space13, space14, space15 },       //      6       14      22      30      38      46      54      62
                { space16, space17, space18, space19, space20, space21, space22, space23 },     //      5       13      21      29      37      45      53      61
                { space24, space25, space26, space27, space28, space29, space30, space31 },     //      4       12      20      28      36      44      52      60
                { space32, space33, space34, space35, space36, space37, space38, space39 },     //      3       11      19      27      35      43      51      59
                { space40, space41, space42, space43, space44, space45, space46, space47 },     //      2       10      18      26      34      42      50      58
                { space48, space49, space50, space51, space52, space53, space54, space55 },     //      1       9       17      25      33      41      49      57
                { space56, space57, space58, space59, space60, space61, space62, space63 }      //      0       8       16      24      32      40      48      56
            };
            space11.Tag = null; space12.Tag = null; space13.Tag = null; space18.Tag = null; space3.Tag = null;
        }

        public void PieceSelect(PictureBox space, string name)
        {
            string tag = string.Empty;
            foreach (var spaces in board)
            {
                if (space.Tag == spaces.Tag && space.Name == spaces.Name)
                {
                    space.BackColor = clickColor;
                    tag = (string)space.Tag;
                }
                else continue;
            }

            switch (tag)
            {
                // Pawns.
                #region
                // BlackPawn2.
                case "BlackPawn2":
                    if (BlackTurn)
                    {
                        if (name.Length == 6)
                        {
                            int[] index = new int[2] { 0, int.Parse(name[5].ToString()) };
                            if (index[1] > 7) { index[0] = 1; index[1] %= 8; }

                            if (board[index[0], index[1] + 1].Tag == null)
                            {
                                board[index[0], index[1] + 1].BackColor = selectedColor;
                                if (board[index[0], index[1] + 2].Tag == null) board[index[0], index[1] + 2].BackColor = selectedColor;
                                MoveSetter(index);
                            }
                            try { if (board[index[0] + 1, index[1] + 1].Tag.ToString().Contains("White")) { board[index[0] + 1, index[1] + 1].BackColor = dangerColor; MoveSetter(index); } } catch { }
                            try { if (board[index[0] - 1, index[1] + 1].Tag.ToString().Contains("White")) { board[index[0] - 1, index[1] + 1].BackColor = dangerColor; MoveSetter(index); } } catch { }
                        }
                        else
                        {
                            int[] ind = new int[2] { int.Parse(name[5].ToString()), int.Parse(name[6].ToString()) };
                            string num = name[5].ToString() + name[6].ToString();
                            if (int.Parse(num) > 7)
                            {
                                ind[0] = int.Parse(num) / 8;
                                ind[1] = int.Parse(num) % 8;
                            }
                            if (board[ind[0], ind[1] + 1].Tag == null) board[ind[0], ind[1] + 1].BackColor = selectedColor;
                            if (board[ind[0], ind[1] + 2].Tag == null) board[ind[0], ind[1] + 2].BackColor = selectedColor;
                            MoveSetter(ind);

                            try
                            { if (board[ind[0] + 1, ind[1] + 1].Tag.ToString().Contains("White")) { board[ind[0] + 1, ind[1] + 1].BackColor = dangerColor; MoveSetter(ind); } }
                            catch { }
                            try { if (board[ind[0] - 1, ind[1] + 1].Tag.ToString().Contains("White")) { board[ind[0] - 1, ind[1] + 1].BackColor = dangerColor; MoveSetter(ind); } } catch { }
                        }
                    }
                    break;

                // BlackPawn.
                case "BlackPawn":
                    if (BlackTurn)
                    {
                        if (name.Length == 6)
                        {
                            int index2 = int.Parse(name[5].ToString());
                            if (board[0, index2 + 1].Tag == null)
                            {
                                board[0, index2 + 1].BackColor = selectedColor;
                                Mover[0] = 0; Mover[1] = index2;
                                Moving = true;
                            }
                            try { if (board[1, index2 + 1].Tag.ToString().Contains("White")) { board[1, index2 + 1].BackColor = dangerColor; Moving = true; Mover[0] = 0; Mover[1] = index2; } } catch { }
                        }

                        else
                        {
                            int[] ind = new int[2] { int.Parse(name[5].ToString()), int.Parse(name[6].ToString()) };
                            string num = name[5].ToString() + name[6].ToString();
                            if (int.Parse(num) > 7)
                            {
                                ind[0] = int.Parse(num) / 8;
                                ind[1] = int.Parse(num) % 8;
                            }
                            try
                            {
                                if (board[ind[0], ind[1] + 1].Tag == null)
                                {
                                    board[ind[0], ind[1] + 1].BackColor = selectedColor;
                                    MoveSetter(ind);
                                }
                            }
                            catch { MessageBox.Show("BLACK PAWN ON WHITE LAND"); }

                            try { if (board[ind[0] + 1, ind[1] + 1].Tag.ToString().Contains("White")) { board[ind[0] + 1, ind[1] + 1].BackColor = dangerColor; MoveSetter(ind); } } catch { }
                            try { if (board[ind[0] - 1, ind[1] + 1].Tag.ToString().Contains("White")) { board[ind[0] - 1, ind[1] + 1].BackColor = dangerColor; MoveSetter(ind); } } catch { }
                        }
                    }
                    break;

                // WhitePawn2.
                case "WhitePawn2":
                    if (WhiteTurn)
                    {
                        if (name.Length == 6)
                        {
                            int index2 = (int)char.GetNumericValue(name[5]);
                            if (board[0, index2 - 1].Tag == null)
                            {
                                board[0, index2 - 1].BackColor = selectedColor;
                                if (board[0, index2 - 2].Tag == null) board[0, index2 - 2].BackColor = selectedColor;
                                Moving = true;
                                Mover[0] = 0; Mover[1] = index2;
                            }
                            try { if (board[0 + 1, index2 - 1].Tag.ToString().Contains("Black")) board[0 + 1, index2 - 1].BackColor = dangerColor; Moving = true; Mover[0] = 0; Mover[1] = index2; } catch { }
                            try { if (board[0 - 1, index2 - 1].Tag.ToString().Contains("Black")) board[0 - 1, index2 - 1].BackColor = dangerColor; Moving = true; Mover[0] = 0; Mover[1] = index2; } catch { }
                        }
                        else
                        {
                            int[] ind = new int[2] { int.Parse(name[5].ToString()), int.Parse(name[6].ToString()) };
                            string num = name[5].ToString() + name[6].ToString();
                            if (int.Parse(num) > 7)
                            {
                                var dividor = int.Parse(num) / 8;
                                var remainder = int.Parse(num) % 8;
                                ind[0] = dividor;
                                ind[1] = remainder;
                            }

                            if (board[ind[0], ind[1] - 1].Tag == null)
                            {
                                board[ind[0], ind[1] - 1].BackColor = selectedColor;
                                if (board[ind[0], ind[1] - 2].Tag == null) board[ind[0], ind[1] - 2].BackColor = selectedColor;
                                MoveSetter(ind);
                            }

                            try { if (board[ind[0] + 1, ind[1] - 1].Tag.ToString().Contains("Black")) { board[ind[0] + 1, ind[1] - 1].BackColor = dangerColor; MoveSetter(ind); } } catch { }
                            try { if (board[ind[0] - 1, ind[1] - 1].Tag.ToString().Contains("Black")) { board[ind[0] - 1, ind[1] - 1].BackColor = dangerColor; MoveSetter(ind); } } catch { }
                        }
                    }
                    break;

                // WhitePawn.
                case "WhitePawn":
                    if (WhiteTurn)
                    {
                        if (name.Length == 6)
                        {
                            int index2 = (int)char.GetNumericValue(name[5]);
                            if (board[0, index2 - 1].Tag == null)
                            {
                                board[0, index2 - 1].BackColor = selectedColor;
                                Mover[0] = 0; Mover[1] = index2;
                                Moving = true;
                            }
                            try { if (board[1, index2 - 1].Tag.ToString().Contains("Black")) { board[1, index2 - 1].BackColor = dangerColor; Moving = true; Mover[0] = 0; Mover[1] = index2; } } catch { }
                        }

                        else
                        {
                            int[] ind = new int[2] { int.Parse(name[5].ToString()), int.Parse(name[6].ToString()) };
                            string num = name[5].ToString() + name[6].ToString();
                            if (int.Parse(num) > 7)
                            {
                                ind[0] = int.Parse(num) / 8;
                                ind[1] = int.Parse(num) % 8;
                            }

                            if (board[ind[0], ind[1] - 1].Tag == null)
                            {
                                board[ind[0], ind[1] - 1].BackColor = selectedColor;
                                MoveSetter(ind);
                            }
                            try { if (board[ind[0] + 1, ind[1] - 1].Tag.ToString().Contains("Black")) { board[ind[0] + 1, ind[1] - 1].BackColor = dangerColor; Moving = true; Mover[0] = ind[0]; Mover[1] = ind[1]; } } catch { }
                            try { if (board[ind[0] - 1, ind[1] - 1].Tag.ToString().Contains("Black")) { board[ind[0] - 1, ind[1] - 1].BackColor = dangerColor; Moving = true; Mover[0] = ind[0]; Mover[1] = ind[1]; } } catch { }
                        }
                    }
                    break;
                #endregion

                // Rooks and Queens.
                #region
                // Black Rook.
                case "BlackRook":
                case "BlackQueen":
                    if (BlackTurn)
                    {
                        int[] index = new int[2];
                        IndexSetter(index, name);

                        // Forward.
                        for (var i = 1; i < 8; i++)
                        {
                            try
                            {
                                if (board[index[0], index[1] + i].Tag != null)
                                {
                                    try { if (board[index[0], index[1] + i].Tag.ToString().Contains("White")) board[index[0], index[1] + i].BackColor = dangerColor; } catch { }
                                    break;
                                }

                                else board[index[0], index[1] + i].BackColor = selectedColor;
                            }
                            catch { }
                        }

                        // Backward.
                        for (var i = 1; i < 8; i++)
                        {
                            try
                            {
                                if (board[index[0], index[1] - i].Tag != null)
                                {
                                    try { if (board[index[0], index[1] - i].Tag.ToString().Contains("White")) board[index[0], index[1] - i].BackColor = dangerColor; } catch { }
                                    break;
                                }
                                else board[index[0], index[1] - i].BackColor = selectedColor;
                            }
                            catch { }
                        }
                        // Left.
                        for (var i = 1; i < 8; i++)
                        {
                            try
                            {
                                if (board[index[0] - i, index[1]].Tag != null)
                                {
                                    if (board[index[0] - i, index[1]].Tag.ToString().Contains("White")) board[index[0] - i, index[1]].BackColor = dangerColor;
                                    break;
                                }
                                else board[index[0] - i, index[1]].BackColor = selectedColor;
                            }
                            catch { }
                        }

                        // Right.
                        for (var i = 1; i < 8; i++)
                        {
                            try
                            {
                                if (board[index[0] + i, index[1]].Tag != null)
                                {
                                    if (board[index[0] + i, index[1]].Tag.ToString().Contains("White")) board[index[0] + i, index[1]].BackColor = dangerColor;
                                    break;
                                }
                                else board[index[0] + i, index[1]].BackColor = selectedColor;
                            }
                            catch { }
                        }
                        MoveSetter(index);
                        if (tag == "BlackQueen") BishopLogic(index, name, "White");

                    }
                    break;

                case "WhiteRook":
                case "WhiteQueen":
                    if (WhiteTurn)
                    {
                        int[] index = new int[2];
                        IndexSetter(index, name);

                        // Backward.
                        for (var i = 1; i < 8; i++)
                        {
                            try
                            {
                                if (board[index[0], index[1] + i].Tag != null)
                                {
                                    try { if (board[index[0], index[1] + i].Tag.ToString().Contains("Black")) board[index[0], index[1] + i].BackColor = dangerColor; } catch { }
                                    break;
                                }

                                else board[index[0], index[1] + i].BackColor = selectedColor;
                            }
                            catch { }
                        }

                        // Forward.
                        for (var i = 1; i < 8; i++)
                        {
                            try
                            {
                                if (board[index[0], index[1] - i].Tag != null)
                                {
                                    try { if (board[index[0], index[1] - i].Tag.ToString().Contains("Black")) board[index[0], index[1] - i].BackColor = dangerColor; } catch { }
                                    break;
                                }
                                else board[index[0], index[1] - i].BackColor = selectedColor;
                            }
                            catch { }
                        }
                        // Left.
                        for (var i = 1; i < 8; i++)
                        {
                            try
                            {
                                if (board[index[0] - i, index[1]].Tag != null)
                                {
                                    if (board[index[0] - i, index[1]].Tag.ToString().Contains("Black")) board[index[0] - i, index[1]].BackColor = dangerColor;
                                    break;
                                }
                                else board[index[0] - i, index[1]].BackColor = selectedColor;
                            }
                            catch { }
                        }

                        // Right.
                        for (var i = 1; i < 8; i++)
                        {
                            try
                            {
                                if (board[index[0] + i, index[1]].Tag != null)
                                {
                                    if (board[index[0] + i, index[1]].Tag.ToString().Contains("Black")) board[index[0] + i, index[1]].BackColor = dangerColor;
                                    break;
                                }
                                else board[index[0] + i, index[1]].BackColor = selectedColor;
                            }
                            catch { }
                        }
                        MoveSetter(index);

                        if (tag == "WhiteQueen") BishopLogic(index, name, "Black");
                    }
                    break;
                #endregion

                // Knights.
                #region
                // BlackKnight.
                case "BlackKnight":
                    if (BlackTurn)
                    {
                        int[] index = new int[2];
                        IndexSetter(index, name);

                        // 2 up 1 left.
                        try
                        {
                            if (board[index[0] - 1, index[1] + 2].Tag == null) board[index[0] - 1, index[1] + 2].BackColor = selectedColor;
                            if (board[index[0] - 1, index[1] + 2].Tag.ToString().Contains("White")) board[index[0] - 1, index[1] + 2].BackColor = dangerColor;
                        }
                        catch { }

                        // 2 down 1 right.
                        try
                        {
                            if (board[index[0] + 1, index[1] - 2].Tag == null) board[index[0] + 1, index[1] - 2].BackColor = selectedColor;
                            if (board[index[0] + 1, index[1] - 2].Tag.ToString().Contains("White")) board[index[0] + 1, index[1] - 2].BackColor = dangerColor;
                        }
                        catch { }

                        // 2 up 1 right.
                        try
                        {
                            if (board[index[0] + 1, index[1] + 2].Tag == null) board[index[0] + 1, index[1] + 2].BackColor = selectedColor;
                            if (board[index[0] + 1, index[1] + 2].Tag.ToString().Contains("White")) board[index[0] + 1, index[1] + 2].BackColor = dangerColor;
                        }
                        catch { }

                        // 2 down 1 left.
                        try
                        {
                            if (board[index[0] - 1, index[1] - 2].Tag == null) board[index[0] - 1, index[1] - 2].BackColor = selectedColor;
                            if (board[index[0] - 1, index[1] - 2].Tag.ToString().Contains("White")) board[index[0] - 1, index[1] - 2].BackColor = dangerColor;
                        }
                        catch { }

                        // 2 left 1 down.
                        try
                        {
                            if (board[index[0] - 2, index[1] - 1].Tag == null) board[index[0] - 2, index[1] - 1].BackColor = selectedColor;
                            if (board[index[0] - 2, index[1] - 1].Tag.ToString().Contains("White")) board[index[0] - 2, index[1] - 1].BackColor = dangerColor;
                        }
                        catch { }

                        // 2 left 1 up.
                        try
                        {
                            if (board[index[0] - 2, index[1] + 1].Tag == null) board[index[0] - 2, index[1] + 1].BackColor = selectedColor;
                            if (board[index[0] - 2, index[1] + 1].Tag.ToString().Contains("White")) board[index[0] - 2, index[1] + 1].BackColor = dangerColor;
                        }
                        catch { }

                        // 2 left 1 down.
                        try
                        {
                            if (board[index[0] + 2, index[1] - 1].Tag == null) board[index[0] + 2, index[1] - 1].BackColor = selectedColor;
                            if (board[index[0] + 2, index[1] - 1].Tag.ToString().Contains("White")) board[index[0] + 2, index[1] - 1].BackColor = dangerColor;
                        }
                        catch { }

                        // 2 right 1 up.
                        try
                        {
                            if (board[index[0] + 2, index[1] + 1].Tag == null) board[index[0] + 2, index[1] + 1].BackColor = selectedColor;
                            if (board[index[0] + 2, index[1] + 1].Tag.ToString().Contains("White")) board[index[0] + 2, index[1] + 1].BackColor = dangerColor;
                        }
                        catch { }

                        MoveSetter(index);
                    }
                    break;

                // WhiteKnight.
                case "WhiteKnight":
                    if (WhiteTurn)
                    {
                        int[] index = new int[2];
                        IndexSetter(index, name);

                        // 2 up 1 left.
                        try
                        {
                            if (board[index[0] - 1, index[1] + 2].Tag == null) board[index[0] - 1, index[1] + 2].BackColor = selectedColor;
                            if (board[index[0] - 1, index[1] + 2].Tag.ToString().Contains("Black")) board[index[0] - 1, index[1] + 2].BackColor = dangerColor;
                        }
                        catch { }

                        // 2 down 1 right.
                        try
                        {
                            if (board[index[0] + 1, index[1] - 2].Tag == null) board[index[0] + 1, index[1] - 2].BackColor = selectedColor;
                            if (board[index[0] + 1, index[1] - 2].Tag.ToString().Contains("Black")) board[index[0] + 1, index[1] - 2].BackColor = dangerColor;
                        }
                        catch { }

                        // 2 up 1 right.
                        try
                        {
                            if (board[index[0] + 1, index[1] + 2].Tag == null) board[index[0] + 1, index[1] + 2].BackColor = selectedColor;
                            if (board[index[0] + 1, index[1] + 2].Tag.ToString().Contains("Black")) board[index[0] + 1, index[1] + 2].BackColor = dangerColor;
                        }
                        catch { }

                        // 2 down 1 left.
                        try
                        {
                            if (board[index[0] - 1, index[1] - 2].Tag == null) board[index[0] - 1, index[1] - 2].BackColor = selectedColor;
                            if (board[index[0] - 1, index[1] - 2].Tag.ToString().Contains("Black")) board[index[0] - 1, index[1] - 2].BackColor = dangerColor;
                        }
                        catch { }

                        // 2 left 1 down.
                        try
                        {
                            if (board[index[0] - 2, index[1] - 1].Tag == null) board[index[0] - 2, index[1] - 1].BackColor = selectedColor;
                            if (board[index[0] - 2, index[1] - 1].Tag.ToString().Contains("Black")) board[index[0] - 2, index[1] - 1].BackColor = dangerColor;
                        }
                        catch { }

                        // 2 left 1 up.
                        try
                        {
                            if (board[index[0] - 2, index[1] + 1].Tag == null) board[index[0] - 2, index[1] + 1].BackColor = selectedColor;
                            if (board[index[0] - 2, index[1] + 1].Tag.ToString().Contains("Black")) board[index[0] - 2, index[1] + 1].BackColor = dangerColor;
                        }
                        catch { }

                        // 2 left 1 down.
                        try
                        {
                            if (board[index[0] + 2, index[1] - 1].Tag == null) board[index[0] + 2, index[1] - 1].BackColor = selectedColor;
                            if (board[index[0] + 2, index[1] - 1].Tag.ToString().Contains("Black")) board[index[0] + 2, index[1] - 1].BackColor = dangerColor;
                        }
                        catch { }

                        // 2 right 1 up.
                        try
                        {
                            if (board[index[0] + 2, index[1] + 1].Tag == null) board[index[0] + 2, index[1] + 1].BackColor = selectedColor;
                            if (board[index[0] + 2, index[1] + 1].Tag.ToString().Contains("Black")) board[index[0] + 2, index[1] + 1].BackColor = dangerColor;
                        }
                        catch { }

                        MoveSetter(index);
                    }
                    break;
                #endregion

                // Bishops.
                #region
                // BlackBishop.
                case "BlackBishop":
                    if (BlackTurn)
                    {
                        int[] index = new int[2];
                        BishopLogic(index, name, "White");
                    }
                    break;

                // WhiteBishop.
                case "WhiteBishop":
                    if (WhiteTurn)
                    {
                        int[] index = new int[2];
                        BishopLogic(index, name, "Black");
                    }
                    break;
                #endregion

                // Kings.
                #region
                case "BlackKing":
                    if (BlackTurn)
                    {
                        int[] index = new int[2];
                        IndexSetter(index, name);

                        try
                        {
                            if (board[index[0] + 1, index[1]].Tag == null) { board[index[0] + 1, index[1]].BackColor = selectedColor; }
                            else if (board[index[0] + 1, index[1]].Tag.ToString().Contains("White")) { board[index[0] + 1, index[1]].BackColor = dangerColor; }
                        }
                        catch { }

                        try
                        {
                            if (board[index[0] - 1, index[1]].Tag == null) { board[index[0] - 1, index[1]].BackColor = selectedColor; }
                            else if (board[index[0] - 1, index[1]].Tag.ToString().Contains("White")) { board[index[0] - 1, index[1]].BackColor = dangerColor; }
                        }
                        catch { }

                        try
                        {
                            if (board[index[0] + 1, index[1] + 1].Tag == null) { board[index[0] + 1, index[1] + 1].BackColor = selectedColor; }
                            else if (board[index[0] + 1, index[1] + 1].Tag.ToString().Contains("White")) { board[index[0] + 1, index[1] + 1].BackColor = dangerColor; }
                        }
                        catch { }

                        try
                        {
                            if (board[index[0] - 1, index[1] - 1].Tag == null) { board[index[0] - 1, index[1] - 1].BackColor = selectedColor; }
                            else if (board[index[0] - 1, index[1] - 1].Tag.ToString().Contains("White")) { board[index[0] - 1, index[1] - 1].BackColor = dangerColor; }
                        }
                        catch { }

                        try
                        {
                            if (board[index[0] - 1, index[1] + 1].Tag == null) { board[index[0] - 1, index[1] + 1].BackColor = selectedColor; }
                            else if (board[index[0] - 1, index[1] + 1].Tag.ToString().Contains("White")) { board[index[0] - 1, index[1] + 1].BackColor = dangerColor; }
                        }
                        catch { }

                        try
                        {
                            if (board[index[0] + 1, index[1] - 1].Tag == null) { board[index[0] + 1, index[1] - 1].BackColor = selectedColor; }
                            else if (board[index[0] + 1, index[1] - 1].Tag.ToString().Contains("White")) { board[index[0] + 1, index[1] - 1].BackColor = dangerColor; }
                        }
                        catch { }

                        try
                        {
                            if (board[index[0], index[1] + 1].Tag == null) { board[index[0], index[1] + 1].BackColor = selectedColor; }
                            else if (board[index[0], index[1] + 1].Tag.ToString().Contains("White")) { board[index[0], index[1] + 1].BackColor = dangerColor; }
                        }
                        catch { }

                        try
                        {
                            if (board[index[0], index[1] - 1].Tag == null) { board[index[0], index[1] - 1].BackColor = selectedColor; }
                            else if (board[index[0], index[1] - 1].Tag.ToString().Contains("White")) { board[index[0], index[1] - 1].BackColor = dangerColor; }
                        }
                        catch { }

                        MoveSetter(index);
                    }
                    break;

                // WhiteKing.
                case "WhiteKing":
                    if (WhiteTurn)
                    {
                        int[] index = new int[2];
                        IndexSetter(index, name);

                        try
                        {
                            if (board[index[0] + 1, index[1]].Tag == null) { board[index[0] + 1, index[1]].BackColor = selectedColor; }
                            else if (board[index[0] + 1, index[1]].Tag.ToString().Contains("Black")) { board[index[0] + 1, index[1]].BackColor = dangerColor; }
                        }
                        catch { }

                        try
                        {
                            if (board[index[0] - 1, index[1]].Tag == null) { board[index[0] - 1, index[1]].BackColor = selectedColor; }
                            else if (board[index[0] - 1, index[1]].Tag.ToString().Contains("Black")) { board[index[0] - 1, index[1]].BackColor = dangerColor; }
                        }
                        catch { }

                        try
                        {
                            if (board[index[0] + 1, index[1] + 1].Tag == null) { board[index[0] + 1, index[1] + 1].BackColor = selectedColor; }
                            else if (board[index[0] + 1, index[1] + 1].Tag.ToString().Contains("Black")) { board[index[0] + 1, index[1] + 1].BackColor = dangerColor; }
                        }
                        catch { }

                        try
                        {
                            if (board[index[0] - 1, index[1] - 1].Tag == null) { board[index[0] - 1, index[1] - 1].BackColor = selectedColor; }
                            else if (board[index[0] - 1, index[1] - 1].Tag.ToString().Contains("Black")) { board[index[0] - 1, index[1] - 1].BackColor = dangerColor; }
                        }
                        catch { }

                        try
                        {
                            if (board[index[0] - 1, index[1] + 1].Tag == null) { board[index[0] - 1, index[1] + 1].BackColor = selectedColor; }
                            else if (board[index[0] - 1, index[1] + 1].Tag.ToString().Contains("Black")) { board[index[0] - 1, index[1] + 1].BackColor = dangerColor; }
                        }
                        catch { }

                        try
                        {
                            if (board[index[0] + 1, index[1] - 1].Tag == null) { board[index[0] + 1, index[1] - 1].BackColor = selectedColor; }
                            else if (board[index[0] + 1, index[1] - 1].Tag.ToString().Contains("Black")) { board[index[0] + 1, index[1] - 1].BackColor = dangerColor; }
                        }
                        catch { }

                        try
                        {
                            if (board[index[0], index[1] + 1].Tag == null) { board[index[0], index[1] + 1].BackColor = selectedColor; }
                            else if (board[index[0], index[1] + 1].Tag.ToString().Contains("Black")) { board[index[0], index[1] + 1].BackColor = dangerColor; }
                        }
                        catch { }

                        try
                        {
                            if (board[index[0], index[1] - 1].Tag == null) { board[index[0], index[1] - 1].BackColor = selectedColor; }
                            else if (board[index[0], index[1] - 1].Tag.ToString().Contains("Black")) { board[index[0], index[1] - 1].BackColor = dangerColor; }
                        }
                        catch { }

                        MoveSetter(index);
                    }
                    break;
                    #endregion
            }
        }

        // Resets all spaces backColor to normalColour.
        public void RemoveColor()
        {
            for (int i = 0; i < 8; i++) for (int l = 0; l < 8; l++) board[i, l].BackColor = normalColor;
        }

        public void CheckForWin(string piece)
        {
            if (piece == "WhiteKing")
            {
                MessageBox.Show($"White King captured!\n{PlayerGame.PlayerGame.player1Name} Wins in {blackCount} moves!");
                timer.Enabled = false;
                Leaders.LeaderBoard lD = new Leaders.LeaderBoard();
                lD.Store(PlayerGame.PlayerGame.player1Name, blackCount);
                Close();
            }
            else if (piece == "BlackKing")
            {
                MessageBox.Show($"Black King captured!\n{PlayerGame.PlayerGame.player2Name} Wins in {whiteCount} moves!");
                timer.Enabled = false;
                Leaders.LeaderBoard lD = new Leaders.LeaderBoard();
                lD.Store(PlayerGame.PlayerGame.player2Name, whiteCount);
                Close();
            }
        }

        // Bishop's logic.
        public void BishopLogic(int[] index, string name, string enemyPiece)
        {
            IndexSetter(index, name);

            // Upwards.
            for (var i = 1; i < 8; i++)
            {
                try
                {
                    if (board[index[0] + i, index[1] + i].Tag == null)
                        board[index[0] + i, index[1] + i].BackColor = selectedColor;
                    else if (board[index[0] + i, index[1] + i].Tag.ToString().Contains(enemyPiece))
                    {
                        board[index[0] + i, index[1] + i].BackColor = dangerColor;
                        break;
                    }
                    else break;
                }
                catch { }
            }

            // Downwards.
            for (var i = 1; i < 8; i++)
            {
                try
                {
                    if (board[index[0] - i, index[1] - i].Tag == null)
                        board[index[0] - i, index[1] - i].BackColor = selectedColor;
                    else if (board[index[0] - i, index[1] - i].Tag.ToString().Contains(enemyPiece))
                    {
                        board[index[0] - i, index[1] - i].BackColor = dangerColor;
                        break;
                    }
                    else break;
                }
                catch { }
            }

            // Left.
            for (var i = 1; i < 8; i++)
            {
                try
                {
                    if (board[index[0] - i, index[1] + i].Tag == null)
                        board[index[0] - i, index[1] + i].BackColor = selectedColor;
                    else if (board[index[0] - i, index[1] + i].Tag.ToString().Contains(enemyPiece))
                    {
                        board[index[0] - i, index[1] + i].BackColor = dangerColor;
                        break;
                    }
                    else break;
                }
                catch { }
            }

            // Right.
            for (var i = 1; i < 8; i++)
            {
                try
                {
                    if (board[index[0] + i, index[1] - i].Tag == null)
                        board[index[0] + i, index[1] - i].BackColor = selectedColor;
                    else if (board[index[0] + i, index[1] - i].Tag.ToString().Contains(enemyPiece))
                    {
                        board[index[0] + i, index[1] - i].BackColor = dangerColor;
                        break;
                    }
                    else break;
                }
                catch { }
            }
            MoveSetter(index);
        }

        // Preparing for piece movement.
        public void MoveSetter(int[] index)
        {
            Moving = true;
            Mover[0] = index[0]; Mover[1] = index[1];
        }

        // Setting the indexes.
        public void IndexSetter(int[] index, string name)
        {
            if (name.Length == 6)
            {
                if (int.Parse(name[5].ToString()) > 7)
                {
                    index[0] = 1;
                    index[1] = (int)char.GetNumericValue(name[5]) % 8;
                }
                else
                {
                    index[0] = 0;
                    index[1] = (int)char.GetNumericValue(name[5]);
                }
            }
            else
            {
                string num = name[5].ToString() + name[6].ToString();
                if (int.Parse(num) > 7)
                {
                    index[0] = int.Parse(num) / 8;
                    index[1] = int.Parse(num) % 8;
                }
            }
        }

        // What happens when any piece is clicked on. This method is called from the various PictureBox_Click(object sender, EventArgs e){} methods in this game.
        public void WhenClicked(ref PictureBox spaceName)
        {
            if (spaceName.BackColor == dangerColor && Moving)
            {
                RemoveColor();
                spaceName.BackgroundImage = board[Mover[0], Mover[1]].BackgroundImage;
                board[Mover[0], Mover[1]].BackgroundImage = null;

                if (spaceName.Tag.ToString() == "WhiteKing") { CheckForWin("WhiteKing"); }
                else if (spaceName.Tag.ToString() == "BlackKing") { CheckForWin("BlackKing"); }

                spaceName.Tag = board[Mover[0], Mover[1]].Tag;
                board[Mover[0], Mover[1]].Tag = null;

                if (BlackTurn) { ++blackCount; BlackTurn = false; WhiteTurn = true; }
                else if (WhiteTurn) { ++whiteCount; WhiteTurn = false; BlackTurn = true; }
                Moving = false;

                ResetTime();
            }
            if (spaceName.BackColor == selectedColor && !Moving) RemoveColor();
            else if (spaceName.BackColor == selectedColor && Moving && spaceName.Tag == null)
            {
                if (BlackTurn) { ++blackCount; BlackTurn = false; WhiteTurn = true; }
                else if (WhiteTurn) { ++whiteCount; WhiteTurn = false; BlackTurn = true; }
                RemoveColor();
                spaceName.BackgroundImage = board[Mover[0], Mover[1]].BackgroundImage;
                board[Mover[0], Mover[1]].BackgroundImage = null;

                // Tag changer.
                if (board[Mover[0], Mover[1]].Tag.ToString().Contains("Pawn")) spaceName.Tag = (board[Mover[0], Mover[1]].Tag.ToString().Contains("Black")) ? "BlackPawn" : "WhitePawn";
                else spaceName.Tag = board[Mover[0], Mover[1]].Tag;

                board[Mover[0], Mover[1]].Tag = null;
                Moving = false;
                Mover = new int[2];

                ResetTime();
            }
            else if (spaceName.Tag != null && !Moving)
            {
                RemoveColor();
                PieceSelect(spaceName, spaceName.Name);
            }
            else Moving = false;
        }

        // space_Click Events.
        #region
        private void space0_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space0);
        }

        private void space1_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space1);
        }

        private void space2_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space2);
        }

        private void space3_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space3);
        }

        private void space4_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space4);
        }

        private void space5_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space5);
        }

        private void space6_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space6);
        }

        private void space7_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space7);
        }

        private void space8_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space8);
        }

        private void space9_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space9);
        }

        private void space10_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space10);
        }

        private void space11_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space11);
        }

        private void space12_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space12);
        }

        private void space13_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space13);
        }

        private void space14_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space14);
        }

        private void space15_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space15);
        }

        private void space16_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space16);
        }

        private void space17_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space17);
        }

        private void space18_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space18);
        }

        private void space19_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space19);
        }

        private void space20_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space20);
        }

        private void space21_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space21);
        }

        private void space22_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space22);
        }

        private void space23_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space23);
        }

        private void space24_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space24);
        }

        private void space25_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space25);
        }

        private void space26_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space26);
        }

        private void space27_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space27);
        }

        private void space28_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space28);
        }

        private void space29_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space29);
        }

        private void space30_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space30);
        }

        private void space31_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space31);
        }

        private void space32_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space32);
        }

        private void space33_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space33);
        }

        private void space34_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space34);
        }

        private void space35_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space35);
        }

        private void space36_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space36);
        }

        private void space37_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space37);
        }

        private void space38_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space38);
        }

        private void space39_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space39);
        }

        private void space40_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space40);
        }

        private void space41_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space41);
        }

        private void space42_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space42);
        }

        private void space43_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space43);
        }

        private void space44_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space44);
        }

        private void space45_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space45);
        }

        private void space46_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space46);
        }

        private void space47_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space47);
        }

        private void space48_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space48);
        }

        private void space49_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space49);
        }

        private void space50_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space50);
        }

        private void space51_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space51);
        }

        private void space52_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space52);
        }

        private void space53_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space53);
        }

        private void space54_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space54);
        }

        private void space55_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space55);
        }

        private void space56_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space56);
        }

        private void space57_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space57);
        }

        private void space58_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space58);
        }

        private void space59_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space59);
        }

        private void space60_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space60);
        }

        private void space61_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space61);
        }

        private void space62_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space62);
        }

        private void space63_Click(object sender, EventArgs e)
        {
            WhenClicked(ref space63);
        }
        #endregion

        private void timer_Tick(object sender, EventArgs e)
        {
            timerValue++;
            try { timeLeftBar.Value = timeLeftBar.Maximum - timerValue; } finally { }

            if (timerValue == 30 && timeLeftBar.Value == 0)
            {
                ResetTime();
                if (BlackTurn) { WhiteTurn = true; BlackTurn = false; RemoveColor(); MessageBox.Show("Time's Up!\nWhite Turn"); }
                else if (WhiteTurn) { WhiteTurn = false; BlackTurn = true; RemoveColor(); MessageBox.Show("Time's Up!\nBlack Turn"); }
            }
        }

        private void ResetTime()
        {
            timerValue = 0;
            timeLeftBar.Value = 30;
        }
    }
}
