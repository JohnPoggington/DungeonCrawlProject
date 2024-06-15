namespace DungeonCrawlProject
{
    partial class ItemDetails
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ItemTile = new PictureBox();
            ItemName = new Label();
            ItemDesc = new Label();
            UseItem = new Button();
            ThrowItem = new Button();
            ((System.ComponentModel.ISupportInitialize)ItemTile).BeginInit();
            SuspendLayout();
            // 
            // ItemTile
            // 
            ItemTile.Location = new Point(2, 10);
            ItemTile.Name = "ItemTile";
            ItemTile.Size = new Size(48, 48);
            ItemTile.TabIndex = 0;
            ItemTile.TabStop = false;
            // 
            // ItemName
            // 
            ItemName.AutoSize = true;
            ItemName.Location = new Point(56, 25);
            ItemName.Name = "ItemName";
            ItemName.Size = new Size(63, 15);
            ItemName.TabIndex = 1;
            ItemName.Text = "ItemName";
            // 
            // ItemDesc
            // 
            ItemDesc.AutoSize = true;
            ItemDesc.Location = new Point(12, 86);
            ItemDesc.Name = "ItemDesc";
            ItemDesc.Size = new Size(91, 15);
            ItemDesc.TabIndex = 2;
            ItemDesc.Text = "ItemDescription";
            // 
            // UseItem
            // 
            UseItem.Location = new Point(21, 170);
            UseItem.Name = "UseItem";
            UseItem.Size = new Size(75, 23);
            UseItem.TabIndex = 3;
            UseItem.Text = "Użyj";
            UseItem.UseVisualStyleBackColor = true;
            // 
            // ThrowItem
            // 
            ThrowItem.Location = new Point(102, 170);
            ThrowItem.Name = "ThrowItem";
            ThrowItem.Size = new Size(75, 23);
            ThrowItem.TabIndex = 4;
            ThrowItem.Text = "Wyrzuć";
            ThrowItem.UseVisualStyleBackColor = true;
            // 
            // ItemDetails
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ThrowItem);
            Controls.Add(UseItem);
            Controls.Add(ItemDesc);
            Controls.Add(ItemName);
            Controls.Add(ItemTile);
            Name = "ItemDetails";
            Size = new Size(201, 215);
            ((System.ComponentModel.ISupportInitialize)ItemTile).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox ItemTile;
        private Label ItemName;
        private Label ItemDesc;
        private Button UseItem;
        private Button ThrowItem;
    }
}
