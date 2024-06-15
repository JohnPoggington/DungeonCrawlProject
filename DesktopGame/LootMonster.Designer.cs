namespace DungeonCrawlProject
{
    partial class LootMonster
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
            groupBox1 = new GroupBox();
            WeightLabel = new Label();
            ItemTable = new TableLayoutPanel();
            groupBox2 = new GroupBox();
            LootTable = new TableLayoutPanel();
            CloseButton = new Button();
            MenuTitle = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(WeightLabel);
            groupBox1.Controls.Add(ItemTable);
            groupBox1.Location = new Point(16, 58);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(157, 186);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "Twój ekwipunek";
            // 
            // WeightLabel
            // 
            WeightLabel.AutoSize = true;
            WeightLabel.Location = new Point(6, 163);
            WeightLabel.Name = "WeightLabel";
            WeightLabel.Size = new Size(44, 15);
            WeightLabel.TabIndex = 14;
            WeightLabel.Text = "label12";
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
            ItemTable.Location = new Point(3, 19);
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
            // groupBox2
            // 
            groupBox2.Controls.Add(LootTable);
            groupBox2.Location = new Point(224, 58);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(157, 160);
            groupBox2.TabIndex = 13;
            groupBox2.TabStop = false;
            groupBox2.Text = "Loot";
            // 
            // LootTable
            // 
            LootTable.AutoScroll = true;
            LootTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            LootTable.ColumnCount = 4;
            LootTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            LootTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            LootTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            LootTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            LootTable.Location = new Point(3, 19);
            LootTable.Name = "LootTable";
            LootTable.RowCount = 4;
            LootTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            LootTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            LootTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            LootTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            LootTable.Size = new Size(151, 135);
            LootTable.TabIndex = 6;
            LootTable.Visible = false;
            // 
            // CloseButton
            // 
            CloseButton.Location = new Point(167, 249);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(75, 23);
            CloseButton.TabIndex = 14;
            CloseButton.Text = "Zakończ";
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CloseButton_Click;
            // 
            // MenuTitle
            // 
            MenuTitle.AutoSize = true;
            MenuTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 238);
            MenuTitle.Location = new Point(16, 19);
            MenuTitle.Name = "MenuTitle";
            MenuTitle.Size = new Size(102, 32);
            MenuTitle.TabIndex = 15;
            MenuTitle.Text = "Looting";
            // 
            // LootMonster
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(404, 284);
            ControlBox = false;
            Controls.Add(MenuTitle);
            Controls.Add(CloseButton);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "LootMonster";
            ShowIcon = false;
            Text = "Looting";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label WeightLabel;
        private TableLayoutPanel ItemTable;
        private GroupBox groupBox2;
        private TableLayoutPanel LootTable;
        private Button CloseButton;
        private Label MenuTitle;
    }
}