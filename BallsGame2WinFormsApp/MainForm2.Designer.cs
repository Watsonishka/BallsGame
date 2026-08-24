namespace BallsGame2WinFormsApp
{
    partial class MainForm2
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            catchBallsCountLabel = new Label();
            commonBallsCountLabel = new Label();
            generate = new Button();
            timer = new System.Windows.Forms.Timer(components);
            panel = new Panel();
            restartButton = new Button();
            roundLabel = new Label();
            panel.SuspendLayout();
            SuspendLayout();
            // 
            // catchBallsCountLabel
            // 
            catchBallsCountLabel.AutoSize = true;
            catchBallsCountLabel.Font = new Font("Segoe UI", 12F);
            catchBallsCountLabel.ImageAlign = ContentAlignment.BottomLeft;
            catchBallsCountLabel.Location = new Point(31, 37);
            catchBallsCountLabel.Name = "catchBallsCountLabel";
            catchBallsCountLabel.Size = new Size(130, 21);
            catchBallsCountLabel.TabIndex = 6;
            catchBallsCountLabel.Text = "Шаров поймано:";
            // 
            // commonBallsCountLabel
            // 
            commonBallsCountLabel.AutoSize = true;
            commonBallsCountLabel.Font = new Font("Segoe UI", 12F);
            commonBallsCountLabel.ImageAlign = ContentAlignment.BottomLeft;
            commonBallsCountLabel.Location = new Point(31, 16);
            commonBallsCountLabel.Name = "commonBallsCountLabel";
            commonBallsCountLabel.Size = new Size(124, 21);
            commonBallsCountLabel.TabIndex = 5;
            commonBallsCountLabel.Text = "Шаров создано:";
            // 
            // generate
            // 
            generate.Font = new Font("Segoe UI", 12F);
            generate.ImageAlign = ContentAlignment.BottomRight;
            generate.Location = new Point(614, 18);
            generate.Name = "generate";
            generate.Size = new Size(124, 42);
            generate.TabIndex = 4;
            generate.Text = "Начать раунд";
            generate.UseVisualStyleBackColor = true;
            generate.Click += generate_Click;
            // 
            // timer
            // 
            timer.Tick += timer_Tick;
            // 
            // panel
            // 
            panel.BackColor = Color.Silver;
            panel.Controls.Add(restartButton);
            panel.Controls.Add(roundLabel);
            panel.Controls.Add(catchBallsCountLabel);
            panel.Controls.Add(generate);
            panel.Controls.Add(commonBallsCountLabel);
            panel.Location = new Point(0, 496);
            panel.Name = "panel";
            panel.Size = new Size(859, 76);
            panel.TabIndex = 7;
            // 
            // restartButton
            // 
            restartButton.Font = new Font("Segoe UI", 12F);
            restartButton.ImageAlign = ContentAlignment.BottomRight;
            restartButton.Location = new Point(744, 18);
            restartButton.Name = "restartButton";
            restartButton.Size = new Size(99, 42);
            restartButton.TabIndex = 8;
            restartButton.Text = "Рестарт";
            restartButton.UseVisualStyleBackColor = true;
            restartButton.Click += restartButton_Click;
            // 
            // roundLabel
            // 
            roundLabel.AutoSize = true;
            roundLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            roundLabel.Location = new Point(357, 16);
            roundLabel.Name = "roundLabel";
            roundLabel.Size = new Size(104, 37);
            roundLabel.TabIndex = 7;
            roundLabel.Text = "Раунд ";
            // 
            // MainForm2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(855, 565);
            Controls.Add(panel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Balls game 2";
            FormClosing += MainForm2_FormClosing;
            MouseDown += MainForm2_MouseDown;
            panel.ResumeLayout(false);
            panel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label catchBallsCountLabel;
        private Label commonBallsCountLabel;
        private Button generate;
        private System.Windows.Forms.Timer timer;
        private Panel panel;
        private Label roundLabel;
        private Button restartButton;
    }
}
