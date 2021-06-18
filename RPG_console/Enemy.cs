using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_console.DAL
{
    class Enemy
    {
        public  string name { get; set; }
        public  int lives { get; set; }
        public  int Damage { get; set; }
        public  int Armor { get; set; }

         
        public void makeTrooper()
        {
            name = "trooper";
            lives = 5;
            Damage = 1;
            Armor = 0;
        }
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
