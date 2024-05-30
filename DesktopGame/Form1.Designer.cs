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
            flowLayoutPanel1 = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBox1.FormattingEnabled = true;
            listBox1.HorizontalScrollbar = true;
            listBox1.Location = new Point(12, 12);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(277, 555);
            listBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(295, 191);
            button1.Name = "button1";
            button1.Size = new Size(86, 26);
            button1.TabIndex = 1;
            button1.Text = "Generuj";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(295, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(183, 173);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // TileTable
            // 
            TileTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TileTable.AutoSize = true;
            TileTable.ColumnCount = 1;
            TileTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 16F));
            TileTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            TileTable.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            TileTable.Location = new Point(565, 12);
            TileTable.Margin = new Padding(0);
            TileTable.Name = "TileTable";
            TileTable.RowCount = 1;
            TileTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 16F));
            TileTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            TileTable.Size = new Size(942, 552);
            TileTable.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.None;
            flowLayoutPanel1.Location = new Point(295, 267);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(258, 297);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1516, 576);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(TileTable);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Controls.Add(listBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private Button button1;
        private PictureBox pictureBox1;
        private TableLayoutPanel TileTable;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}
