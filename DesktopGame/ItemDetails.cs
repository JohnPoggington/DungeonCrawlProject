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
using Lib.Items;

namespace DungeonCrawlProject
{
    public partial class ItemDetails : UserControl
    {
        public ItemDetails(ref Player p, ref Item item)
        {
            InitializeComponent();

            _player = p;
            _item = item;

            var ResourceManager = new System.Resources.ResourceManager("DungeonCrawlProject.Properties.Resources", typeof(Resources).Assembly);

            object pic = ResourceManager.GetObject(item.SpriteName);
            if (pic is not null)
                ItemTile.Image = ((Bitmap)(pic));
            else ItemTile.Image = Resources.missingno;

            ItemName.Text = item.Name;

            if (item is Weapon)
            {
                
            }
        }

        private Player _player;
        private Item _item;
    }
}
