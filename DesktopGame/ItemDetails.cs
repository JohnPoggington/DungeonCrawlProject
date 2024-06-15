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
    public partial class ItemDetails : UserControl
    {
        public ItemDetails(ref Player p, ref Item item)
        {
            InitializeComponent();

            _player = p;
            _item = item;
        }

        private Player _player;
        private Item _item;
    }
}
