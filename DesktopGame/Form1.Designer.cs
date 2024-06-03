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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            MovementBox.SuspendLayout();
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
            listBox1.Size = new Size(243, 559);
            listBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(258, 151);
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
            pictureBox1.Location = new Point(258, 9);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(160, 137);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // TileTable
            // 
            TileTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TileTable.AutoScroll = true;
            TileTable.ColumnCount = 1;
            TileTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 824F));
            TileTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 18F));
            TileTable.Location = new Point(433, 9);
            TileTable.Margin = new Padding(0);
            TileTable.Name = "TileTable";
            TileTable.RowCount = 1;
            TileTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 436F));
            TileTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 436F));
            TileTable.Size = new Size(885, 570);
            TileTable.TabIndex = 3;
            // 
            // MovementBox
            // 
            MovementBox.Controls.Add(MoveEast);
            MovementBox.Controls.Add(MoveSouth);
            MovementBox.Controls.Add(MoveWest);
            MovementBox.Controls.Add(MoveNorth);
            MovementBox.Location = new Point(258, 321);
            MovementBox.Name = "MovementBox";
            MovementBox.Size = new Size(160, 169);
            MovementBox.TabIndex = 4;
            MovementBox.TabStop = false;
            MovementBox.Text = "Ruch";
            // 
            // MoveEast
            // 
            MoveEast.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            MoveEast.Location = new Point(80, 78);
            MoveEast.Name = "MoveEast";
            MoveEast.Size = new Size(75, 37);
            MoveEast.TabIndex = 3;
            MoveEast.Text = "→";
            MoveEast.UseVisualStyleBackColor = true;
            MoveEast.Click += MoveEast_Click;
            // 
            // MoveSouth
            // 
            MoveSouth.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            MoveSouth.Location = new Point(63, 121);
            MoveSouth.Name = "MoveSouth";
            MoveSouth.Size = new Size(29, 37);
            MoveSouth.TabIndex = 2;
            MoveSouth.Text = "↓";
            MoveSouth.UseVisualStyleBackColor = true;
            MoveSouth.Click += MoveSouth_Click;
            // 
            // MoveWest
            // 
            MoveWest.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            MoveWest.Location = new Point(10, 78);
            MoveWest.Name = "MoveWest";
            MoveWest.Size = new Size(64, 37);
            MoveWest.TabIndex = 1;
            MoveWest.Text = "←";
            MoveWest.UseVisualStyleBackColor = true;
            MoveWest.Click += MoveWest_Click;
            // 
            // MoveNorth
            // 
            MoveNorth.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            MoveNorth.Location = new Point(63, 22);
            MoveNorth.Name = "MoveNorth";
            MoveNorth.Size = new Size(29, 40);
            MoveNorth.TabIndex = 0;
            MoveNorth.Text = "↑ ";
            MoveNorth.UseVisualStyleBackColor = true;
            MoveNorth.Click += MoveNorth_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1326, 589);
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
    }
}
