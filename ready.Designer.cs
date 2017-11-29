namespace PlayerGame
{
    partial class PlayerGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerGame));
            this.BackButton = new System.Windows.Forms.Button();
            this.PlayButton = new System.Windows.Forms.Button();
            this.Player1Label = new System.Windows.Forms.Label();
            this.Player2Label = new System.Windows.Forms.Label();
            this.Player1Ready = new System.Windows.Forms.Label();
            this.Player2Ready = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.firstBox = new System.Windows.Forms.MaskedTextBox();
            this.secondBox = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.SystemColors.Desktop;
            this.BackButton.Font = new System.Drawing.Font("Moire", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BackButton.Location = new System.Drawing.Point(21, 740);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(105, 39);
            this.BackButton.TabIndex = 0;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // PlayButton
            // 
            this.PlayButton.BackColor = System.Drawing.SystemColors.Desktop;
            this.PlayButton.Enabled = false;
            this.PlayButton.Font = new System.Drawing.Font("Moire", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.PlayButton.Location = new System.Drawing.Point(830, 21);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(105, 39);
            this.PlayButton.TabIndex = 1;
            this.PlayButton.Text = "PLAY!";
            this.PlayButton.UseVisualStyleBackColor = false;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // Player1Label
            // 
            this.Player1Label.AutoSize = true;
            this.Player1Label.Font = new System.Drawing.Font("Moire", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1Label.Location = new System.Drawing.Point(12, 133);
            this.Player1Label.Name = "Player1Label";
            this.Player1Label.Size = new System.Drawing.Size(570, 116);
            this.Player1Label.TabIndex = 2;
            this.Player1Label.Text = "PLAYER 1";
            this.Player1Label.Click += new System.EventHandler(this.Player1Label_Click);
            // 
            // Player2Label
            // 
            this.Player2Label.AutoSize = true;
            this.Player2Label.Font = new System.Drawing.Font("Moire", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player2Label.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Player2Label.Location = new System.Drawing.Point(365, 514);
            this.Player2Label.Name = "Player2Label";
            this.Player2Label.Size = new System.Drawing.Size(570, 116);
            this.Player2Label.TabIndex = 3;
            this.Player2Label.Text = "PLAYER 2";
            // 
            // Player1Ready
            // 
            this.Player1Ready.AutoSize = true;
            this.Player1Ready.Font = new System.Drawing.Font("Moire ExtraBold", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1Ready.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Player1Ready.Location = new System.Drawing.Point(198, 237);
            this.Player1Ready.Name = "Player1Ready";
            this.Player1Ready.Size = new System.Drawing.Size(168, 45);
            this.Player1Ready.TabIndex = 4;
            this.Player1Ready.Text = "READY";
            // 
            // Player2Ready
            // 
            this.Player2Ready.AutoSize = true;
            this.Player2Ready.Font = new System.Drawing.Font("Moire ExtraBold", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player2Ready.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Player2Ready.Location = new System.Drawing.Point(555, 630);
            this.Player2Ready.Name = "Player2Ready";
            this.Player2Ready.Size = new System.Drawing.Size(168, 45);
            this.Player2Ready.TabIndex = 5;
            this.Player2Ready.Text = "READY";
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.SystemColors.Desktop;
            this.StartButton.Font = new System.Drawing.Font("Moire", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.ForeColor = System.Drawing.Color.Black;
            this.StartButton.Location = new System.Drawing.Point(244, 335);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(451, 130);
            this.StartButton.TabIndex = 6;
            this.StartButton.Text = "START";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Desktop;
            this.textBox3.Font = new System.Drawing.Font("Miramonte", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.SystemColors.Menu;
            this.textBox3.Location = new System.Drawing.Point(156, 285);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(82, 21);
            this.textBox3.TabIndex = 9;
            this.textBox3.Text = "Player 1 Name";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Desktop;
            this.textBox4.Font = new System.Drawing.Font("Miramonte", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.ForeColor = System.Drawing.SystemColors.Menu;
            this.textBox4.Location = new System.Drawing.Point(421, 678);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(82, 21);
            this.textBox4.TabIndex = 10;
            this.textBox4.Text = "Player 2 Name";
            // 
            // firstBox
            // 
            this.firstBox.BackColor = System.Drawing.SystemColors.Desktop;
            this.firstBox.ForeColor = System.Drawing.SystemColors.Window;
            this.firstBox.Location = new System.Drawing.Point(244, 285);
            this.firstBox.Name = "firstBox";
            this.firstBox.Size = new System.Drawing.Size(144, 20);
            this.firstBox.TabIndex = 11;
            // 
            // secondBox
            // 
            this.secondBox.BackColor = System.Drawing.SystemColors.Desktop;
            this.secondBox.ForeColor = System.Drawing.SystemColors.Window;
            this.secondBox.Location = new System.Drawing.Point(509, 679);
            this.secondBox.Name = "secondBox";
            this.secondBox.Size = new System.Drawing.Size(144, 20);
            this.secondBox.TabIndex = 12;
            // 
            // PlayerGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(947, 802);
            this.Controls.Add(this.secondBox);
            this.Controls.Add(this.firstBox);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.Player2Ready);
            this.Controls.Add(this.Player1Ready);
            this.Controls.Add(this.Player2Label);
            this.Controls.Add(this.Player1Label);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.BackButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PlayerGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chess";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Label Player1Label;
        private System.Windows.Forms.Label Player2Label;
        private System.Windows.Forms.Label Player1Ready;
        private System.Windows.Forms.Label Player2Ready;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.MaskedTextBox firstBox;
        private System.Windows.Forms.MaskedTextBox secondBox;
    }
}


