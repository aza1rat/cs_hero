using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroGame
{
    public class Hero //поставить ограничения в том числе на ограничение размера окна
    {
        private string name;
        public struct position {public int X; public int Y; }
        public enum status
        {
            здоров,
            жив,
            при_смерти,
            мертв,
            лечиться
        }
        private string pic;
        private double lives;
        private double health;
        private string friend;
        private double damage;

        public string Name { get { return name; } set { name = value; } }
        public position Position;
        public status Status;
        public string Pic { get { return pic; } set { pic = value; } }
        public double Lives { get { return lives; } set { lives = value; } }
        public double Health { get { return health; } set { health = value; } }
        public string Friend { get { return friend; } set { friend = value; } }
        public double Damage { get { return damage; } set { damage = value; } }

        public Hero(string nm, int x, int y, string picture, double heal, string fr)
        {
            name = nm;
            Position.X = x;
            Position.Y = y;
            Status = status.здоров;
            pic = picture;
            lives = 100;
            health = heal;
            friend = fr;
        }

        public void Move(string dir)
        {
            if (Position.X < 1260 && Position.Y < 700 && Position.X > 20 && Position.Y > 20)
            {
                switch (dir)
                {
                    case "u": Position.Y -= 3; break;
                    case "d": Position.Y += 3; break;
                    case "l": Position.X -= 3; break;
                    case "r": Position.X += 3; break;
                    case "ul": Position.Y -= 1; Position.X -= 3; break;
                    case "ur": Position.Y -= 1; Position.X += 3; break;
                    case "dl": Position.Y += 1; Position.X -= 3; break;
                    case "dr": Position.Y += 1; Position.X += 3; break;
                }
            }
        }

        public void ChangeStatus(status s) //мб смена изображения
        {
            Status = s;
        }

        public string ChangePic(string picture, string friend) //стринг убрать, заменится изображением
        {
            if (friend == "T")
                return picture + friend;
            if (friend == "F")
                return picture + friend;
            if (friend == "M")
                return picture + friend;
            return "";
        }

        public void FullHeal()
        {
            lives = 100;
        }

        public void FullDead()
        {
            lives = 0;
        }

        public void Battle(Hero h1, Hero h2)
        {
            if (h1.friend == "M")
            {
                if (h2.friend == "F")
                    Beat(h2, h1.Damage);
                else
                    Heal(h1);
            }
            else
            {
                if (h1.friend != h2.friend)
                    Beat(h1, h2.Damage);
                else
                    Heal(h1);
            }
        }

        public void Beat(Hero hero, double damage)
        {
            hero.Lives -= damage;
        }

        public void Heal(Hero h1)
        {
            double heal;
            heal = h1.Lives / 100 * h1.Health;
            h1.Lives += heal;
        }
    }
}
