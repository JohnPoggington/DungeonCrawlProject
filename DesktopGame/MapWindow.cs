using DungeonCrawlProject.Properties;
using Lib.Monsters;
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
    public partial class MapWindow : Form
    {
               
        private Dungeon dungeon;
        public MapWindow(ref Dungeon dg)
        {
            InitializeComponent();
            dungeon = dg;

            TileTable.Hide();

            TileTable.SuspendLayout();

            for (int i = TileTable.Controls.Count - 1; i >= 0; --i)
                TileTable.Controls[i].Dispose();

            TileTable.Controls.Clear();

            TileTable.RowStyles.Clear();
            TileTable.ColumnStyles.Clear();

            TileTable.RowCount = Dungeon.MapWidth;
            TileTable.ColumnCount = Dungeon.MapWidth;
            TableLayoutColumnStyleCollection styles = TileTable.ColumnStyles;


            for (int x = 1; x < Dungeon.MapHeight; x++)
            {
                String map = "";

                for (int y = 1; y < Dungeon.MapWidth; y++)

                {
                    map += dungeon.Map[x, y];


                    PictureBox tile = new PictureBox();
                    setTile(tile, x, y);
                    tile.Width = 16;
                    tile.Height = 16;
                    tile.SizeMode = PictureBoxSizeMode.Zoom;
                    tile.WaitOnLoad = true;
                    tile.Margin = new Padding(0);

                    TileTable.Controls.Add(tile, x, y);
                    
                }

                
                

            }



            foreach (ColumnStyle col in styles)
            {
                col.SizeType = SizeType.Absolute;
                col.Width = 16;
            }
            TileTable.ResumeLayout();
            TileTable.Show();
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }

        

        private PictureBox setTile(PictureBox tile, int x, int y)
        {
            
            
                tile.Image = dungeon.Map[x, y] == 0 ? DungeonCrawlProject.Properties.Resources.wall : DungeonCrawlProject.Properties.Resources.floor;
                

            
            return tile;

        }
    }
}
