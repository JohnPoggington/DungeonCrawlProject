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
            InteractButton = new Button();
            ActivityLog = new ListBox();
            InventoryBox = new GroupBox();
            label14 = new Label();
            JeweleryTable = new TableLayoutPanel();
            ArmorIcon = new PictureBox();
            label13 = new Label();
            label12 = new Label();
            WeaponIcon = new PictureBox();
            WeightLabel = new Label();
            CoordinatesLabel = new Label();
            GiveFish = new Button();
            SpellList = new ListBox();
            SpellBox = new GroupBox();
            menuStrip1 = new MenuStrip();
            NewGameButton = new ToolStripMenuItem();
            wczytajGręToolStripMenuItem = new ToolStripMenuItem();
            zapiszGręToolStripMenuItem = new ToolStripMenuItem();
            devToolsToolStripMenuItem = new ToolStripMenuItem();
            zakończGręToolStripMenuItem = new ToolStripMenuItem();
            button4 = new Button();
            UIContainer = new FlowLayoutPanel();
            MovementBox.SuspendLayout();
            PlayerStats.SuspendLayout();
            InventoryBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ArmorIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WeaponIcon).BeginInit();
            SpellBox.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // TileTable
            // 
            TileTable.AutoScroll = true;
            TileTable.ColumnCount = 1;
            TileTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 885F));
            TileTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 18F));
            TileTable.Location = new Point(184, 29);
            TileTable.Margin = new Padding(0);
            TileTable.Name = "TileTable";
            TileTable.RowCount = 1;
            TileTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 570F));
            TileTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 570F));
            TileTable.Size = new Size(643, 630);
            TileTable.TabIndex = 3;
            TileTable.Visible = false;
            // 
            // MovementBox
            // 
            MovementBox.Controls.Add(MoveEast);
            MovementBox.Controls.Add(MoveSouth);
            MovementBox.Controls.Add(MoveWest);
            MovementBox.Controls.Add(MoveNorth);
            MovementBox.Enabled = false;
            MovementBox.Location = new Point(172, 667);
            MovementBox.Name = "MovementBox";
            MovementBox.Size = new Size(121, 149);
            MovementBox.TabIndex = 4;
            MovementBox.TabStop = false;
            MovementBox.Text = "Ruch";
            MovementBox.Visible = false;
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
            PlayerStats.Location = new Point(12, 29);
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
            ManaBar.MarqueeAnimationSpeed = 1;
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
            HealthBar.MarqueeAnimationSpeed = 1;
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
            ItemTable.AutoScroll = true;
            ItemTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            ItemTable.ColumnCount = 4;
            ItemTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            ItemTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            ItemTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            ItemTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            ItemTable.Location = new Point(1, 153);
            ItemTable.Name = "ItemTable";
            ItemTable.RowCount = 4;
            ItemTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            ItemTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            ItemTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            ItemTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            ItemTable.Size = new Size(151, 135);
            ItemTable.TabIndex = 6;
            ItemTable.Visible = false;
            // 
            // button2
            // 
            button2.Location = new Point(84, 753);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 7;
            button2.Text = "+500xp EZ";
            button2.UseVisualStyleBackColor = true;
            button2.Visible = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(3, 753);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 8;
            button3.Text = "Map";
            button3.UseVisualStyleBackColor = true;
            button3.Visible = false;
            button3.Click += button3_Click;
            // 
            // InteractButton
            // 
            InteractButton.Enabled = false;
            InteractButton.Location = new Point(3, 724);
            InteractButton.Name = "InteractButton";
            InteractButton.Size = new Size(75, 23);
            InteractButton.TabIndex = 9;
            InteractButton.Text = "Interact";
            InteractButton.UseVisualStyleBackColor = true;
            InteractButton.Visible = false;
            InteractButton.Click += InteractButton_Click;
            // 
            // ActivityLog
            // 
            ActivityLog.FormattingEnabled = true;
            ActivityLog.ItemHeight = 15;
            ActivityLog.Location = new Point(299, 662);
            ActivityLog.Name = "ActivityLog";
            ActivityLog.Size = new Size(516, 154);
            ActivityLog.TabIndex = 10;
            ActivityLog.Visible = false;
            // 
            // InventoryBox
            // 
            InventoryBox.Controls.Add(label14);
            InventoryBox.Controls.Add(JeweleryTable);
            InventoryBox.Controls.Add(ArmorIcon);
            InventoryBox.Controls.Add(label13);
            InventoryBox.Controls.Add(label12);
            InventoryBox.Controls.Add(WeaponIcon);
            InventoryBox.Controls.Add(WeightLabel);
            InventoryBox.Controls.Add(ItemTable);
            InventoryBox.Location = new Point(12, 279);
            InventoryBox.Name = "InventoryBox";
            InventoryBox.Size = new Size(157, 315);
            InventoryBox.TabIndex = 11;
            InventoryBox.TabStop = false;
            InventoryBox.Text = "Ekwipunek";
            InventoryBox.Visible = false;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(48, 135);
            label14.Name = "label14";
            label14.Size = new Size(52, 15);
            label14.TabIndex = 20;
            label14.Text = "Biżuteria";
            // 
            // JeweleryTable
            // 
            JeweleryTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            JeweleryTable.ColumnCount = 4;
            JeweleryTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            JeweleryTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            JeweleryTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            JeweleryTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            JeweleryTable.Location = new Point(6, 96);
            JeweleryTable.Name = "JeweleryTable";
            JeweleryTable.RowCount = 1;
            JeweleryTable.RowStyles.Add(new RowStyle(SizeType.Percent, 47.22222F));
            JeweleryTable.RowStyles.Add(new RowStyle(SizeType.Percent, 52.77778F));
            JeweleryTable.Size = new Size(145, 36);
            JeweleryTable.TabIndex = 19;
            // 
            // ArmorIcon
            // 
            ArmorIcon.Image = Properties.Resources.FrameSquare;
            ArmorIcon.Location = new Point(89, 22);
            ArmorIcon.Name = "ArmorIcon";
            ArmorIcon.Size = new Size(32, 32);
            ArmorIcon.SizeMode = PictureBoxSizeMode.Zoom;
            ArmorIcon.TabIndex = 18;
            ArmorIcon.TabStop = false;
            ArmorIcon.Click += ArmorIcon_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(89, 57);
            label13.Name = "label13";
            label13.Size = new Size(48, 15);
            label13.TabIndex = 17;
            label13.Text = "Pancerz";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(14, 57);
            label12.Name = "label12";
            label12.Size = new Size(32, 15);
            label12.TabIndex = 16;
            label12.Text = "Broń";
            // 
            // WeaponIcon
            // 
            WeaponIcon.Image = Properties.Resources.FrameSquare;
            WeaponIcon.Location = new Point(16, 22);
            WeaponIcon.Name = "WeaponIcon";
            WeaponIcon.Size = new Size(32, 32);
            WeaponIcon.SizeMode = PictureBoxSizeMode.Zoom;
            WeaponIcon.TabIndex = 15;
            WeaponIcon.TabStop = false;
            WeaponIcon.Click += WeaponIcon_Click;
            // 
            // WeightLabel
            // 
            WeightLabel.AutoSize = true;
            WeightLabel.Location = new Point(4, 297);
            WeightLabel.Name = "WeightLabel";
            WeightLabel.Size = new Size(44, 15);
            WeightLabel.TabIndex = 14;
            WeightLabel.Text = "label12";
            // 
            // CoordinatesLabel
            // 
            CoordinatesLabel.AutoSize = true;
            CoordinatesLabel.Location = new Point(131, 779);
            CoordinatesLabel.Name = "CoordinatesLabel";
            CoordinatesLabel.Size = new Size(27, 15);
            CoordinatesLabel.TabIndex = 12;
            CoordinatesLabel.Text = "X, Y";
            CoordinatesLabel.Visible = false;
            // 
            // GiveFish
            // 
            GiveFish.Location = new Point(84, 724);
            GiveFish.Name = "GiveFish";
            GiveFish.Size = new Size(75, 23);
            GiveFish.TabIndex = 13;
            GiveFish.Text = "gib fish";
            GiveFish.UseVisualStyleBackColor = true;
            GiveFish.Visible = false;
            GiveFish.Click += GiveFish_Click;
            // 
            // SpellList
            // 
            SpellList.FormattingEnabled = true;
            SpellList.ItemHeight = 15;
            SpellList.Location = new Point(6, 17);
            SpellList.Name = "SpellList";
            SpellList.Size = new Size(146, 94);
            SpellList.TabIndex = 14;
            SpellList.MouseDoubleClick += SpellList_MouseDoubleClick;
            // 
            // SpellBox
            // 
            SpellBox.Controls.Add(SpellList);
            SpellBox.Location = new Point(9, 594);
            SpellBox.Name = "SpellBox";
            SpellBox.Size = new Size(157, 124);
            SpellBox.TabIndex = 15;
            SpellBox.TabStop = false;
            SpellBox.Text = "Dostępne czary";
            SpellBox.Visible = false;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { NewGameButton, wczytajGręToolStripMenuItem, zapiszGręToolStripMenuItem, devToolsToolStripMenuItem, zakończGręToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1270, 24);
            menuStrip1.TabIndex = 16;
            menuStrip1.Text = "menuStrip1";
            // 
            // NewGameButton
            // 
            NewGameButton.Name = "NewGameButton";
            NewGameButton.Size = new Size(70, 20);
            NewGameButton.Text = "Nowa gra";
            NewGameButton.Click += NewGameButton_Click;
            // 
            // wczytajGręToolStripMenuItem
            // 
            wczytajGręToolStripMenuItem.Name = "wczytajGręToolStripMenuItem";
            wczytajGręToolStripMenuItem.Size = new Size(80, 20);
            wczytajGręToolStripMenuItem.Text = "Wczytaj grę";
            wczytajGręToolStripMenuItem.Click += wczytajGręToolStripMenuItem_Click;
            // 
            // zapiszGręToolStripMenuItem
            // 
            zapiszGręToolStripMenuItem.Enabled = false;
            zapiszGręToolStripMenuItem.Name = "zapiszGręToolStripMenuItem";
            zapiszGręToolStripMenuItem.Size = new Size(72, 20);
            zapiszGręToolStripMenuItem.Text = "Zapisz grę";
            zapiszGręToolStripMenuItem.Click += zapiszGręToolStripMenuItem_Click;
            // 
            // devToolsToolStripMenuItem
            // 
            devToolsToolStripMenuItem.Enabled = false;
            devToolsToolStripMenuItem.Name = "devToolsToolStripMenuItem";
            devToolsToolStripMenuItem.Size = new Size(69, 20);
            devToolsToolStripMenuItem.Text = "Dev Tools";
            devToolsToolStripMenuItem.Click += devToolsToolStripMenuItem_Click;
            // 
            // zakończGręToolStripMenuItem
            // 
            zakończGręToolStripMenuItem.Name = "zakończGręToolStripMenuItem";
            zakończGręToolStripMenuItem.Size = new Size(83, 20);
            zakończGręToolStripMenuItem.Text = "Zakończ grę";
            zakończGręToolStripMenuItem.Click += zakończGręToolStripMenuItem_Click;
            // 
            // button4
            // 
            button4.Location = new Point(3, 782);
            button4.Name = "button4";
            button4.Size = new Size(98, 23);
            button4.TabIndex = 17;
            button4.Text = "Kill monsters";
            button4.UseVisualStyleBackColor = true;
            button4.Visible = false;
            button4.Click += button4_Click;
            // 
            // UIContainer
            // 
            UIContainer.FlowDirection = FlowDirection.TopDown;
            UIContainer.Location = new Point(830, 203);
            UIContainer.Name = "UIContainer";
            UIContainer.Size = new Size(428, 304);
            UIContainer.TabIndex = 18;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1270, 842);
            Controls.Add(UIContainer);
            Controls.Add(button4);
            Controls.Add(SpellBox);
            Controls.Add(GiveFish);
            Controls.Add(CoordinatesLabel);
            Controls.Add(InventoryBox);
            Controls.Add(ActivityLog);
            Controls.Add(InteractButton);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(PlayerStats);
            Controls.Add(MovementBox);
            Controls.Add(TileTable);
            Controls.Add(menuStrip1);
            KeyPreview = true;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            KeyDown += Form1_KeyDown;
            MovementBox.ResumeLayout(false);
            PlayerStats.ResumeLayout(false);
            PlayerStats.PerformLayout();
            InventoryBox.ResumeLayout(false);
            InventoryBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ArmorIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)WeaponIcon).EndInit();
            SpellBox.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
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
        private Button InteractButton;
        private ListBox ActivityLog;
        private GroupBox InventoryBox;
        private Label CoordinatesLabel;
        private Button GiveFish;
        private Label WeightLabel;
        private Label label14;
        private TableLayoutPanel JeweleryTable;
        private PictureBox ArmorIcon;
        private Label label13;
        private Label label12;
        private PictureBox WeaponIcon;
        private ListBox SpellList;
        private GroupBox SpellBox;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem NewGameButton;
        private ToolStripMenuItem wczytajGręToolStripMenuItem;
        private ToolStripMenuItem zapiszGręToolStripMenuItem;
        private Button button4;
        private ToolStripMenuItem devToolsToolStripMenuItem;
        private ToolStripMenuItem zakończGręToolStripMenuItem;
        private FlowLayoutPanel UIContainer;
    }
}
