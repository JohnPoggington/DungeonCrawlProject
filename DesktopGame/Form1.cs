using Lib;
using System.Drawing.Imaging;

namespace DungeonCrawlProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int width = 100;
            int height = 100;
            Dungeon dungeon = new Dungeon(width, height);
            MessageBox.Show(Dungeon.MapWidth + " x " + Dungeon.MapHeight);

            var bmp = new Bitmap(Dungeon.MapWidth, Dungeon.MapHeight, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);

            var palette = bmp.Palette;

            for (int i = TileTable.Controls.Count - 1; i >= 0; --i)
                TileTable.Controls[i].Dispose();

            TileTable.Controls.Clear();
            TileTable.RowCount = width;
            TileTable.ColumnCount = width;
            TableLayoutColumnStyleCollection styles = TileTable.ColumnStyles;

            
            

            dungeon.GenerateMap();


            bmp.Palette = palette;


            listBox1.Items.Clear();

            //for (int i = 0; i < 100; i++)
            //{


            //    PictureBox t1 = new PictureBox();
            //    t1.Image = Properties.Resources.wall;
            //    t1.Width = 16;
            //    t1.Height = 16;
            //    TileTable.Controls.Add(t1, 0, 0);
            //}

            for (int x = 1; x < Dungeon.MapWidth; x++)
            {
                String map = "";
                for (int y = 1; y < Dungeon.MapHeight; y++)

                {
                    map += dungeon.Map[x, y];

                    PictureBox tile = new PictureBox();
                    tile.Image = dungeon.Map[x, y] == 0 ? DungeonCrawlProject.Properties.Resources.wall : DungeonCrawlProject.Properties.Resources.floor;
                    tile.Width = 16;
                    tile.Height = 16;
                    tile.SizeMode = PictureBoxSizeMode.Zoom;
                    TileTable.Controls.Add(tile,y,x);
                }
                listBox1.Items.Add(map);
            }

            foreach (ColumnStyle col in styles)
            {
                col.SizeType = SizeType.Absolute;
                col.Width = 16;
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
