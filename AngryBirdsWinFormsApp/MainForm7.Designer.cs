namespace AngryBirdsWinFormsApp
{
    partial class MainForm7
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
            scoreLabel = new Label();
            timer = new System.Windows.Forms.Timer(components);
            attemptCountLabel = new Label();
            roundLabel = new Label();
            pigsCountLabel = new Label();
            restartButton = new Button();
            SuspendLayout();
            // 
            // scoreLabel
            // 
            scoreLabel.AutoSize = true;
            scoreLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            scoreLabel.Location = new Point(12, 36);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new Size(62, 21);
            scoreLabel.TabIndex = 0;
            scoreLabel.Text = "Счет: 0";
            // 
            // timer
            // 
            timer.Interval = 20;
            timer.Tick += timer_Tick;
            // 
            // attemptCountLabel
            // 
            attemptCountLabel.AutoSize = true;
            attemptCountLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            attemptCountLabel.Location = new Point(286, 15);
            attemptCountLabel.Name = "attemptCountLabel";
            attemptCountLabel.Size = new Size(192, 21);
            attemptCountLabel.TabIndex = 1;
            attemptCountLabel.Text = "Количество попыток:  0";
            // 
            // roundLabel
            // 
            roundLabel.AutoSize = true;
            roundLabel.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            roundLabel.Location = new Point(657, 15);
            roundLabel.Name = "roundLabel";
            roundLabel.Size = new Size(77, 25);
            roundLabel.TabIndex = 2;
            roundLabel.Text = "Раунд 1";
            // 
            // pigsCountLabel
            // 
            pigsCountLabel.AutoSize = true;
            pigsCountLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            pigsCountLabel.Location = new Point(12, 15);
            pigsCountLabel.Name = "pigsCountLabel";
            pigsCountLabel.Size = new Size(235, 21);
            pigsCountLabel.TabIndex = 3;
            pigsCountLabel.Text = "Количество сбитых свиней: 0";
            // 
            // restartButton
            // 
            restartButton.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            restartButton.Location = new Point(692, 400);
            restartButton.Name = "restartButton";
            restartButton.Size = new Size(83, 30);
            restartButton.TabIndex = 4;
            restartButton.Text = "Рестарт";
            restartButton.UseVisualStyleBackColor = true;
            restartButton.Click += restartButton_Click;
            // 
            // MainForm7
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(800, 450);
            Controls.Add(restartButton);
            Controls.Add(pigsCountLabel);
            Controls.Add(roundLabel);
            Controls.Add(attemptCountLabel);
            Controls.Add(scoreLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MinimizeBox = false;
            Name = "MainForm7";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Angry Birds";
            MouseDown += MainForm7_MouseDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label scoreLabel;
        private System.Windows.Forms.Timer timer;
        private Label attemptCountLabel;
        private Label roundLabel;
        private Label pigsCountLabel;
        private Button restartButton;
    }
}
