using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace HeroGame
{
    public partial class Form1 : Form
    {
        /*
         На оценку «Удовлетворительно»
Учитывать размеры игрового пространства.
Изменять состояние объекта.
При движении менять картинку в зависимости от направления движения персонажа (поворот головы, движение рук и ног и т.д.).
На оценку «Хорошо»
Дополнительно реализовать к объекту:
	полное восстановление (при попадании игрового персонажа в какую-либо область на игровом поле);
	изменение количества жизней и процента энергии в зависимости от условий;
	уничтожение игрока (столкновение с какой-то областью на игровом поле).
На оценку «Отлично»
Дополнительно создать несколько объектов из разных лагерей.
	столкновение двух объектов в зависимости от лагеря – лечение или нанесение урона.
*/


        public Hero mainHero = new Hero("Eblan", 690, 410, "test", 14, "M");
        bool up, down, left, right; int totalDelta = 0;
        List<PictureBox> heroespb = new List<PictureBox>();
        List<Hero> heroes = new List<Hero>();
        public Form1()
        {
            InitializeComponent();
            MouseWheel += new MouseEventHandler(Form_MouseWheel);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (up)
                Moving(pictureBox1, mainHero, "u");
            if (down)
                Moving(pictureBox1, mainHero, "d");
            if (left)
                Moving(pictureBox1, mainHero, "l");
            if (right)
                Moving(pictureBox1, mainHero, "r");
            if (up && left)
                Moving(pictureBox1, mainHero, "ul");
            if (up && right)
                Moving(pictureBox1, mainHero, "ur");
            if (down && left)
                Moving(pictureBox1, mainHero, "dl");
            if (down && right)
                Moving(pictureBox1, mainHero, "dr");
        }

        private void Form_MouseWheel(object sender, MouseEventArgs e) //?
        {
            if (e.Delta != totalDelta)
            {  
                if (e.Delta > 0)
                {
                    up = true;
                    down = false;
                    totalDelta += totalDelta + e.Delta;
                }
                if (e.Delta < 0)
                {
                    up = false;
                    down = true;
                    totalDelta -= totalDelta + e.Delta;
                }
            }
            else
            {
                totalDelta = 0;
                up = false;
                down = false;
            }
        }

        void Moving (PictureBox pictureBox, Hero hero, string napravl)
        {
            hero.Move(napravl);
            pictureBox.Location = new Point(hero.Position.X, hero.Position.Y);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
                up = true;
            if (e.KeyCode == Keys.S)
                down = true;
            if (e.KeyCode == Keys.A)
                left = true;
            if (e.KeyCode == Keys.D)
                right = true;
            if (e.KeyCode == Keys.Up)
                up = true;
            if (e.KeyCode == Keys.Down)
                down = true;
            if (e.KeyCode == Keys.Left)
                left = true;
            if (e.KeyCode == Keys.Right)
                right = true;
            if (e.KeyCode == Keys.Shift)
                AddFriendHero(ref heroespb, ref heroes); //добавить героя или злодея
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
                up = false;
            if (e.KeyCode == Keys.S)
                down = false;
            if (e.KeyCode == Keys.A)
                left = false;
            if (e.KeyCode == Keys.D)
                right = false;
            if (e.KeyCode == Keys.Up)
                up = false;
            if (e.KeyCode == Keys.Down)
                down = false;
            if (e.KeyCode == Keys.Left)
                left = false;
            if (e.KeyCode == Keys.Right)
                right = false;
        }

        void AddFriendHero (ref List<PictureBox> pictureBoxes, ref List<Hero> heroes)
        {
            int n = -1;
            Random random = new Random();
            heroes.Add(new Hero(Interaction.InputBox("Введите имя персонажа"), random.Next(20, 1251), random.Next(20, 701), "pic", random.Next(1, 20), "T"));
            foreach(Hero her in heroes)
            {
                n++;
                if (heroes.Count - 1 == n)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Location = new Point(her.Position.X, her.Position.Y);
                    //изображение и автоподбор
                    Controls.Add(pictureBox);
                    pictureBoxes.Add(pictureBox);
                }
                
            }
            

        }


    }
}
