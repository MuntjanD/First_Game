using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetFighter_Game
{
    public class Person
    {

        static public int Count = 0;
        //public string Name { get; set; }
        //public int Damage  { get; set; }
        //public int Health  { get; set; }
        //public int Armor  { get; set; }
        //public static Random rnd = new Random();
        public Random rnd_dmg = new Random();
        public Random rnd_block = new Random();
        public int MinDamage;
        public int MaxDamage;
        public string Name { get; set; }
        public int Damage;// = rnd.Next(1, 10);
        public int Health = 100;
        public int Armor = 50;
        public int Attack_Head;
        public int Attack_Torso;
        public int Attack_Leg;
        public int Block_Head;
        public int Block_Torso;
        public int Block_Leg;
        public int pAttack;
        public int pBlock;
        



        public string printString()
        {
            string s = Name + " DMG :   " + Damage.ToString() + ":     HP : " + Health.ToString() + ":    ARM : " + Armor.ToString();
            return s;
        }
        public string DmgPrinstring()
        {
            string b = Damage.ToString();
            return b;
        }

        public Person(int armor, int damage, int health, string name , int minDamage , int maxDamage )


        {
            //Name = name;
            //Damage = damage
            //Health = 100;
            //Armor = 50;
            Name = name;
            Damage = damage;
            Health = health;
            Armor = armor;
            MinDamage = minDamage;
            MaxDamage = maxDamage;

        }

        public Person() { }


    }
}
