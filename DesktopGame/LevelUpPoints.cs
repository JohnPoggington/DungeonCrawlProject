using Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DungeonCrawlProject
{
    public partial class LevelUpPoints : Form
    {
        public LevelUpPoints(ref Player p, int oldLvl)
        {
            InitializeComponent();
            
            _OldDex = p.Dexterity;
            _OldStr = p.Strength;
            _Player = p;
            _Dexterity = p.Dexterity;
            _Strength = p.Strength;
            _Points = (p.Level - oldLvl) * 3;
            this.Text = "Level Up";
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.ControlBox = false;
            InitUI();
        }
        private Player _Player;
        private int _Points;

        private int _OldDex;
        private int _OldStr;
        private int _Dexterity;
        private int _Strength;


        private void InitUI()
        {
            SubDexButton.Enabled = true;
            AddDexButton.Enabled = true;
            AddStrButton.Enabled = true;
            SubStrButton.Enabled = true;

            

            UpdateUI();

        }

        private void UpdateUI()
        {
            PointsLabel.Text = _Points.ToString();
            StrengthLabel.Text = _Strength.ToString();
            DexterityLabel.Text = _Dexterity.ToString();

        }

        private void SubDexButton_Click(object sender, EventArgs e)
        {
            if (_Dexterity > _OldDex)
            {
                _Dexterity--;
                _Points++;
                UpdateUI();
            }
        }

        private void AddDexButton_Click(object sender, EventArgs e)
        {
            if (_Points > 0)
            {
                _Dexterity++;
                _Points--;
                UpdateUI();
            }
        }

        private void SubStrButton_Click(object sender, EventArgs e)
        {
            if (_Strength > _OldStr)
            {
                _Strength--;
                _Points++;
                UpdateUI();
            }
        }

        private void AddStrButton_Click(object sender, EventArgs e)
        {
            if (_Points > 0)
            {
                _Strength++;
                _Points--;
                UpdateUI();

            }
        }

        private void CreatePlayerButton_Click(object sender, EventArgs e)
        {
            if (_Points == 0)
            {
                _Player.Dexterity = _Dexterity;
                _Player.Strength = _Strength;
                Close();
            }
            else MessageBox.Show("Masz niewykorzystane punkty!");
        }
    }
}
