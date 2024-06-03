using Lib;
using Lib.Enums;
using System.Drawing.Imaging;

namespace DungeonCrawlProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Game";
        }

        private Dungeon dungeon;

        private void UpdatePlayerStats()
        {
            Player p = dungeon.GetPlayer();

            PlayerStats.Text = p.Name;
            HealthBar.Maximum = p.MaxHealth;
            HealthBar.Value = p.CurHealth;

            ManaBar.Maximum = p.MaxMana;
            ManaBar.Value = p.CurMana;

            LevelLabel.Text = p.Level.ToString();

            XPLabel.Text = p.Experience.ToString() + "/" + p.XPToNextLevel();

            TotalXPLabel.Text = p.TotalExperience.ToString();

            PhysResistLabel.Text = p.PhysicalResist.ToString();
            FireResistLabel.Text = p.FireResist.ToString();
            MagicResistLabel.Text = p.MagicResist.ToString();

            DexterityLabel.Text = p.Dexterity.ToString();

            StrengthLabel.Text = p.Strength.ToString();
        }

        private void AwardXP(int amount)
        {
            
            dungeon.GetPlayer().AwardXP(amount);
            UpdatePlayerStats();
        }

        private void SetDelegates()
        {
            dungeon.GetPlayer().OnLevelUp += (lvl) => { MessageBox.Show($"Level Up! Twoja postaæ ma poziom {lvl}!"); };
        }

        /// INIT WORLD
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            DialogResult result = f2.ShowDialog();

            if (result == DialogResult.OK)
            {
                Player p = f2.CreatedPlayer;
                MessageBox.Show($"{p.Name} str{p.Strength}");
            }
            else if (result == DialogResult.TryAgain)
            {
                //DialogResult result2 = f2.ShowDialog();
                MessageBox.Show("Try again");
            }
            
            int width = 40;
            int height = 40;
            dungeon = new Dungeon(width, height);
            MessageBox.Show(Dungeon.MapWidth + " x " + Dungeon.MapHeight);

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




            listBox1.Items.Clear();

            //PictureBox[] _mapTiles = new PictureBox[Dungeon.MapWidth];

            for (int x = 1; x < Dungeon.MapHeight; x++)
            {
                String map = "";

                for (int y = 1; y < Dungeon.MapWidth; y++)

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



            foreach (ColumnStyle col in styles)
            {
                col.SizeType = SizeType.Absolute;
                col.Width = 16;
            }
            TileTable.ResumeLayout();
            TileTable.Show();
            MessageBox.Show($"Tiles {TileTable.Controls.Count}");
            MovementBox.Enabled = true;

            UpdatePlayerStats();
            SetDelegates();
            PlayerStats.Visible = true;
            ItemTable.Visible = true;


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

                listBox1.Items.Clear();

                for (int x = 1; x < Dungeon.MapWidth; x++)
                {
                    String map = "";

                    for (int y = 1; y < Dungeon.MapHeight; y++)

                    {
                        Player p = dungeon.GetPlayer();
                        if (p.Position.X == x && p.Position.Y == y)
                            map += "P";
                        else
                            map += dungeon.Map[x, y];


                    }

                    listBox1.Items.Add(map);
                    //TileTable.Controls.AddRange(_mapTiles);

                }

                //TileTable.Controls.Add(tile,entity.Position.X,entity.Position.Y);
            }
            catch (Lib.Exceptions.IllegalMovementException e) { MessageBox.Show("Illegal move"); }


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

        private void button2_Click(object sender, EventArgs e)
        {
            AwardXP(500);
        }
    }
}
