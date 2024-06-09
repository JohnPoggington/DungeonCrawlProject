namespace DungeonCrawlProject
{
    partial class MapWindow
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
            TileTable = new TableLayoutPanel();
            SuspendLayout();
            // 
            // TileTable
            // 
            TileTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TileTable.AutoScroll = true;
            TileTable.ColumnCount = 1;
            TileTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 885F));
            TileTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 18F));
            TileTable.Location = new Point(9, 9);
            TileTable.Margin = new Padding(0);
            TileTable.Name = "TileTable";
            TileTable.RowCount = 1;
            TileTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 570F));
            TileTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 570F));
            TileTable.Size = new Size(614, 587);
            TileTable.TabIndex = 4;
            // 
            // MapWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(636, 655);
            Controls.Add(TileTable);
            Name = "MapWindow";
            Text = "MapWindow";
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel TileTable;
    }
}