namespace DungeonCrawlProject
{
    partial class Form1
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
            listBox1 = new ListBox();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            TileTable = new TableLayoutPanel();
            MovementBox = new GroupBox();
            MoveEast = new Button();
            MoveSouth = new Button();
            MoveWest = new Button();
            MoveNorth = new Button();
            PlayerStats = new GroupBox();
            TotalXPLabel = new Label();
            label11 = new Label();
            StrengthLabel = new Label();
            DexterityLabel = new Label();
            label10 = new Label();
            label9 = new Label();
            FireResistLabel = new Label();
            MagicResistLabel = new Label();
            PhysResistLabel = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            XPLabel = new Label();
            label4 = new Label();
            LevelLabel = new Label();
            label3 = new Label();
            ManaBar = new ProgressBar();
            label2 = new Label();
            HealthBar = new ProgressBar();
            label1 = new Label();
            ItemTable = new TableLayoutPanel();
            button2 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            MovementBox.SuspendLayout();
            PlayerStats.SuspendLayout();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBox1.FormattingEnabled = true;
            listBox1.HorizontalScrollbar = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(10, 9);
            listBox1.Margin = new Padding(3, 2, 3, 2);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(243, 574);
            listBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(257, 9);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(75, 21);
            button1.TabIndex = 1;
            button1.Text = "Generuj";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(541, 9);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(160, 137);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // TileTable
            // 
            TileTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            TileTable.AutoScroll = true;
            TileTable.ColumnCount = 1;
            TileTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 885F));
            TileTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 18F));
            TileTable.Location = new Point(704, 9);
            TileTable.Margin = new Padding(0);
            TileTable.Name = "TileTable";
            TileTable.RowCount = 1;
            TileTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 570F));
            TileTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 570F));
            TileTable.Size = new Size(614, 593);
            TileTable.TabIndex = 3;
            // 
            // MovementBox
            // 
            MovementBox.Controls.Add(MoveEast);
            MovementBox.Controls.Add(MoveSouth);
            MovementBox.Controls.Add(MoveWest);
            MovementBox.Controls.Add(MoveNorth);
            MovementBox.Enabled = false;
            MovementBox.Location = new Point(263, 418);
            MovementBox.Name = "MovementBox";
            MovementBox.Size = new Size(121, 149);
            MovementBox.TabIndex = 4;
            MovementBox.TabStop = false;
            MovementBox.Text = "Ruch";
            // 
            // MoveEast
            // 
            MoveEast.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            MoveEast.Location = new Point(72, 58);
            MoveEast.Name = "MoveEast";
            MoveEast.Size = new Size(49, 37);
            MoveEast.TabIndex = 3;
            MoveEast.Text = "E";
            MoveEast.UseVisualStyleBackColor = true;
            MoveEast.Click += MoveEast_Click;
            // 
            // MoveSouth
            // 
            MoveSouth.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            MoveSouth.Location = new Point(46, 106);
            MoveSouth.Name = "MoveSouth";
            MoveSouth.Size = new Size(29, 37);
            MoveSouth.TabIndex = 2;
            MoveSouth.Text = "S";
            MoveSouth.UseVisualStyleBackColor = true;
            MoveSouth.Click += MoveSouth_Click;
            // 
            // MoveWest
            // 
            MoveWest.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            MoveWest.Location = new Point(12, 58);
            MoveWest.Name = "MoveWest";
            MoveWest.Size = new Size(39, 37);
            MoveWest.TabIndex = 1;
            MoveWest.Text = "W";
            MoveWest.UseVisualStyleBackColor = true;
            MoveWest.Click += MoveWest_Click;
            // 
            // MoveNorth
            // 
            MoveNorth.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            MoveNorth.Location = new Point(52, 12);
            MoveNorth.Name = "MoveNorth";
            MoveNorth.Size = new Size(29, 40);
            MoveNorth.TabIndex = 0;
            MoveNorth.Text = "N";
            MoveNorth.UseVisualStyleBackColor = true;
            MoveNorth.Click += MoveNorth_Click;
            // 
            // PlayerStats
            // 
            PlayerStats.Controls.Add(TotalXPLabel);
            PlayerStats.Controls.Add(label11);
            PlayerStats.Controls.Add(StrengthLabel);
            PlayerStats.Controls.Add(DexterityLabel);
            PlayerStats.Controls.Add(label10);
            PlayerStats.Controls.Add(label9);
            PlayerStats.Controls.Add(FireResistLabel);
            PlayerStats.Controls.Add(MagicResistLabel);
            PlayerStats.Controls.Add(PhysResistLabel);
            PlayerStats.Controls.Add(label8);
            PlayerStats.Controls.Add(label7);
            PlayerStats.Controls.Add(label6);
            PlayerStats.Controls.Add(label5);
            PlayerStats.Controls.Add(XPLabel);
            PlayerStats.Controls.Add(label4);
            PlayerStats.Controls.Add(LevelLabel);
            PlayerStats.Controls.Add(label3);
            PlayerStats.Controls.Add(ManaBar);
            PlayerStats.Controls.Add(label2);
            PlayerStats.Controls.Add(HealthBar);
            PlayerStats.Controls.Add(label1);
            PlayerStats.Location = new Point(257, 36);
            PlayerStats.Margin = new Padding(3, 2, 3, 2);
            PlayerStats.Name = "PlayerStats";
            PlayerStats.Padding = new Padding(3, 2, 3, 2);
            PlayerStats.Size = new Size(157, 245);
            PlayerStats.TabIndex = 5;
            PlayerStats.TabStop = false;
            PlayerStats.Text = "Postać";
            PlayerStats.Visible = false;
            // 
            // TotalXPLabel
            // 
            TotalXPLabel.AutoSize = true;
            TotalXPLabel.Location = new Point(72, 114);
            TotalXPLabel.Name = "TotalXPLabel";
            TotalXPLabel.Size = new Size(39, 15);
            TotalXPLabel.TabIndex = 20;
            TotalXPLabel.Text = "TOTAL";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(6, 114);
            label11.Name = "label11";
            label11.Size = new Size(60, 15);
            label11.TabIndex = 19;
            label11.Text = "XP łącznie";
            // 
            // StrengthLabel
            // 
            StrengthLabel.AutoSize = true;
            StrengthLabel.Location = new Point(72, 226);
            StrengthLabel.Name = "StrengthLabel";
            StrengthLabel.Size = new Size(26, 15);
            StrengthLabel.TabIndex = 18;
            StrengthLabel.Text = "STR";
            // 
            // DexterityLabel
            // 
            DexterityLabel.AutoSize = true;
            DexterityLabel.Location = new Point(72, 201);
            DexterityLabel.Name = "DexterityLabel";
            DexterityLabel.Size = new Size(28, 15);
            DexterityLabel.TabIndex = 17;
            DexterityLabel.Text = "DEX";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 226);
            label10.Name = "label10";
            label10.Size = new Size(25, 15);
            label10.TabIndex = 16;
            label10.Text = "Siła";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 201);
            label9.Name = "label9";
            label9.Size = new Size(60, 15);
            label9.TabIndex = 15;
            label9.Text = "Zręczność";
            // 
            // FireResistLabel
            // 
            FireResistLabel.AutoSize = true;
            FireResistLabel.Location = new Point(73, 174);
            FireResistLabel.Name = "FireResistLabel";
            FireResistLabel.Size = new Size(23, 15);
            FireResistLabel.TabIndex = 14;
            FireResistLabel.Text = "FIR";
            // 
            // MagicResistLabel
            // 
            MagicResistLabel.AutoSize = true;
            MagicResistLabel.Location = new Point(73, 159);
            MagicResistLabel.Name = "MagicResistLabel";
            MagicResistLabel.Size = new Size(34, 15);
            MagicResistLabel.TabIndex = 13;
            MagicResistLabel.Text = "MAG";
            // 
            // PhysResistLabel
            // 
            PhysResistLabel.AutoSize = true;
            PhysResistLabel.Location = new Point(73, 144);
            PhysResistLabel.Name = "PhysResistLabel";
            PhysResistLabel.Size = new Size(36, 15);
            PhysResistLabel.TabIndex = 12;
            PhysResistLabel.Text = "PHYS";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(15, 174);
            label8.Name = "label8";
            label8.Size = new Size(39, 15);
            label8.TabIndex = 11;
            label8.Text = "Ogień";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(15, 159);
            label7.Name = "label7";
            label7.Size = new Size(58, 15);
            label7.TabIndex = 10;
            label7.Text = "Magiczne";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 144);
            label6.Name = "label6";
            label6.Size = new Size(51, 15);
            label6.TabIndex = 9;
            label6.Text = "Fizyczne";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 129);
            label5.Name = "label5";
            label5.Size = new Size(139, 15);
            label5.TabIndex = 8;
            label5.Text = "Odporności na obrażenia";
            // 
            // XPLabel
            // 
            XPLabel.AutoSize = true;
            XPLabel.Location = new Point(33, 95);
            XPLabel.Name = "XPLabel";
            XPLabel.Size = new Size(27, 15);
            XPLabel.TabIndex = 7;
            XPLabel.Text = "EXP";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 95);
            label4.Name = "label4";
            label4.Size = new Size(21, 15);
            label4.TabIndex = 6;
            label4.Text = "XP";
            // 
            // LevelLabel
            // 
            LevelLabel.AutoSize = true;
            LevelLabel.Location = new Point(59, 68);
            LevelLabel.Name = "LevelLabel";
            LevelLabel.Size = new Size(31, 15);
            LevelLabel.TabIndex = 5;
            LevelLabel.Text = "level";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 68);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 4;
            label3.Text = "Poziom";
            // 
            // ManaBar
            // 
            ManaBar.Location = new Point(45, 41);
            ManaBar.Name = "ManaBar";
            ManaBar.Size = new Size(100, 15);
            ManaBar.Style = ProgressBarStyle.Continuous;
            ManaBar.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(5, 41);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 2;
            label2.Text = "Mana";
            // 
            // HealthBar
            // 
            HealthBar.ForeColor = Color.Red;
            HealthBar.Location = new Point(45, 15);
            HealthBar.Margin = new Padding(3, 2, 3, 2);
            HealthBar.Name = "HealthBar";
            HealthBar.Size = new Size(101, 15);
            HealthBar.Style = ProgressBarStyle.Continuous;
            HealthBar.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(4, 15);
            label1.Name = "label1";
            label1.Size = new Size(23, 15);
            label1.TabIndex = 0;
            label1.Text = "HP";
            // 
            // ItemTable
            // 
            ItemTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            ItemTable.ColumnCount = 8;
            ItemTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            ItemTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            ItemTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            ItemTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            ItemTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            ItemTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            ItemTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            ItemTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            ItemTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            ItemTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            ItemTable.Location = new Point(263, 286);
            ItemTable.Name = "ItemTable";
            ItemTable.RowCount = 8;
            ItemTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            ItemTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            ItemTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            ItemTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            ItemTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            ItemTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            ItemTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            ItemTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            ItemTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            ItemTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            ItemTable.Size = new Size(151, 126);
            ItemTable.TabIndex = 6;
            ItemTable.Visible = false;
            // 
            // button2
            // 
            button2.Location = new Point(517, 224);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 7;
            button2.Text = "+500xp EZ";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(390, 544);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 8;
            button3.Text = "Map";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1326, 612);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(ItemTable);
            Controls.Add(PlayerStats);
            Controls.Add(MovementBox);
            Controls.Add(TileTable);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Controls.Add(listBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            MovementBox.ResumeLayout(false);
            PlayerStats.ResumeLayout(false);
            PlayerStats.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBox1;
        private Button button1;
        private PictureBox pictureBox1;
        private TableLayoutPanel TileTable;
        private GroupBox MovementBox;
        private Button MoveNorth;
        private Button MoveEast;
        private Button MoveSouth;
        private Button MoveWest;
        private GroupBox PlayerStats;
        private Label label1;
        private ProgressBar HealthBar;
        private Label label2;
        private ProgressBar ManaBar;
        private Label XPLabel;
        private Label label4;
        private Label LevelLabel;
        private Label label3;
        private Label FireResistLabel;
        private Label MagicResistLabel;
        private Label PhysResistLabel;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label StrengthLabel;
        private Label DexterityLabel;
        private Label label10;
        private Label label9;
        private TableLayoutPanel ItemTable;
        private Button button2;
        private Label label11;
        private Label TotalXPLabel;
        private Button button3;
    }
}
