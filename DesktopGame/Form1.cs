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
            Dungeon dungeon = new Dungeon(100,100);
            MessageBox.Show(Dungeon.MapWidth + " x " + Dungeon.MapHeight);

            var bmp = new Bitmap(Dungeon.MapWidth, Dungeon.MapHeight, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);

            var palette = bmp.Palette;

            dungeon.GenerateMap();
            

            bmp.Palette = palette;

            
            listBox1.Items.Clear();

            for (int x = 1; x < Dungeon.MapWidth; x++)
            {
                String map = "";
                for (int y = 1; y < Dungeon.MapHeight; y++)
                
                {
                    map += dungeon.Map[x,y];
                    
                }
                listBox1.Items.Add(map);
            }

        }
    }
}
