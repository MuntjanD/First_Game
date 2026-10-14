using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetFighter_Game
{
    class Enemy : Person
    {
        //public string E_Name = " Enemy";
        //public int E_Damage = 10;
        //public int E_Health = 100;
        //public int E_Armor = 50;

        public string E_printString()
        {
            string s = Name + " DMG   :    " + Damage.ToString()  + "      HP   : " + Health.ToString()  + "   ARM :   "  + Armor.ToString();
            return s;
        }
        public string DmgE_printString()
        {
            string c = Damage.ToString();
            return c;
        }
        public Enemy()

        {
            Name = "Enemy";
            //Damage = //rnd.Next(1, 11); //Convert.ToInt32(rnd_dmg.Next(0, Damage));          
            Health = 100;
            Armor = 50;

        }
        public Enemy(int armor, int damage, int health, string name, int minDamage, int maxDamage) : base(armor, damage, health, name, minDamage, maxDamage) 
        {
            
        }
        
            
        
        //public Enemy() { }

    }
}
