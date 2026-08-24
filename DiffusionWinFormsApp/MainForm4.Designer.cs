namespace DiffusionWinFormsApp
{
    partial class MainForm4
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
            timer = new System.Windows.Forms.Timer(components);
            panel1 = new Panel();
            greenDownLabel = new Label();
            greenTopLabel = new Label();
            greenRightLabel = new Label();
            greenLeftLabel = new Label();
            pinkTopLabel = new Label();
            pinkDownLabel = new Label();
            pinkLeftLabel = new Label();
            pinkRightLabel = new Label();
            SuspendLayout();
            // 
            // timer
            // 
            timer.Tick += timer_Tick;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gray;
            panel1.Location = new Point(420, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(10, 534);
            panel1.TabIndex = 8;
            // 
            // greenDownLabel
            // 
            greenDownLabel.AutoSize = true;
            greenDownLabel.BackColor = Color.Aquamarine;
            greenDownLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            greenDownLabel.Location = new Point(445, 503);
            greenDownLabel.Name = "greenDownLabel";
            greenDownLabel.Size = new Size(17, 20);
            greenDownLabel.TabIndex = 10;
            greenDownLabel.Text = "0";
            // 
            // greenTopLabel
            // 
            greenTopLabel.AutoSize = true;
            greenTopLabel.BackColor = Color.Aquamarine;
            greenTopLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            greenTopLabel.Location = new Point(445, 9);
            greenTopLabel.Name = "greenTopLabel";
            greenTopLabel.Size = new Size(17, 20);
            greenTopLabel.TabIndex = 9;
            greenTopLabel.Text = "0";
            // 
            // greenRightLabel
            // 
            greenRightLabel.AutoSize = true;
            greenRightLabel.BackColor = Color.Aquamarine;
            greenRightLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            greenRightLabel.Location = new Point(792, 234);
            greenRightLabel.Name = "greenRightLabel";
            greenRightLabel.Size = new Size(17, 20);
            greenRightLabel.TabIndex = 12;
            greenRightLabel.Text = "0";
            // 
            // greenLeftLabel
            // 
            greenLeftLabel.AutoSize = true;
            greenLeftLabel.BackColor = Color.Aquamarine;
            greenLeftLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            greenLeftLabel.Location = new Point(12, 234);
            greenLeftLabel.Name = "greenLeftLabel";
            greenLeftLabel.Size = new Size(17, 20);
            greenLeftLabel.TabIndex = 11;
            greenLeftLabel.Text = "0";
            // 
            // pinkTopLabel
            // 
            pinkTopLabel.AutoSize = true;
            pinkTopLabel.BackColor = Color.LightCoral;
            pinkTopLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            pinkTopLabel.Location = new Point(358, 9);
            pinkTopLabel.Name = "pinkTopLabel";
            pinkTopLabel.Size = new Size(17, 20);
            pinkTopLabel.TabIndex = 13;
            pinkTopLabel.Text = "0";
            // 
            // pinkDownLabel
            // 
            pinkDownLabel.AutoSize = true;
            pinkDownLabel.BackColor = Color.LightCoral;
            pinkDownLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            pinkDownLabel.Location = new Point(358, 503);
            pinkDownLabel.Name = "pinkDownLabel";
            pinkDownLabel.Size = new Size(17, 20);
            pinkDownLabel.TabIndex = 15;
            pinkDownLabel.Text = "0";
            // 
            // pinkLeftLabel
            // 
            pinkLeftLabel.AutoSize = true;
            pinkLeftLabel.BackColor = Color.LightCoral;
            pinkLeftLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            pinkLeftLabel.Location = new Point(12, 267);
            pinkLeftLabel.Name = "pinkLeftLabel";
            pinkLeftLabel.Size = new Size(17, 20);
            pinkLeftLabel.TabIndex = 16;
            pinkLeftLabel.Text = "0";
            // 
            // pinkRightLabel
            // 
            pinkRightLabel.AutoSize = true;
            pinkRightLabel.BackColor = Color.LightCoral;
            pinkRightLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            pinkRightLabel.Location = new Point(791, 267);
            pinkRightLabel.Name = "pinkRightLabel";
            pinkRightLabel.Size = new Size(17, 20);
            pinkRightLabel.TabIndex = 17;
            pinkRightLabel.Text = "0";
            // 
            // MainForm4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(820, 526);
            Controls.Add(pinkRightLabel);
            Controls.Add(pinkLeftLabel);
            Controls.Add(pinkDownLabel);
            Controls.Add(pinkTopLabel);
            Controls.Add(greenRightLabel);
            Controls.Add(greenLeftLabel);
            Controls.Add(greenDownLabel);
            Controls.Add(greenTopLabel);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm4";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Diffuse";
            MouseDown += MainForm4_MouseDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label RightLabel;
        private Label LeftLabel;
        private Label DownLabel;
        private Label TopLabel;
        private System.Windows.Forms.Timer timer;
        private Panel panel1;
        private Label greenDownLabel;
        private Label greenTopLabel;
        private Label greenRightLabel;
        private Label greenLeftLabel;
        private Label pinkTopLabel;
        private Label pinkDownLabel;
        private Label pinkLeftLabel;
        private Label pinkRightLabel;
    }
}
