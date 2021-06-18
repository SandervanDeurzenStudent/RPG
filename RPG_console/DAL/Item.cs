using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_console.DAL
{
    class Item
    {
        public  string name { get; set; }
        public  int damage { get; set; }
        public  int level { get; set; }

        public Item(string itemName, int itemDamage,  int itemLevel)
        {
            name = itemName;
            damage = itemDamage;
            level = itemLevel;
        }
    }
}
