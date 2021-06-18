using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_console.DAL
{
   public class Enemy
    {
        public string name { get; set; }
        public int lives { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }

        public Enemy(string enemyName, int enemyFormat, int enemyType, int enemyArmor)
        {
            name = enemyName;
            lives = enemyFormat;
            Damage = enemyType;
            Armor = enemyArmor;
        }
        //public void makeTrooper()
        //{
        //    //stats of trooper
        //    name = "trooper";
        //    lives = 5;
        //    Damage = 1;
        //    Armor = 0;


        //    Battle battle = new Battle();
        //    battle.addEnemy(name, lives, Damage, Armor);
            
        //}
        public void makeHellHound()
        {
            name = "hellhound";
            lives = 10;
            Damage = 4;
            Armor = 1;
        }
        public void makeDragon()
        {
            name = "Dragon";
            lives = 5;
            Damage = 1;
            Armor = 0;
        }
    }
}
