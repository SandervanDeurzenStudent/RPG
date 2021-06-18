using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_console.DAL
{
    class Level
    {
        List<Enemy> enemyList = new List<Enemy>();
        List<Item> itemList = new List<Item>();
        List<Armor> armorList = new List<Armor>();
        public void level(string playerChoice)
        {
            if (playerChoice == "Under")
            {
                //whiteline to be more readable
                Console.WriteLine("");
                Console.WriteLine("You chose to go under it, it seems the most safe way.. but what is that red light? Oh no! there are troopers!. We have to kill it!");
                Console.WriteLine("lets go kill it!");
                Console.ReadLine();
                makeTrooper();
                makeTrooper();
                //start battle
                Battle battle = new Battle();
                battle.SetBattle(enemyList);
            }
            else
            {
                Console.WriteLine("You chose to go Trough it, it seems the most safe way.. but what is that red light? Oh no! its a Trooper!. We have to kill it!");
                makeTrooper();
                //start battle
                Battle battle = new Battle();
                battle.SetBattle(enemyList);
            }
        }
        public void levelHellhound(string armorChoice)
        {
            if (armorChoice == "Y")
            {
                this.addArmorToPlayer("iron helmet", 5, 1, false);
            }
            else
            {
                Console.WriteLine("You chose to not take the armor.");
            }

            Console.WriteLine("You see the big gate to the ending, but first you need to attack the great HellHound!");
            //whiteline to be more readable
            Console.WriteLine("");
            Console.WriteLine("You chose to go in it, it seems the most safe way? Oh no! its a hellhound!. We have to kill it!");
            Console.WriteLine("lets go kill it!");
            Console.ReadLine();
            makeHellhound();
            //start battle
            Battle battle = new Battle();
            battle.SetBattle(enemyList);
        }
        public void EndLevel()
        {
            Console.WriteLine("You can finally battle the Endboss! the big dragon!!");
            //whiteline to be more readable
            Console.WriteLine("");
            Console.WriteLine("Your lives have been restored!");
            Player.lives = 20;
            Program program = new Program();
            program.showPlayerStats();
            Console.WriteLine("lets go kill it!");
            Console.ReadLine();
            makeDragon();
            //start battle
            Battle battle = new Battle();
            battle.SetBattle(enemyList);
        }
        public void playerchoiceStatsUp(int playerLives, int PlayerArmor, int playerAttackDamage, bool upgradeLevel)
        {

            if (playerLives > 0 || PlayerArmor > 0)
            {
                Player.lives = Player.lives + playerLives;
                Player.playerArmor = Player.playerArmor + PlayerArmor;

                Console.WriteLine("{0} gained + {1} lives and + {2}", DAL.Player.name, Player.lives, Player.playerArmor);
                Program program = new Program();
                program.showPlayerStats();
            }
           
            
        }
        public void addItemToPlayer(string itemName, int itemDamage, int itemLevel, bool upgradeLevel)
        {
            // add the item to the player
            foreach (var items in itemList)
            {
                if (upgradeLevel == true)
                {
                    items.level = items.level + 1;
                    Console.WriteLine("{0}'s {1} went to level {2} ", DAL.Player.name, items.name, items.level);
                   

                    //ad the stats of the item to the players attack
                    Player.playerDamage = Player.playerDamage + itemDamage;
                    Program program = new Program();
                    program.showPlayerStats();
                    return;
                }
                else
                {
                    itemList.Clear();
                    Item itemm = new Item(itemName, itemDamage, itemLevel);
                    itemList.Add(itemm);
                    Console.WriteLine("{0}'s found a {1}! ", DAL.Player.name, itemName);

                    //ad the stats of the item to the players attack
                    Player.playerDamage = Player.playerDamage + itemDamage;
                    Program program = new Program();

                    program.showPlayerStats();
                    return;
                }
            }
            
            Item item = new Item(itemName, itemDamage, itemLevel);
            itemList.Add(item);

            Console.WriteLine("{0}'s found a {1}! ", DAL.Player.name, item.name);
            Program programs = new Program();
            Player.playerDamage = Player.playerDamage + itemDamage;

            programs.showPlayerStats();

        }
        public void addArmorToPlayer(string name, int armorHealth, int itemLevel, bool upgradeLevel)
        {
            foreach (var armor in armorList)
            {
                if (upgradeLevel == true)
                {
                    armor.level = armor.level + 1;
                    Console.WriteLine("{0}'s {1} went to level {2} ", DAL.Player.name, armor.name, armor.level);


                    //ad the stats of the item to the players armor
                    armor.health = armor.health + armorHealth;
                    Program program = new Program();
                    //add the armor to the player
                    Player.playerArmor = armor.health;

                    program.showPlayerStats();
                    return;
                }
                else
                {

                    armorList.Clear();
                    Item itemm = new Item(name, armorHealth, itemLevel);
                    itemList.Add(itemm);
                    Console.WriteLine("{0}'s found a {1}! ", DAL.Player.name, name);

                    //ad the stats of the item to the players attack
                    armor.health = armor.health + armorHealth;

                    Program program = new Program();

                    Player.playerArmor = armor.health;
                    program.showPlayerStats();
                    return;
                }
            }
            
            armorList.Add(new Armor(name, armorHealth, itemLevel));

            Console.WriteLine("{0}'s found a {1}! ", DAL.Player.name, name);
            Program programs = new Program();
            if (armorList.Count > 0)
            {
                var specific = armorList[armorList.Count - 1];
                Player.playerArmor = specific.health;


            }

            programs.showPlayerStats();
        }
        public void makeTrooper()
        {
            //stats of trooper
            string name = "trooper";
            int lives = 5;
            int Damage = 1;
            int Armor = 1;

            Enemy enemy = new Enemy(name, lives, Damage, Armor);
            enemyList.Add(enemy);
        }
        public void makeHellhound()
        {
            string name = "Hellhound";
            int lives = 10;
            int Damage = 3;
            int Armor = 3;

            Enemy enemy = new Enemy(name, lives, Damage, Armor);
            enemyList.Add(enemy);
            
        }
        public void makeDragon()
        {
            string name = "Dragon";
            int lives = 19;
            int Damage = 5;
            int Armor = 5;

            Enemy enemy = new Enemy(name, lives, Damage, Armor);
            enemyList.Add(enemy);
        }
    }
}
