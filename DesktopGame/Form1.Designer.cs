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
            CharacterStats = new GroupBox();
            HealthBar = new ProgressBar();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            MovementBox.SuspendLayout();
            CharacterStats.SuspendLayout();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBox1.FormattingEnabled = true;
            listBox1.HorizontalScrollbar = true;
            listBox1.Location = new Point(11, 11);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(277, 707);
            listBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(294, 12);
            button1.Name = "button1";
            button1.Size = new Size(86, 27);
            button1.TabIndex = 1;
            button1.Text = "Generuj";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(647, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(183, 174);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // TileTable
            // 
            TileTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TileTable.AutoScroll = true;
            TileTable.ColumnCount = 1;
            TileTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 1011F));
            TileTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 21F));
            TileTable.Location = new Point(833, 11);
            TileTable.Margin = new Padding(0);
            TileTable.Name = "TileTable";
            TileTable.RowCount = 1;
            TileTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 722F));
            TileTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 722F));
            TileTable.Size = new Size(673, 722);
            TileTable.TabIndex = 3;
            // 
            // MovementBox
            // 
            MovementBox.Controls.Add(MoveEast);
            MovementBox.Controls.Add(MoveSouth);
            MovementBox.Controls.Add(MoveWest);
            MovementBox.Controls.Add(MoveNorth);
            MovementBox.Enabled = false;
            MovementBox.Location = new Point(294, 529);
            MovementBox.Margin = new Padding(3, 4, 3, 4);
            MovementBox.Name = "MovementBox";
            MovementBox.Padding = new Padding(3, 4, 3, 4);
            MovementBox.Size = new Size(155, 189);
            MovementBox.TabIndex = 4;
            MovementBox.TabStop = false;
            MovementBox.Text = "Ruch";
            // 
            // MoveEast
            // 
            MoveEast.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            MoveEast.Location = new Point(83, 74);
            MoveEast.Margin = new Padding(3, 4, 3, 4);
            MoveEast.Name = "MoveEast";
            MoveEast.Size = new Size(56, 47);
            MoveEast.TabIndex = 3;
            MoveEast.Text = "E";
            MoveEast.UseVisualStyleBackColor = true;
            MoveEast.Click += MoveEast_Click;
            // 
            // MoveSouth
            // 
            MoveSouth.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            MoveSouth.Location = new Point(64, 140);
            MoveSouth.Margin = new Padding(3, 4, 3, 4);
            MoveSouth.Name = "MoveSouth";
            MoveSouth.Size = new Size(33, 47);
            MoveSouth.TabIndex = 2;
            MoveSouth.Text = "S";
            MoveSouth.UseVisualStyleBackColor = true;
            MoveSouth.Click += MoveSouth_Click;
            // 
            // MoveWest
            // 
            MoveWest.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            MoveWest.Location = new Point(32, 74);
            MoveWest.Margin = new Padding(3, 4, 3, 4);
            MoveWest.Name = "MoveWest";
            MoveWest.Size = new Size(45, 47);
            MoveWest.TabIndex = 1;
            MoveWest.Text = "W";
            MoveWest.UseVisualStyleBackColor = true;
            MoveWest.Click += MoveWest_Click;
            // 
            // MoveNorth
            // 
            MoveNorth.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            MoveNorth.Location = new Point(64, 15);
            MoveNorth.Margin = new Padding(3, 4, 3, 4);
            MoveNorth.Name = "MoveNorth";
            MoveNorth.Size = new Size(33, 51);
            MoveNorth.TabIndex = 0;
            MoveNorth.Text = "N";
            MoveNorth.UseVisualStyleBackColor = true;
            MoveNorth.Click += MoveNorth_Click;
            // 
            // CharacterStats
            // 
            CharacterStats.Controls.Add(HealthBar);
            CharacterStats.Controls.Add(label1);
            CharacterStats.Location = new Point(294, 45);
            CharacterStats.Name = "CharacterStats";
            CharacterStats.Size = new Size(166, 310);
            CharacterStats.TabIndex = 5;
            CharacterStats.TabStop = false;
            CharacterStats.Text = "Postać";
            // 
            // HealthBar
            // 
            HealthBar.ForeColor = Color.Red;
            HealthBar.Location = new Point(32, 19);
            HealthBar.Name = "HealthBar";
            HealthBar.Size = new Size(115, 26);
            HealthBar.Style = ProgressBarStyle.Continuous;
            HealthBar.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(5, 19);
            label1.Name = "label1";
            label1.Size = new Size(27, 19);
            label1.TabIndex = 0;
            label1.Text = "HP";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1515, 746);
            Controls.Add(CharacterStats);
            Controls.Add(MovementBox);
            Controls.Add(TileTable);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Controls.Add(listBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            MovementBox.ResumeLayout(false);
            CharacterStats.ResumeLayout(false);
            CharacterStats.PerformLayout();
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
        private GroupBox CharacterStats;
        private Label label1;
        private ProgressBar HealthBar;
    }
}
