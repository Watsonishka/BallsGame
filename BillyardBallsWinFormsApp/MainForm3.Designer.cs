namespace BillyardBallsWinFormsApp
{
    partial class MainForm3
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
            TopLabel = new Label();
            DownLabel = new Label();
            LeftLabel = new Label();
            RightLabel = new Label();
            generateButton = new Button();
            moveButton = new Button();
            timer = new System.Windows.Forms.Timer(components);
            stopButton = new Button();
            panel = new Panel();
            panel.SuspendLayout();
            SuspendLayout();
            // 
            // TopLabel
            // 
            TopLabel.AutoSize = true;
            TopLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            TopLabel.Location = new Point(384, 9);
            TopLabel.Name = "TopLabel";
            TopLabel.Size = new Size(17, 20);
            TopLabel.TabIndex = 0;
            TopLabel.Text = "0";
            // 
            // DownLabel
            // 
            DownLabel.AutoSize = true;
            DownLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            DownLabel.Location = new Point(384, 374);
            DownLabel.Name = "DownLabel";
            DownLabel.Size = new Size(17, 20);
            DownLabel.TabIndex = 1;
            DownLabel.Text = "0";
            // 
            // LeftLabel
            // 
            LeftLabel.AutoSize = true;
            LeftLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LeftLabel.Location = new Point(12, 186);
            LeftLabel.Name = "LeftLabel";
            LeftLabel.Size = new Size(17, 20);
            LeftLabel.TabIndex = 2;
            LeftLabel.Text = "0";
            // 
            // RightLabel
            // 
            RightLabel.AutoSize = true;
            RightLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            RightLabel.Location = new Point(771, 186);
            RightLabel.Name = "RightLabel";
            RightLabel.Size = new Size(17, 20);
            RightLabel.TabIndex = 3;
            RightLabel.Text = "0";
            // 
            // generateButton
            // 
            generateButton.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            generateButton.Location = new Point(211, 13);
            generateButton.Name = "generateButton";
            generateButton.Size = new Size(116, 28);
            generateButton.TabIndex = 4;
            generateButton.Text = "Сгенерировать";
            generateButton.UseVisualStyleBackColor = true;
            generateButton.Click += generateButton_Click_1;
            // 
            // moveButton
            // 
            moveButton.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            moveButton.Location = new Point(333, 13);
            moveButton.Name = "moveButton";
            moveButton.Size = new Size(116, 28);
            moveButton.TabIndex = 6;
            moveButton.Text = "Старт";
            moveButton.UseVisualStyleBackColor = true;
            moveButton.Click += moveButton_Click;
            // 
            // timer
            // 
            timer.Tick += timer_Tick;
            // 
            // stopButton
            // 
            stopButton.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            stopButton.Location = new Point(455, 13);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(116, 28);
            stopButton.TabIndex = 7;
            stopButton.Text = "Стоп";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += stopButton_Click;
            // 
            // panel
            // 
            panel.BackColor = Color.DarkGray;
            panel.Controls.Add(generateButton);
            panel.Controls.Add(stopButton);
            panel.Controls.Add(moveButton);
            panel.Location = new Point(0, 397);
            panel.Name = "panel";
            panel.Size = new Size(802, 58);
            panel.TabIndex = 8;
            // 
            // MainForm3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(800, 450);
            Controls.Add(panel);
            Controls.Add(RightLabel);
            Controls.Add(LeftLabel);
            Controls.Add(DownLabel);
            Controls.Add(TopLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm3";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Billyard Balls";
            panel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TopLabel;
        private Label DownLabel;
        private Label LeftLabel;
        private Label RightLabel;
        private Button generateButton;
        private Button moveButton;
        private System.Windows.Forms.Timer timer;
        private Button stopButton;
        private Panel panel;
    }
}
