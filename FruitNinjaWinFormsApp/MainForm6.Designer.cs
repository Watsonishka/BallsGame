namespace FruitNinjaWinFormsApp
{
    partial class MainForm6
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
            panel1 = new Panel();
            slowDownTimeLabel = new Label();
            startButton = new Button();
            restartButton = new Button();
            stopButton = new Button();
            scoreLabel = new Label();
            timer = new System.Windows.Forms.Timer(components);
            fruitGenerationTimer = new System.Windows.Forms.Timer(components);
            slowDownTimer = new System.Windows.Forms.Timer(components);
            slowFruitGenerationTimer = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonShadow;
            panel1.Controls.Add(slowDownTimeLabel);
            panel1.Controls.Add(startButton);
            panel1.Controls.Add(restartButton);
            panel1.Controls.Add(stopButton);
            panel1.Controls.Add(scoreLabel);
            panel1.Location = new Point(-5, 386);
            panel1.Name = "panel1";
            panel1.Size = new Size(806, 70);
            panel1.TabIndex = 0;
            // 
            // slowDownTimeLabel
            // 
            slowDownTimeLabel.AutoSize = true;
            slowDownTimeLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            slowDownTimeLabel.Location = new Point(267, 26);
            slowDownTimeLabel.Name = "slowDownTimeLabel";
            slowDownTimeLabel.Size = new Size(177, 20);
            slowDownTimeLabel.TabIndex = 4;
            slowDownTimeLabel.Text = "Замедление времени: 0";
            // 
            // startButton
            // 
            startButton.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            startButton.Location = new Point(512, 17);
            startButton.Name = "startButton";
            startButton.Size = new Size(86, 34);
            startButton.TabIndex = 3;
            startButton.Text = "Играть";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // restartButton
            // 
            restartButton.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            restartButton.Location = new Point(695, 17);
            restartButton.Name = "restartButton";
            restartButton.Size = new Size(98, 34);
            restartButton.TabIndex = 2;
            restartButton.Text = "Рестарт";
            restartButton.UseVisualStyleBackColor = true;
            restartButton.Click += restartButton_Click;
            // 
            // stopButton
            // 
            stopButton.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            stopButton.Location = new Point(614, 18);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(75, 34);
            stopButton.TabIndex = 1;
            stopButton.Text = "Стоп";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += stopButton_Click;
            // 
            // scoreLabel
            // 
            scoreLabel.AutoSize = true;
            scoreLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            scoreLabel.Location = new Point(27, 25);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new Size(57, 20);
            scoreLabel.TabIndex = 0;
            scoreLabel.Text = "Счет: 0";
            // 
            // timer
            // 
            timer.Tick += timer_Tick;
            // 
            // fruitGenerationTimer
            // 
            fruitGenerationTimer.Interval = 2000;
            fruitGenerationTimer.Tick += fruitGenerationTimer_Tick;
            // 
            // slowDownTimer
            // 
            slowDownTimer.Interval = 150;
            slowDownTimer.Tick += slowDownTimer_Tick;
            // 
            // slowFruitGenerationTimer
            // 
            slowFruitGenerationTimer.Interval = 2500;
            slowFruitGenerationTimer.Tick += slowFruitGenerationTimer_Tick;
            // 
            // MainForm6
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm6";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Fruit Ninja";
            MouseMove += MainForm6_MouseMove;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label scoreLabel;
        private Button restartButton;
        private Button stopButton;
        private System.Windows.Forms.Timer timer;
        private Button startButton;
        private System.Windows.Forms.Timer fruitGenerationTimer;
        private System.Windows.Forms.Timer slowDownTimer;
        private System.Windows.Forms.Timer slowFruitGenerationTimer;
        private Label slowDownTimeLabel;
    }
}
