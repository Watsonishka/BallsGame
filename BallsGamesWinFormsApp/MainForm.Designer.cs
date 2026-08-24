namespace BallsGamesWinFormsApp
{
    partial class MainForm
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
            stop = new Button();
            generate = new Button();
            timer = new System.Windows.Forms.Timer(components);
            commonBallsCountLabel = new Label();
            catchBallsCountLabel = new Label();
            SuspendLayout();
            // 
            // stop
            // 
            stop.Font = new Font("Segoe UI", 12F);
            stop.ImageAlign = ContentAlignment.BottomRight;
            stop.Location = new Point(673, 490);
            stop.Name = "stop";
            stop.Size = new Size(151, 42);
            stop.TabIndex = 0;
            stop.Text = "Остановить";
            stop.UseVisualStyleBackColor = true;
            stop.Click += stop_Click;
            // 
            // generate
            // 
            generate.Font = new Font("Segoe UI", 12F);
            generate.ImageAlign = ContentAlignment.BottomRight;
            generate.Location = new Point(516, 490);
            generate.Name = "generate";
            generate.Size = new Size(151, 42);
            generate.TabIndex = 1;
            generate.Text = "Создать";
            generate.UseVisualStyleBackColor = true;
            generate.Click += generate_Click;
            // 
            // timer
            // 
            timer.Tick += timer_Tick;
            // 
            // commonBallsCountLabel
            // 
            commonBallsCountLabel.AutoSize = true;
            commonBallsCountLabel.Font = new Font("Segoe UI", 12F);
            commonBallsCountLabel.ImageAlign = ContentAlignment.BottomLeft;
            commonBallsCountLabel.Location = new Point(30, 490);
            commonBallsCountLabel.Name = "commonBallsCountLabel";
            commonBallsCountLabel.Size = new Size(124, 21);
            commonBallsCountLabel.TabIndex = 2;
            commonBallsCountLabel.Text = "Шаров создано:";
            // 
            // catchBallsCountLabel
            // 
            catchBallsCountLabel.AutoSize = true;
            catchBallsCountLabel.Font = new Font("Segoe UI", 12F);
            catchBallsCountLabel.ImageAlign = ContentAlignment.BottomLeft;
            catchBallsCountLabel.Location = new Point(30, 511);
            catchBallsCountLabel.Name = "catchBallsCountLabel";
            catchBallsCountLabel.Size = new Size(130, 21);
            catchBallsCountLabel.TabIndex = 3;
            catchBallsCountLabel.Text = "Шаров поймано:";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(855, 565);
            Controls.Add(catchBallsCountLabel);
            Controls.Add(commonBallsCountLabel);
            Controls.Add(generate);
            Controls.Add(stop);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Balls game";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button stop;
        private Button generate;
        private System.Windows.Forms.Timer timer;
        private Label commonBallsCountLabel;
        private Label catchBallsCountLabel;
    }
}
