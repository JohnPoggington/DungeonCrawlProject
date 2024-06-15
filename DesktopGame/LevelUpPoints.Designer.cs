namespace DungeonCrawlProject
{
    partial class LevelUpPoints
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
            AddStrButton = new Button();
            SubStrButton = new Button();
            StrengthLabel = new Label();
            AddDexButton = new Button();
            SubDexButton = new Button();
            DexterityLabel = new Label();
            label7 = new Label();
            label6 = new Label();
            label1 = new Label();
            CreatePlayerButton = new Button();
            PointsLabel = new Label();
            label8 = new Label();
            SuspendLayout();
            // 
            // AddStrButton
            // 
            AddStrButton.Enabled = false;
            AddStrButton.Location = new Point(152, 100);
            AddStrButton.Name = "AddStrButton";
            AddStrButton.Size = new Size(21, 23);
            AddStrButton.TabIndex = 24;
            AddStrButton.Text = "+";
            AddStrButton.UseVisualStyleBackColor = true;
            AddStrButton.Click += AddStrButton_Click;
            // 
            // SubStrButton
            // 
            SubStrButton.Enabled = false;
            SubStrButton.Location = new Point(106, 100);
            SubStrButton.Name = "SubStrButton";
            SubStrButton.Size = new Size(21, 23);
            SubStrButton.TabIndex = 23;
            SubStrButton.Text = "-";
            SubStrButton.UseVisualStyleBackColor = true;
            SubStrButton.Click += SubStrButton_Click;
            // 
            // StrengthLabel
            // 
            StrengthLabel.AutoSize = true;
            StrengthLabel.Location = new Point(133, 104);
            StrengthLabel.Name = "StrengthLabel";
            StrengthLabel.Size = new Size(13, 15);
            StrengthLabel.TabIndex = 22;
            StrengthLabel.Text = "0";
            // 
            // AddDexButton
            // 
            AddDexButton.Enabled = false;
            AddDexButton.Location = new Point(152, 71);
            AddDexButton.Name = "AddDexButton";
            AddDexButton.Size = new Size(21, 23);
            AddDexButton.TabIndex = 21;
            AddDexButton.Text = "+";
            AddDexButton.UseVisualStyleBackColor = true;
            AddDexButton.Click += AddDexButton_Click;
            // 
            // SubDexButton
            // 
            SubDexButton.Enabled = false;
            SubDexButton.Location = new Point(106, 71);
            SubDexButton.Name = "SubDexButton";
            SubDexButton.Size = new Size(21, 23);
            SubDexButton.TabIndex = 20;
            SubDexButton.Text = "-";
            SubDexButton.UseVisualStyleBackColor = true;
            SubDexButton.Click += SubDexButton_Click;
            // 
            // DexterityLabel
            // 
            DexterityLabel.AutoSize = true;
            DexterityLabel.Location = new Point(133, 75);
            DexterityLabel.Name = "DexterityLabel";
            DexterityLabel.Size = new Size(13, 15);
            DexterityLabel.TabIndex = 19;
            DexterityLabel.Text = "0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(42, 105);
            label7.Name = "label7";
            label7.Size = new Size(25, 15);
            label7.TabIndex = 18;
            label7.Text = "Siła";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(42, 75);
            label6.Name = "label6";
            label6.Size = new Size(60, 15);
            label6.TabIndex = 17;
            label6.Text = "Zręczność";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.Location = new Point(56, 20);
            label1.Name = "label1";
            label1.Size = new Size(117, 32);
            label1.TabIndex = 25;
            label1.Text = "Level up!";
            // 
            // CreatePlayerButton
            // 
            CreatePlayerButton.Location = new Point(82, 163);
            CreatePlayerButton.Name = "CreatePlayerButton";
            CreatePlayerButton.Size = new Size(75, 23);
            CreatePlayerButton.TabIndex = 28;
            CreatePlayerButton.Text = "Zatwierdź";
            CreatePlayerButton.UseVisualStyleBackColor = true;
            CreatePlayerButton.Click += CreatePlayerButton_Click;
            // 
            // PointsLabel
            // 
            PointsLabel.AutoSize = true;
            PointsLabel.Location = new Point(179, 138);
            PointsLabel.Name = "PointsLabel";
            PointsLabel.Size = new Size(13, 15);
            PointsLabel.TabIndex = 27;
            PointsLabel.Text = "0";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(62, 138);
            label8.Name = "label8";
            label8.Size = new Size(111, 15);
            label8.TabIndex = 26;
            label8.Text = "Pozostało punktów:";
            // 
            // LevelUpPoints
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(250, 198);
            Controls.Add(CreatePlayerButton);
            Controls.Add(PointsLabel);
            Controls.Add(label8);
            Controls.Add(label1);
            Controls.Add(AddStrButton);
            Controls.Add(SubStrButton);
            Controls.Add(StrengthLabel);
            Controls.Add(AddDexButton);
            Controls.Add(SubDexButton);
            Controls.Add(DexterityLabel);
            Controls.Add(label7);
            Controls.Add(label6);
            Name = "LevelUpPoints";
            Text = "LevelUpPoints";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AddStrButton;
        private Button SubStrButton;
        private Label StrengthLabel;
        private Button AddDexButton;
        private Button SubDexButton;
        private Label DexterityLabel;
        private Label label7;
        private Label label6;
        private Label label1;
        private Button CreatePlayerButton;
        private Label PointsLabel;
        private Label label8;
    }
}