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

        private Dungeon dungeon;

        private void button1_Click(object sender, EventArgs e)
        {
            int width = 40;
            int height = 40;
            dungeon = new Dungeon(width, height);
            MessageBox.Show(Dungeon.MapWidth + " x " + Dungeon.MapHeight);

            var bmp = new Bitmap(Dungeon.MapWidth, Dungeon.MapHeight, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);

            var palette = bmp.Palette;
            TileTable.Hide();

            TileTable.SuspendLayout();

            for (int i = TileTable.Controls.Count - 1; i >= 0; --i)
                TileTable.Controls[i].Dispose();

            TileTable.Controls.Clear();

            TileTable.RowStyles.Clear();
            TileTable.ColumnStyles.Clear();

            TileTable.RowCount = width;
            TileTable.ColumnCount = width;
            TableLayoutColumnStyleCollection styles = TileTable.ColumnStyles;




            dungeon.GenerateMap();


            bmp.Palette = palette;



            listBox1.Items.Clear();

            //PictureBox[] _mapTiles = new PictureBox[Dungeon.MapWidth];

            for (int x = 1; x < Dungeon.MapWidth; x++)
            {
                String map = "";

                for (int y = Dungeon.MapHeight-1; y > 0; y--)

                {
                    map += dungeon.Map[x, y];


                    PictureBox tile = new PictureBox();
                    setTile(ref tile, x, y);
                    tile.Width = 16;
                    tile.Height = 16;
                    tile.SizeMode = PictureBoxSizeMode.Zoom;
                    tile.WaitOnLoad = true;
                    tile.Margin = new Padding(0);

                    TileTable.Controls.Add(tile, x, y);
                    //TileTable.Controls.Add(tile); 

                    //flowLayoutPanel1.Controls.Add(tile);
                    //if (y == Dungeon.MapHeight - 1)
                    //{
                    //    PictureBox lastTile = tile;
                    //    flowLayoutPanel1.Controls.Add(lastTile);
                    //    flowLayoutPanel1.SetFlowBreak(tile, true);
                    //}
                    //else flowLayoutPanel1.Controls.Add(tile);
                    //_mapTiles[y] = tile;
                }

                listBox1.Items.Add(map);
                //TileTable.Controls.AddRange(_mapTiles);

            }

            //TileTable.Controls.AddRange(_mapTiles);

            foreach (ColumnStyle col in styles)
            {
                col.SizeType = SizeType.Absolute;
                col.Width = 16;
            }
            TileTable.ResumeLayout();
            TileTable.Show();
            MessageBox.Show($"Tiles {TileTable.Controls.Count}");

        }

        private PictureBox setTile(ref PictureBox tile, int x, int y)
        {
            tile.Image = dungeon.Map[x, y] == 0 ? DungeonCrawlProject.Properties.Resources.wall : DungeonCrawlProject.Properties.Resources.floor;
            var ent = dungeon.Entites.Find(e => e.Position.Equals(new Point(x, y)));
            if (ent is Player)
            {
                tile.Image = Properties.Resources.player;
            }
            return tile;
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void MoveNorth_Click(object sender, EventArgs e)
        {
            MoveChar(WalkingDirection.North, dungeon.GetPlayer());
        }

        private void MoveChar(WalkingDirection direction, IEntity entity)
        {
            try
            {
                Control c = TileTable.GetControlFromPosition(entity.Position.X, entity.Position.Y);
                PictureBox oldtile = c as PictureBox;
                int oldX = entity.Position.X;
                int oldY = entity.Position.Y;

                dungeon.MoveEntity(entity, direction);
                c = TileTable.GetControlFromPosition(entity.Position.X, entity.Position.Y);

                PictureBox tile = c as PictureBox;



                if (tile != null)
                {
                    setTile(ref tile, entity.Position.X, entity.Position.Y);
                    //MessageBox.Show("Moved");
                }
                if (oldtile != null)
                {
                    setTile(ref oldtile, oldX, oldY);

                }

                //TileTable.Controls.Add(tile,entity.Position.X,entity.Position.Y);
            }
            catch ( Lib.Exceptions.IllegalMovementException e ) { MessageBox.Show("Illegal move"); }


        }

        private void MoveWest_Click(object sender, EventArgs e)
        {
            MoveChar(WalkingDirection.West, dungeon.GetPlayer());
        }

        private void MoveEast_Click(object sender, EventArgs e)
        {
            MoveChar(WalkingDirection.East, dungeon.GetPlayer());
        }

        private void MoveSouth_Click(object sender, EventArgs e)
        {
            MoveChar(WalkingDirection.South, dungeon.GetPlayer());
        }
    }
}
