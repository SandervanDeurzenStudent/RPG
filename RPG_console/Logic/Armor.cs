using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_console.DAL
{
    public class Armor
    {
        public string name { get; set; }
        public int health { get; set; }
        public int level { get; set; }

        public Armor(string armorName, int armorDamage, int ArmorLevel)
        {
            name = armorName;
            health = armorDamage;
            level = ArmorLevel;
        }
    }
}
