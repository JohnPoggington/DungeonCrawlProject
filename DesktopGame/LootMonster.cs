using DungeonCrawlProject.Properties;
using Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DungeonCrawlProject
{
    public partial class LootMonster : Form
    {
        public LootMonster(ref Player p, List<Item> loot, String entName)
        {
            _Player = p;
            _Loot = loot;
            _entName = entName;

            

            InitializeComponent();
            UpdateItems();

            groupBox2.Text = entName;
            MenuTitle.Text = $"Przedmioty {entName}";
        }

        private Player _Player;
        private List<Item> _Loot;
        private String _entName;

        private void UpdateItems()
        {
            var ResourceManager = new System.Resources.ResourceManager("DungeonCrawlProject.Properties.Resources", typeof(Resources).Assembly);

            ItemTable.Hide();

            ItemTable.SuspendLayout();

            LootTable.Hide();
            LootTable.SuspendLayout();

            for (int i = ItemTable.Controls.Count - 1; i >= 0; --i)
                ItemTable.Controls[i].Dispose();

            ItemTable.Controls.Clear();

            for (int i = LootTable.Controls.Count - 1; i >= 0; --i)
                LootTable.Controls[i].Dispose();

            LootTable.Controls.Clear();

            List<Item> playerItems = _Player.Items;


            foreach (Item item in playerItems)
            {
                PictureBox itemTile = new PictureBox();
                object pic = ResourceManager.GetObject(item.SpriteName);
                if (pic is not null)
                    itemTile.Image = ((Bitmap)(pic));
                else itemTile.Image = Resources.missingno;

                itemTile.Width = 48;
                itemTile.Height = 48;
                itemTile.SizeMode = PictureBoxSizeMode.Zoom;
                itemTile.WaitOnLoad = true;

                itemTile.Click += delegate
                {
                    _Player.RemoveItem(item, false);
                    _Loot.Add(item);
                    UpdateItems();
                };

                ToolTip toolTip = new ToolTip();
                toolTip.SetToolTip(itemTile, item.Name);

                ItemTable.Controls.Add(itemTile);

            }

            foreach (Item item in _Loot)
            {
                PictureBox itemTile = new PictureBox();
                object pic = ResourceManager.GetObject(item.SpriteName);
                if (pic is not null)
                    itemTile.Image = ((Bitmap)(pic));
                else itemTile.Image = Resources.missingno;

                itemTile.Width = 48;
                itemTile.Height = 48;
                itemTile.SizeMode = PictureBoxSizeMode.Zoom;
                itemTile.WaitOnLoad = true;

                itemTile.Click += delegate
                {
                    _Loot.Remove(item);
                    _Player.AddItem(item);
                    UpdateItems();
                };

                ToolTip toolTip = new ToolTip();
                toolTip.SetToolTip(itemTile, item.Name);

                LootTable.Controls.Add(itemTile);

            }

            ItemTable.ResumeLayout();
            ItemTable.Show();

            LootTable.ResumeLayout();
            LootTable.Show();
            WeightLabel.Text = _Player.CurrentWeight.ToString();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
