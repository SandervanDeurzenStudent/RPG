using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_console.DAL
{
    class Player
    {
        public  static string name { get; set; }
        public static int lives { get; set; } = 20;
        public static int playerDamage { get; set; } = 1;
        public static int playerArmor { get; set; } = 0;
        public static bool hasitem { get; set; } = false;   
       

        public void playerLivesUp()
        {
            Console.WriteLine("Your lives are up.. You lost");
            Console.WriteLine("games over");
            Console.ReadLine();
            Environment.Exit(0);

        }

    }
}
