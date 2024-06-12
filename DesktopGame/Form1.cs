using DungeonCrawlProject.Properties;
using Lib;
using Lib.Enums;
using Lib.MapObjects;
using Lib.Monsters;
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

        private void UpdatePlayerDisplay()
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
            UpdatePlayerDisplay();
        }

        private void SetDelegates()
        {
            dungeon.GetPlayer().OnLevelUp += (lvl) => { MessageBox.Show($"Level Up! Twoja postaæ ma poziom {lvl}!"); };
            foreach(IEntity ent in dungeon.Entites)
            {
                if (ent is Character)
                {
                    Character character = (Character)ent;
                    character.OnCombat += (dmg) => { AddMessageToLog($"{character} otrzyma³ {dmg} punktów obra¿eñ");};
                    character.OnAttackDodge += delegate { AddMessageToLog($"{character} unikn¹³ nadchodz¹cy atak!"); };
                    character.OnDeath += delegate { AddMessageToLog($"{character} umiera!" ); };

                    if (ent is Player)
                    {
                        character.OnDeath += delegate { MessageBox.Show("Twoja postaæ umar³a!"); this.Close(); };
                    }
                    else
                    {
                        Monster m = (Monster)ent;
                        Player p = dungeon.GetPlayer();
                        m.OnDeath += delegate{dungeon.Entites.Remove(ent); UpdateTiles(p); UpdateInteractButton(p);
                            AddMessageToLog($"{p.Name} otrzymuje {m.XPReward(p)} punktów doœwiadczenia!"); };
                        
                    }
                }
                else if (ent is InteractableObject)
                {
                    
                    if (ent is Altar)
                    {
                        ((InteractableObject)ent).OnInteract += delegate { AddMessageToLog("O³tarz wype³ni³ twoje cia³o determinacj¹ i energi¹"); };
                        ((InteractableObject)(ent)).OnInteractFailed += delegate { AddMessageToLog("O³tarz nie emanuje ¿adn¹ energi¹"); };
                    }
                }
            }
        }

        /// INIT WORLD
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            DialogResult result = f2.ShowDialog();
            Player p = f2.CreatedPlayer;


            //if (result == DialogResult.OK)
            //{
            //    Player p = f2.CreatedPlayer;
            //    MessageBox.Show($"{p.Name} str{p.Strength}");
            //}
            //else if (result == DialogResult.TryAgain)
            //{
            //    //DialogResult result2 = f2.ShowDialog();
            //    MessageBox.Show("Try again");
            //}

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
            try
            {
                dungeon.PutPlayer(p);
            }
            catch (NullReferenceException ex)
            {
                dungeon.PutPlayer(null);
            }






            listBox1.Items.Clear();

            //PictureBox[] _mapTiles = new PictureBox[Dungeon.MapWidth];

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
                col.Width = 24;
            }
            TileTable.ResumeLayout();
            TileTable.Show();
            MessageBox.Show($"Tiles {TileTable.Controls.Count}");
            MovementBox.Enabled = true;

            UpdatePlayerDisplay();
            SetDelegates();
            PlayerStats.Visible = true;
            ItemTable.Visible = true;


        }

        private PictureBox setTile(PictureBox tile, int x, int y)
        {
            if (dungeon.VisMap[x, y] == true)
            {
                tile.Image = dungeon.Map[x, y] == 0 ? DungeonCrawlProject.Properties.Resources.wall : DungeonCrawlProject.Properties.Resources.floor;
                var ent = dungeon.Entites.Find(e => e.Position.Equals(new Point(x, y)));
                var ResourceManager = new System.Resources.ResourceManager("DungeonCrawlProject.Properties.Resources", typeof(Resources).Assembly);
                if (ent is Player)
                {
                    tile.Image = Properties.Resources.Player;
                }
                else if (ent is Monster)
                {

                    //MessageBox.Show($"Monster {ent.Name}");
                    object pic = ResourceManager.GetObject(ent.Name);
                    tile.Image = ((Bitmap)(pic));
                }
                else if (ent is not null)
                {
                    //MessageBox.Show($"entity {ent.GetType().Name}");
                    object pic = ResourceManager.GetObject(ent.GetType().Name);
                    tile.Image = ((Bitmap)(pic));
                }

            }
            else tile.Image = Resources.FogOfWar;
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
                //FOR MOVEMENT W/O FOG OF WAR(PROBABLY WAY MORE EFFICIENT)

                //Control c = TileTable.GetControlFromPosition(entity.Position.X, entity.Position.Y);
                //PictureBox oldtile = c as PictureBox;
                //int oldX = entity.Position.X;
                //int oldY = entity.Position.Y;

                dungeon.MoveEntity(entity, direction);
                //c = TileTable.GetControlFromPosition(entity.Position.X, entity.Position.Y);

                //PictureBox tile = c as PictureBox;



                //if (tile != null)
                //{
                //    setTile(tile, entity.Position.X, entity.Position.Y);
                //    //MessageBox.Show("Moved");
                //}
                //if (oldtile != null)
                //{
                //    setTile(oldtile, oldX, oldY);

                //}

                UpdateTiles(entity);

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


                    UpdateInteractButton(entity);


                }

                //TileTable.Controls.Add(tile,entity.Position.X,entity.Position.Y);
            }
            catch (Lib.Exceptions.IllegalMovementException e) { MessageBox.Show("Illegal move"); }


        }

        private void UpdateInteractButton(IEntity entity)
        {
            List<IEntity> interactableEnts = dungeon.GetInteractableEntitiesAroundEnt(entity);

            //IEntity checkEnt = interactableEnts.ElementAt(0);

            if (interactableEnts.Count > 0)
            {
                InteractButton.Enabled = true;
                if (interactableEnts.ElementAt(0) is Monster)
                {
                    InteractButton.Text = "Atakuj";
                }
                else InteractButton.Text = "U¿yj";
            }
            else InteractButton.Enabled = false;
        }

        private void UpdateTiles(IEntity entity)
        {
            List<PictureBox> tiles = new List<PictureBox>(9);


            Point entpos = entity.Position;
            for (int i = entpos.X - 2; i <= entpos.X + 2; i++)
            {
                for (int j = entpos.Y - 2; j <= entpos.Y + 2; j++)
                {
                    if (i >= 1 && i < Dungeon.MapWidth && j >= 1 && j < Dungeon.MapHeight)
                    {
                        ///MessageBox.Show($"i {i} j {j}");
                        Console.WriteLine($"i {i} j {j}");
                        tiles.Add(TileTable.GetControlFromPosition(i, j) as PictureBox);

                    }
                }
            }

            //keyvaluepair
            //MessageBox.Show($"row {TileTable.GetPositionFromControl(tiles[4]).Row}  col {TileTable.GetPositionFromControl(tiles[4]).Column}");
            foreach (PictureBox tile in tiles)
            {
                TableLayoutPanelCellPosition pos = TileTable.GetPositionFromControl(tile);

                setTile(tile, pos.Column, pos.Row);
            }
        }

        private void AddMessageToLog(String msg)
        {
            ActivityLog.Items.Add(msg);
            ActivityLog.SelectedIndex = ActivityLog.Items.Count - 1;
            ActivityLog.SelectedIndex = -1;
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

        private void button3_Click(object sender, EventArgs e)
        {
            MapWindow map = new MapWindow(ref dungeon);
            map.Show();
        }

        private void InteractButton_Click(object sender, EventArgs e)
        {
            Player p = dungeon.GetPlayer();

            IEntity targetEnt = dungeon.GetInteractableEntitiesAroundEnt(p).ElementAt(0);

            if (targetEnt is Monster)
            {
                Dungeon.Combat(p, (Monster)targetEnt);
                UpdatePlayerDisplay();
            }
            if (targetEnt is InteractableObject)
            {
                InteractableObject obj = (InteractableObject)targetEnt;
                obj.Interact(p);
                UpdatePlayerDisplay();
            }
        }
    }
}
