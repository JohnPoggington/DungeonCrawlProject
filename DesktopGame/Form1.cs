using DungeonCrawlProject.Properties;
using Lib;
using Lib.Enums;
using Lib.MapObjects;
using Lib.Monsters;
using Lib.Spells;
using Newtonsoft.Json;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Imaging;
using System.Resources;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

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

            SpellList.Items.Clear();

            foreach (Spell spell in p.Spells)
            {
                SpellList.Items.Add(spell);

            }


        }

        private void AwardXP(int amount)
        {

            dungeon.GetPlayer().AwardXP(amount);
            UpdatePlayerDisplay();
        }

        private void SetDelegates()
        {

            foreach (IEntity ent in dungeon.Entites)
            {
                if (ent is Character)
                {




                    if (ent is not Player)
                    {
                        Character character = (Character)ent;
                        character.OnCombat += (dmg) => { AddMessageToLog($"{character} otrzyma³ {dmg} punktów obra¿eñ"); UpdatePlayerDisplay(); UpdateTiles(dungeon.GetPlayer()); };
                        character.OnAttackDodge += delegate { AddMessageToLog($"{character} unikn¹³ nadchodz¹cy atak!"); };
                        character.OnDeath += delegate { AddMessageToLog($"{character} umiera!"); };
                        Monster m = (Monster)ent;
                        Player p = dungeon.GetPlayer();
                        m.OnDeath += delegate
                        {
                            if (m.Items.Count > 0) { LootMonster lootMonster = new LootMonster(ref p, m.Items, m.Name); lootMonster.ShowDialog(); UpdateItems(); }
                            dungeon.Entites.Remove(ent); UpdateTiles(p); UpdateInteractButton(p);
                            AddMessageToLog($"{p.Name} otrzymuje {m.XPReward(p)} punktów doœwiadczenia!");
                            //Console.WriteLine(dungeon.GetMonsterCount);
                            if (dungeon.GetMonsterCount == 0)
                            {
                                MessageBox.Show("Pokona³eœ wszystkie potwory i schodzisz ni¿ej do lochu");
                                InitializeWorld(p);
                            }
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

                    if (ent is Chest)
                    {
                        Player p = dungeon.GetPlayer();
                        ((Chest)ent).OnInteract += delegate
                        {
                            AddMessageToLog("Otwierasz skrzyniê");
                            LootMonster lootMonster = new LootMonster(ref p, ((Chest)ent).Items, ent.Name); lootMonster.ShowDialog(); UpdateItems();
                        };
                    }
                }
                if (ent is Spikes)
                {
                    ((Spikes)ent).OnEntityStep += delegate { AddMessageToLog("Nadzia³eœ siê na kolce!"); UpdateTiles(dungeon.GetPlayer()); };
                }
            }

        }

        private void SetPlayerDelegates()
        {
            dungeon.GetPlayer().OnLevelUp += (lvl, oldlvl) =>
            {
                
                Player p = dungeon.GetPlayer();
                LevelUpPoints levelup = new LevelUpPoints(ref p, oldlvl);
                levelup.ShowDialog();
            };
            dungeon.GetPlayer().OnEquipFailed += delegate { MessageBox.Show("Masz za ma³o miejsca na ten przedmiot!"); };

            dungeon.GetPlayer().OnDeath += delegate { MessageBox.Show("Twoja postaæ umar³a!"); this.Close(); };


            dungeon.GetPlayer().OnCombat += (dmg) => { AddMessageToLog($"{dungeon.GetPlayer()} otrzyma³ {dmg} punktów obra¿eñ"); UpdatePlayerDisplay(); UpdateTiles(dungeon.GetPlayer()); };
            dungeon.GetPlayer().OnAttackDodge += delegate { AddMessageToLog($"{dungeon.GetPlayer()} unikn¹³ nadchodz¹cy atak!"); };
            dungeon.GetPlayer().OnDeath += delegate { AddMessageToLog($"{dungeon.GetPlayer()} umiera!"); };
            dungeon.GetPlayer().OnSpellLearned += spell => { AddMessageToLog($"Uda³o ci siê nauczyæ czar {spell}"); };
            dungeon.GetPlayer().OnSpellLearnFailed += spell => { AddMessageToLog("Ju¿ znasz czar z tego kamienia!"); };

        }

        /// INIT WORLD
        private void button1_Click(object sender, EventArgs e)
        {

            NewGame();

        }

        private void NewGame()
        {
            Form2 f2 = new Form2();
            DialogResult result = f2.ShowDialog();
            Player p = f2.CreatedPlayer;

            InitializeWorld(p);
            SetPlayerDelegates();

        }

        private void InitializeWorld(Player p)
        {
            Random rand = new Random();
            int size = rand.Next(30, 45);

            dungeon = new Dungeon(size, size);
            //MessageBox.Show(Dungeon.MapWidth + " x " + Dungeon.MapHeight);






            dungeon.GenerateMap(true);
            try
            {
                dungeon.PutPlayer(p);
            }
            catch (NullReferenceException ex)
            {
                dungeon.PutPlayer(null);
            }

            DrawWorld();

            //MessageBox.Show($"Tiles {TileTable.Controls.Count}");
            MovementBox.Enabled = true;

            UpdatePlayerDisplay();
            SetDelegates();
            PlayerStats.Visible = true;
            ItemTable.Visible = true;
            InventoryBox.Visible = true;
            MovementBox.Visible = true;
            ActivityLog.Visible = true;
            InteractButton.Visible = true;
            SpellBox.Visible = true;
            zapiszGrêToolStripMenuItem.Enabled = true;
            devToolsToolStripMenuItem.Enabled = true;

            CoordinatesLabel.Visible = true;
            UpdateInteractButton(dungeon.GetPlayer());
            UpdateItems();
        }

        private void DrawWorld()
        {
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
                col.Width = 24;
            }
            TileTable.ResumeLayout();
            TileTable.Show();
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

                    
                    object pic = ResourceManager.GetObject(ent.Name);
                    tile.Image = ((Bitmap)(pic));
                    if (ent is Mimic && !((Mimic)ent).isSeen)
                    {
                        tile.Image = Resources.Chest;
                    }
                }
                else if (ent is not null)
                {
                    
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

                   
                }

                UpdateInteractButton(entity);

               

                UpdatePlayerDisplay();


            }
            catch (Lib.Exceptions.IllegalMovementException e) { MessageBox.Show("Illegal move"); }


        }

        private void UpdateInteractButton(IEntity entity)
        {
            List<IEntity> interactableEnts = dungeon.GetInteractableEntitiesAroundEnt(entity);

           
            //Console.WriteLine(interactableEnts.Count.ToString());
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
                        //Console.WriteLine($"i {i} j {j}");
                        tiles.Add(TileTable.GetControlFromPosition(i, j) as PictureBox);

                    }
                }
            }

            foreach (PictureBox tile in tiles)
            {
                TableLayoutPanelCellPosition pos = TileTable.GetPositionFromControl(tile);

                setTile(tile, pos.Column, pos.Row);
            }
        }


        private void UpdateItems()
        {
            var ResourceManager = new System.Resources.ResourceManager("DungeonCrawlProject.Properties.Resources", typeof(Resources).Assembly);

            ItemTable.Hide();

            ItemTable.SuspendLayout();

            for (int i = ItemTable.Controls.Count - 1; i >= 0; --i)
                ItemTable.Controls[i].Dispose();

            ItemTable.Controls.Clear();

            for (int i = JeweleryTable.Controls.Count - 1; i >= 0; --i)
                JeweleryTable.Controls[i].Dispose();

            JeweleryTable.Controls.Clear();

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

                itemTile.Click += new EventHandler((sender, e) => ItemTile_Click(sender, e, item));

                if (item.SpriteName == "Map")
                {
                    itemTile.Click += delegate { MapWindow mapWindow = new MapWindow(ref dungeon); mapWindow.Show(); };
                }



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

                object wpic = ResourceManager.GetObject(dungeon.GetPlayer().Weapon.SpriteName);
                if (wpic is not null)
                    WeaponIcon.Image = ((Bitmap)(wpic));
                else WeaponIcon.Image = Resources.FrameSquare;


                ToolTip wtoolTip = new ToolTip();
                wtoolTip.SetToolTip(ArmorIcon, dungeon.GetPlayer().Weapon.Name);


            }
            else WeaponIcon.Image = Resources.FrameSquare;


            if (dungeon.GetPlayer().Armor is not null)
            {



                object apic = ResourceManager.GetObject(dungeon.GetPlayer().Armor.SpriteName);
                if (apic is not null)
                    ArmorIcon.Image = ((Bitmap)(apic));
                else ArmorIcon.Image = Resources.FrameSquare;


                ToolTip atoolTip = new ToolTip();
                atoolTip.SetToolTip(ArmorIcon, dungeon.GetPlayer().Armor.Name);


            }
            else ArmorIcon.Image = Resources.FrameSquare;



            ItemTable.ResumeLayout();
            ItemTable.Show();
            UpdatePlayerDisplay();
        }

        private void AddMessageToLog(String msg)
        {
            ActivityLog.Items.Add(msg);
            ActivityLog.SelectedIndex = ActivityLog.Items.Count - 1;
            ActivityLog.SelectedIndex = -1;
        }

        private void ItemTile_Click(object sender, EventArgs e, Item item)
        {
            MouseEventArgs me = (MouseEventArgs)e;

            if (me.Button == MouseButtons.Left)
            {
                if (item is Lib.Items.Weapon || item.Type == ItemTypes.Armor || item.Type == ItemTypes.Jewelery)
                {
                    dungeon.GetPlayer().EquipItem(item); UpdateItems(); UpdatePlayerDisplay();
                }
                else if (item.Type == ItemTypes.Consumable)
                {
                    dungeon.GetPlayer().RemoveItem(item, true); UpdateItems(); UpdatePlayerDisplay();
                }

            }
            else if (me.Button == MouseButtons.Right)
            {
                dungeon.GetPlayer().RemoveItem(item, false); UpdateItems(); UpdatePlayerDisplay();
            }
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
            dungeon.GetPlayer().AddItem(new Item("Fish")
            {
                Name = "Ryba",
                Type = ItemTypes.Consumable,
                Weight = 1,
                ItemModifiers = new Dictionary<ModifierTypes, int> { { ModifierTypes.Healing, 3 } }
            });
            UpdateItems();
            UpdatePlayerDisplay();
        }

        private void WeaponIcon_Click(object sender, EventArgs e)
        {
            if (dungeon.GetPlayer().Weapon is not null)
            {

                dungeon.GetPlayer().UnequipWeapon(dungeon.GetPlayer().Weapon); UpdateItems(); UpdatePlayerDisplay();
            }
        }

        private void ArmorIcon_Click(object sender, EventArgs e)
        {
            if (dungeon.GetPlayer().Armor is not null)
            {

                dungeon.GetPlayer().UnequipArmor(dungeon.GetPlayer().Armor); UpdateItems(); UpdatePlayerDisplay();
            }
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void SpellList_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            try
            {
                String selectedSpell = SpellList.SelectedItem.ToString();
                if (selectedSpell is not null)
                {
                    //Console.WriteLine(selectedSpell);
                    bool castSuccesful = dungeon.GetPlayer().CastSpell(dungeon.GetPlayer().GetSpell(selectedSpell));
                    if (castSuccesful)
                    {
                        AddMessageToLog($"Rzuci³eœ zaklêcie {selectedSpell}");
                        dungeon.CastSpell(dungeon.GetPlayer().GetSpell(selectedSpell));
                        UpdatePlayerDisplay();
                    }
                    if (!castSuccesful)
                    {
                        AddMessageToLog("Nie masz many aby rzuciæ dane zaklêcie!");
                    }
                }
            }
            catch (NullReferenceException) {  }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            dungeon.KillAllMonsters();
        }

        private void devToolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GiveFish.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
        }

        private void zapiszGrêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Wybierz miejsce zapisu";

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string sSelectedPath = fbd.SelectedPath;
                using (StreamWriter saveFile = new StreamWriter(Path.Combine(sSelectedPath, "Dungeon.json")))
                {


                    String json = JsonConvert.SerializeObject(dungeon, Formatting.Indented, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Auto,
                        TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple,
                        //ReferenceLoopHandling = ReferenceLoopHandling.Ignore,

                    });
                    saveFile.WriteLine(json);

                }

                MessageBox.Show("Zapisano");
            }
        }

        private void wczytajGrêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                string sFileName = choofdlog.FileName;

                using (StreamReader sr = new StreamReader(sFileName))
                {
                    String save = sr.ReadToEnd();

                    dungeon = JsonConvert.DeserializeObject<Dungeon>(save, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects });

                    DrawWorld();
                    UpdatePlayerDisplay();
                    SetDelegates();
                    SetPlayerDelegates();
                    PlayerStats.Visible = true;
                    ItemTable.Visible = true;
                    InventoryBox.Visible = true;
                    MovementBox.Visible = true;
                    ActivityLog.Visible = true;
                    InteractButton.Visible = true;
                    SpellBox.Visible = true;
                    zapiszGrêToolStripMenuItem.Enabled = true;
                    devToolsToolStripMenuItem.Enabled = true;
                    MovementBox.Enabled = true;
                    CoordinatesLabel.Visible = true;
                    UpdateInteractButton(dungeon.GetPlayer());
                    UpdateItems();
                    UpdateTiles(dungeon.GetPlayer());

                }
            }

        }

        private void zakoñczGrêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
