﻿using Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace DungeonCrawlProject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.Text = "Character Creator";
        }

        private String _Name;
        private String _Class;
        private int _HP;
        private int _Mana;
        private int _Dexterity;
        private int _Strength;
        private int _Points;

        public Player CreatedPlayer { get; private set; }

        private void InitUI()
        {
            SubDexButton.Enabled = true;
            AddDexButton.Enabled = true;
            AddStrButton.Enabled = true;
            SubStrButton.Enabled = true;

            _Points = 5;

            UpdateUI();

        }

        private void UpdateUI()
        {
            PointsLabel.Text = _Points.ToString();
            StrengthLabel.Text = _Strength.ToString();
            DexterityLabel.Text = _Dexterity.ToString();
            HPLabel.Text = _HP.ToString();
            ManaLabel.Text = _Mana.ToString();
        }


        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void WarriorButton_CheckedChanged(object sender, EventArgs e)
        {
            _HP = 20;
            _Mana = 5;
            _Dexterity = 2;
            _Strength = 6;
            InitUI();
        }

        private void MonkButton_CheckedChanged(object sender, EventArgs e)
        {
            _HP = 15;
            _Mana = 15;
            _Dexterity = 3;
            _Strength = 4;
            InitUI();
        }

        private void RogueButton_CheckedChanged(object sender, EventArgs e)
        {
            _HP = 12;
            _Mana = 3;
            _Dexterity = 6;
            _Strength = 3;
            InitUI();
        }

        private void SubDexButton_Click(object sender, EventArgs e)
        {
            if (_Dexterity > 0)
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
            if (_Strength > 0)
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
            EndCreator();
        }

        private DialogResult EndCreator()
        {
            if (!string.IsNullOrEmpty(NameInput.Text) && NameInput.Text.Length >= 3)
            {
                if (_Points == 0)
                {
                    CreatedPlayer = new Player()
                    {
                        Name = NameInput.Text,
                        Level = 1,
                        MaxHealth = _HP,
                        CurHealth = _HP,
                        MaxMana = _Mana,
                        CurMana = _Mana,
                        Dexterity = _Dexterity,
                        PhysicalResist = 1,
                        MagicResist = 1,
                        FireResist = 1,
                        Strength = _Strength,
                        Experience = 0,
                        TotalExperience = 0,
                        MaxItemWeight = 20,
                        Items = new List<Item>()
                    };
                    return DialogResult.OK;
                }
                else { MessageBox.Show("Masz dalej niewykorzystane punkty!"); };

            }
            else MessageBox.Show("Nazwa musi mieć przynajmniej 3 znaki!");
            Close();
            return DialogResult.TryAgain;
        }
    }
}
