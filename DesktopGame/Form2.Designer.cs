namespace DungeonCrawlProject
{
    partial class Form2
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
            label1 = new Label();
            label2 = new Label();
            WarriorButton = new RadioButton();
            NameInput = new TextBox();
            groupBox1 = new GroupBox();
            RogueButton = new RadioButton();
            MonkButton = new RadioButton();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            HPLabel = new Label();
            ManaLabel = new Label();
            DexterityLabel = new Label();
            SubDexButton = new Button();
            AddDexButton = new Button();
            AddStrButton = new Button();
            SubStrButton = new Button();
            StrengthLabel = new Label();
            label8 = new Label();
            PointsLabel = new Label();
            CreatePlayerButton = new Button();
            FireResistLabel = new Label();
            MagicResistLabel = new Label();
            PhysResistLabel = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.Location = new Point(21, 28);
            label1.Name = "label1";
            label1.Size = new Size(228, 32);
            label1.TabIndex = 0;
            label1.Text = "Create a character!";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 99);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 1;
            label2.Text = "Nazwa";
            // 
            // WarriorButton
            // 
            WarriorButton.AutoSize = true;
            WarriorButton.Location = new Point(6, 22);
            WarriorButton.Name = "WarriorButton";
            WarriorButton.Size = new Size(78, 19);
            WarriorButton.TabIndex = 2;
            WarriorButton.TabStop = true;
            WarriorButton.Text = "Wojownik";
            WarriorButton.UseVisualStyleBackColor = true;
            WarriorButton.CheckedChanged += WarriorButton_CheckedChanged;
            // 
            // NameInput
            // 
            NameInput.Location = new Point(80, 96);
            NameInput.Name = "NameInput";
            NameInput.Size = new Size(100, 23);
            NameInput.TabIndex = 3;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(RogueButton);
            groupBox1.Controls.Add(MonkButton);
            groupBox1.Controls.Add(WarriorButton);
            groupBox1.Location = new Point(32, 145);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(121, 98);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Klasy";
            // 
            // RogueButton
            // 
            RogueButton.AutoSize = true;
            RogueButton.Location = new Point(6, 72);
            RogueButton.Name = "RogueButton";
            RogueButton.Size = new Size(66, 19);
            RogueButton.TabIndex = 4;
            RogueButton.TabStop = true;
            RogueButton.Text = "Złodziej";
            RogueButton.UseVisualStyleBackColor = true;
            RogueButton.CheckedChanged += RogueButton_CheckedChanged;
            // 
            // MonkButton
            // 
            MonkButton.AutoSize = true;
            MonkButton.Location = new Point(6, 47);
            MonkButton.Name = "MonkButton";
            MonkButton.Size = new Size(59, 19);
            MonkButton.TabIndex = 3;
            MonkButton.TabStop = true;
            MonkButton.Text = "Mnich";
            MonkButton.UseVisualStyleBackColor = true;
            MonkButton.CheckedChanged += MonkButton_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 127);
            label3.Name = "label3";
            label3.Size = new Size(119, 15);
            label3.TabIndex = 3;
            label3.Text = "Wybierz klasę postaci";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 257);
            label4.Name = "label4";
            label4.Size = new Size(23, 15);
            label4.TabIndex = 5;
            label4.Text = "HP";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(31, 272);
            label5.Name = "label5";
            label5.Size = new Size(37, 15);
            label5.TabIndex = 6;
            label5.Text = "Mana";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(32, 384);
            label6.Name = "label6";
            label6.Size = new Size(60, 15);
            label6.TabIndex = 7;
            label6.Text = "Zręczność";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(32, 414);
            label7.Name = "label7";
            label7.Size = new Size(25, 15);
            label7.TabIndex = 8;
            label7.Text = "Siła";
            label7.Click += label7_Click;
            // 
            // HPLabel
            // 
            HPLabel.AutoSize = true;
            HPLabel.Location = new Point(81, 257);
            HPLabel.Name = "HPLabel";
            HPLabel.Size = new Size(13, 15);
            HPLabel.TabIndex = 9;
            HPLabel.Text = "0";
            // 
            // ManaLabel
            // 
            ManaLabel.AutoSize = true;
            ManaLabel.Location = new Point(81, 272);
            ManaLabel.Name = "ManaLabel";
            ManaLabel.Size = new Size(13, 15);
            ManaLabel.TabIndex = 10;
            ManaLabel.Text = "0";
            // 
            // DexterityLabel
            // 
            DexterityLabel.AutoSize = true;
            DexterityLabel.Location = new Point(123, 384);
            DexterityLabel.Name = "DexterityLabel";
            DexterityLabel.Size = new Size(13, 15);
            DexterityLabel.TabIndex = 11;
            DexterityLabel.Text = "0";
            // 
            // SubDexButton
            // 
            SubDexButton.Enabled = false;
            SubDexButton.Location = new Point(96, 380);
            SubDexButton.Name = "SubDexButton";
            SubDexButton.Size = new Size(21, 23);
            SubDexButton.TabIndex = 12;
            SubDexButton.Text = "-";
            SubDexButton.UseVisualStyleBackColor = true;
            SubDexButton.Click += SubDexButton_Click;
            // 
            // AddDexButton
            // 
            AddDexButton.Enabled = false;
            AddDexButton.Location = new Point(142, 380);
            AddDexButton.Name = "AddDexButton";
            AddDexButton.Size = new Size(21, 23);
            AddDexButton.TabIndex = 13;
            AddDexButton.Text = "+";
            AddDexButton.UseVisualStyleBackColor = true;
            AddDexButton.Click += AddDexButton_Click;
            // 
            // AddStrButton
            // 
            AddStrButton.Enabled = false;
            AddStrButton.Location = new Point(142, 409);
            AddStrButton.Name = "AddStrButton";
            AddStrButton.Size = new Size(21, 23);
            AddStrButton.TabIndex = 16;
            AddStrButton.Text = "+";
            AddStrButton.UseVisualStyleBackColor = true;
            AddStrButton.Click += AddStrButton_Click;
            // 
            // SubStrButton
            // 
            SubStrButton.Enabled = false;
            SubStrButton.Location = new Point(96, 409);
            SubStrButton.Name = "SubStrButton";
            SubStrButton.Size = new Size(21, 23);
            SubStrButton.TabIndex = 15;
            SubStrButton.Text = "-";
            SubStrButton.UseVisualStyleBackColor = true;
            SubStrButton.Click += SubStrButton_Click;
            // 
            // StrengthLabel
            // 
            StrengthLabel.AutoSize = true;
            StrengthLabel.Location = new Point(123, 413);
            StrengthLabel.Name = "StrengthLabel";
            StrengthLabel.Size = new Size(13, 15);
            StrengthLabel.TabIndex = 14;
            StrengthLabel.Text = "0";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(33, 455);
            label8.Name = "label8";
            label8.Size = new Size(111, 15);
            label8.TabIndex = 17;
            label8.Text = "Pozostało punktów:";
            // 
            // PointsLabel
            // 
            PointsLabel.AutoSize = true;
            PointsLabel.Location = new Point(143, 455);
            PointsLabel.Name = "PointsLabel";
            PointsLabel.Size = new Size(13, 15);
            PointsLabel.TabIndex = 18;
            PointsLabel.Text = "0";
            // 
            // CreatePlayerButton
            // 
            CreatePlayerButton.Location = new Point(96, 490);
            CreatePlayerButton.Name = "CreatePlayerButton";
            CreatePlayerButton.Size = new Size(75, 23);
            CreatePlayerButton.TabIndex = 19;
            CreatePlayerButton.Text = "Zatwierdź";
            CreatePlayerButton.UseVisualStyleBackColor = true;
            CreatePlayerButton.Click += CreatePlayerButton_Click;
            // 
            // FireResistLabel
            // 
            FireResistLabel.AutoSize = true;
            FireResistLabel.Location = new Point(98, 341);
            FireResistLabel.Name = "FireResistLabel";
            FireResistLabel.Size = new Size(23, 15);
            FireResistLabel.TabIndex = 26;
            FireResistLabel.Text = "FIR";
            // 
            // MagicResistLabel
            // 
            MagicResistLabel.AutoSize = true;
            MagicResistLabel.Location = new Point(98, 326);
            MagicResistLabel.Name = "MagicResistLabel";
            MagicResistLabel.Size = new Size(34, 15);
            MagicResistLabel.TabIndex = 25;
            MagicResistLabel.Text = "MAG";
            // 
            // PhysResistLabel
            // 
            PhysResistLabel.AutoSize = true;
            PhysResistLabel.Location = new Point(98, 311);
            PhysResistLabel.Name = "PhysResistLabel";
            PhysResistLabel.Size = new Size(36, 15);
            PhysResistLabel.TabIndex = 24;
            PhysResistLabel.Text = "PHYS";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(40, 341);
            label9.Name = "label9";
            label9.Size = new Size(39, 15);
            label9.TabIndex = 23;
            label9.Text = "Ogień";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(40, 326);
            label10.Name = "label10";
            label10.Size = new Size(58, 15);
            label10.TabIndex = 22;
            label10.Text = "Magiczne";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(40, 311);
            label11.Name = "label11";
            label11.Size = new Size(51, 15);
            label11.TabIndex = 21;
            label11.Text = "Fizyczne";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(31, 296);
            label12.Name = "label12";
            label12.Size = new Size(139, 15);
            label12.TabIndex = 20;
            label12.Text = "Odporności na obrażenia";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(273, 525);
            Controls.Add(FireResistLabel);
            Controls.Add(MagicResistLabel);
            Controls.Add(PhysResistLabel);
            Controls.Add(label9);
            Controls.Add(label10);
            Controls.Add(label11);
            Controls.Add(label12);
            Controls.Add(CreatePlayerButton);
            Controls.Add(PointsLabel);
            Controls.Add(label8);
            Controls.Add(AddStrButton);
            Controls.Add(SubStrButton);
            Controls.Add(StrengthLabel);
            Controls.Add(AddDexButton);
            Controls.Add(SubDexButton);
            Controls.Add(DexterityLabel);
            Controls.Add(ManaLabel);
            Controls.Add(HPLabel);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(groupBox1);
            Controls.Add(NameInput);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form2";
            Text = "Form2";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private RadioButton WarriorButton;
        private TextBox NameInput;
        private GroupBox groupBox1;
        private Label label3;
        private RadioButton RogueButton;
        private RadioButton MonkButton;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label HPLabel;
        private Label ManaLabel;
        private Label DexterityLabel;
        private Button SubDexButton;
        private Button AddDexButton;
        private Button AddStrButton;
        private Button SubStrButton;
        private Label StrengthLabel;
        private Label label8;
        private Label PointsLabel;
        private Button CreatePlayerButton;
        private Label FireResistLabel;
        private Label MagicResistLabel;
        private Label PhysResistLabel;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
    }
}