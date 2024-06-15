using DungeonCrawlProject.Properties;
using Lib;
using Lib.Enums;
using Lib.MapObjects;
using Lib.Monsters;
using System.Drawing.Imaging;
using System.Resources;

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

            if (p.CurHealth >= 0)
                HealthBar.Value = p.CurHealth;
            else HealthBar.Value = 0;

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

            CoordinatesLabel.Text = $"{p.Position.X}, {p.Position.Y}";

            WeightLabel.Text = $"Waga ekwipunku: {p.CurrentWeight}/{p.MaxItemWeight}";
        }

        private void AwardXP(int amount)
        {

            dungeon.GetPlayer().AwardXP(amount);
            UpdatePlayerDisplay();
        }

        private void SetDelegates()
        {
            dungeon.GetPlayer().OnLevelUp += (lvl, oldlvl) =>
            {
                MessageBox.Show($"Level Up! Twoja postaæ ma poziom {lvl}!");
                Player p = dungeon.GetPlayer();
                LevelUpPoints levelup = new LevelUpPoints(ref p, oldlvl);
                levelup.ShowDialog();
            };
            dungeon.GetPlayer().OnEquipFailed += delegate { MessageBox.Show("Masz za ma³o miejsca na ten przedmiot!"); };
            foreach (IEntity ent in dungeon.Entites)
            {
                if (ent is Character)
                {
                    Character character = (Character)ent;
                    character.OnCombat += (dmg) => { AddMessageToLog($"{character} otrzyma³ {dmg} punktów obra¿eñ"); UpdatePlayerDisplay(); };
                    character.OnAttackDodge += delegate { AddMessageToLog($"{character} unikn¹³ nadchodz¹cy atak!"); };
                    character.OnDeath += delegate { AddMessageToLog($"{character} umiera!"); };

                    if (ent is Player)
                    {
                        character.OnDeath += delegate { MessageBox.Show("Twoja postaæ umar³a!"); this.Close(); };
                    }
                    else
                    {
                        Monster m = (Monster)ent;
                        Player p = dungeon.GetPlayer();
                        m.OnDeath += delegate
                        {
                            if (m.Items.Count > 0) { LootMonster lootMonster = new LootMonster(ref p, m.Items, m.Name); lootMonster.ShowDialog(); UpdateItems(); }
                            dungeon.Entites.Remove(ent); UpdateTiles(p); UpdateInteractButton(p);
                            AddMessageToLog($"{p.Name} otrzymuje {m.XPReward(p)} punktów doœwiadczenia!");
                        };

                    }
                }
                if (ent is InteractableObject)
                {

                    if (ent is Altar)
                    {
                        ((Altar)ent).OnInteract += delegate { AddMessageToLog("O³tarz wype³ni³ twoje cia³o determinacj¹ i energi¹"); };
                        ((Altar)(ent)).OnInteractFailed += delegate { AddMessageToLog("O³tarz nie emanuje ¿adn¹ energi¹"); };
                    }

                    if (ent is FishingPond)
                    {
                        ((FishingPond)ent).OnInteract += delegate { AddMessageToLog("Uda³o ci siê z³owiæ rybê!"); UpdateItems(); };
                        ((FishingPond)ent).OnInteractFailed += delegate { AddMessageToLog("Nie uda³o ci siê z³owiæ ryby!"); };
                        ((FishingPond)ent).OnNoFishes += delegate { AddMessageToLog("W stawie nie ma ju¿ ryb!"); };
                    }
                }
                if (ent is Spikes)
                {
                    ((Spikes)ent).OnEntityStep += delegate { AddMessageToLog("Nadzia³eœ siê na kolce!"); UpdateTiles(dungeon.GetPlayer()); };
                }
            }

            foreach (Item i in dungeon.GetPlayer().Items)
            {
                if (i.SpriteName == "Map")
                {
                    i.OnUse += delegate { MapWindow map = new MapWindow(ref dungeon); map.Show(); };

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








            //listBox1.Items.Clear();

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

                //listBox1.Items.Add(map);
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
            UpdateInteractButton(dungeon.GetPlayer());
            UpdateItems();


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
                    if (ent is Spikes && ((Spikes)ent).AreFound)
                    {
                        object pic = ResourceManager.GetObject(ent.GetType().Name);
                        tile.Image = ((Bitmap)(pic));
                    }
                    else if (ent is not Spikes)
                    {
                        object pic = ResourceManager.GetObject(ent.GetType().Name);
                        if (pic is not null)
                            tile.Image = ((Bitmap)(pic));
                        else tile.Image = Resources.missingno;
                    }

                }



            }
            else tile.Image = Resources.FogOfWar;
            return tile;

        }

        private void UpdateItems()
        {
            var ResourceManager = new System.Resources.ResourceManager("DungeonCrawlProject.Properties.Resources", typeof(Resources).Assembly);

            ItemTable.Hide();

            ItemTable.SuspendLayout();

            for (int i = ItemTable.Controls.Count - 1; i >= 0; --i)
                ItemTable.Controls[i].Dispose();

            ItemTable.Controls.Clear();

            List<Item> playerItems = dungeon.GetPlayer().Items;
            List<Item> playerJewelery = dungeon.GetPlayer().Jewelery;

            
            

            foreach (Item item in playerItems)
            {

                PictureBox itemTile = new PictureBox();

                itemTile.Width = 32;
                itemTile.Height = 32;
                itemTile.SizeMode = PictureBoxSizeMode.Zoom;
                itemTile.WaitOnLoad = true;

                object pic = ResourceManager.GetObject(item.SpriteName);
                if (pic is not null)
                    itemTile.Image = ((Bitmap)(pic));
                else itemTile.Image = Resources.missingno;

                

                if (item.SpriteName == "Map")
                {
                    itemTile.Click += delegate { MapWindow mapWindow = new MapWindow(ref dungeon); mapWindow.Show(); };
                }
                else itemTile.Click += delegate { dungeon.GetPlayer().RemoveItem(item, true); UpdateItems(); UpdatePlayerDisplay(); };

                ToolTip toolTip = new ToolTip();
                toolTip.SetToolTip(itemTile, item.Name);

                ItemTable.Controls.Add(itemTile);
                               
            }

            foreach (Item item in playerJewelery)
            {

                PictureBox itemTile = new PictureBox();

                itemTile.Width = 32;
                itemTile.Height = 32;
                itemTile.SizeMode = PictureBoxSizeMode.Zoom;
                itemTile.WaitOnLoad = true;

                object pic = ResourceManager.GetObject(item.SpriteName);
                if (pic is not null)
                    itemTile.Image = ((Bitmap)(pic));
                else itemTile.Image = Resources.missingno;



                itemTile.Click += delegate { dungeon.GetPlayer().RemoveJewelery(item); UpdateItems(); UpdatePlayerDisplay(); };

                ToolTip toolTip = new ToolTip();
                toolTip.SetToolTip(itemTile, item.Name);

                JeweleryTable.Controls.Add(itemTile);
            }


            if (dungeon.GetPlayer().Weapon is not null)
            {
                PictureBox weaponTile = new PictureBox();

                weaponTile.Width = 32;
                weaponTile.Height = 32;
                weaponTile.SizeMode = PictureBoxSizeMode.Zoom;
                weaponTile.WaitOnLoad = true;

                object wpic = ResourceManager.GetObject(dungeon.GetPlayer().Weapon.SpriteName);
                if (wpic is not null)
                    weaponTile.Image = ((Bitmap)(wpic));
                else weaponTile.Image = Resources.FrameSquare;



                weaponTile.Click += delegate { dungeon.GetPlayer().UnequipWeapon(dungeon.GetPlayer().Weapon); UpdateItems(); UpdatePlayerDisplay(); };

                ToolTip wtoolTip = new ToolTip();
                wtoolTip.SetToolTip(weaponTile, dungeon.GetPlayer().Weapon.Name);

            }


            if (dungeon.GetPlayer().Armor is not null)
            {

                PictureBox armorTile = new PictureBox();

                armorTile.Width = 32;
                armorTile.Height = 32;
                armorTile.SizeMode = PictureBoxSizeMode.Zoom;
                armorTile.WaitOnLoad = true;

                object apic = ResourceManager.GetObject(dungeon.GetPlayer().Weapon.SpriteName);
                if (apic is not null)
                    armorTile.Image = ((Bitmap)(apic));
                else armorTile.Image = Resources.FrameSquare;



                armorTile.Click += delegate { dungeon.GetPlayer().UnequipArmor(dungeon.GetPlayer().Armor); UpdateItems(); UpdatePlayerDisplay(); };

                ToolTip atoolTip = new ToolTip();
                atoolTip.SetToolTip(armorTile, dungeon.GetPlayer().Armor.Name);
            }



            ItemTable.ResumeLayout();
            ItemTable.Show();
            UpdatePlayerDisplay();
        }

        private void MoveNorth_Click(object sender, EventArgs e)
        {
            MoveChar(WalkingDirection.North, dungeon.GetPlayer());
        }

        private void MoveChar(WalkingDirection direction, IEntity entity)
        {
            try
            {

                dungeon.MoveEntity(entity, direction);


                UpdateTiles(entity);

                //listBox1.Items.Clear();

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

                    //listBox1.Items.Add(map);
                    //TileTable.Controls.AddRange(_mapTiles);





                }

                UpdateInteractButton(entity);

                //TileTable.Controls.Add(tile,entity.Position.X,entity.Position.Y);

                UpdatePlayerDisplay();


            }
            catch (Lib.Exceptions.IllegalMovementException e) { MessageBox.Show("Illegal move"); }


        }

        private void UpdateInteractButton(IEntity entity)
        {
            List<IEntity> interactableEnts = dungeon.GetInteractableEntitiesAroundEnt(entity);

            //IEntity checkEnt = interactableEnts.ElementAt(0);
            Console.WriteLine(interactableEnts.Count.ToString());
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

        private void GiveFish_Click(object sender, EventArgs e)
        {
            dungeon.GetPlayer().AddItem(new Item("Fish") { Name = "Ryba", Type = ItemTypes.Consumable, Weight = 1, 
                ItemModifiers = new Dictionary<ModifierTypes, int> { { ModifierTypes.Healing, 3 } } });
            UpdateItems();
            UpdatePlayerDisplay();
        }
    }
}
