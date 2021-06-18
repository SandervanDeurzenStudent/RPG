using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_console
{
    class Program
    {

        static void Main(string[] args)
        {
            
            Program program = new Program();
            program.login();
            program.story();
        }
        public void story()
        {

            if (DAL.Player.name == "")
            {
                Console.WriteLine("please enter your name:");
                string name = Console.ReadLine();
                DAL.Player.name = name;
            }
            //set name for player
            Console.WriteLine("Hello... {0}" , DAL.Player.name);
            Console.WriteLine("press enter to continue");
            Console.ReadLine();

            Console.WriteLine("What... where am i??");
           

            //intro

            Console.WriteLine("{0} woke up in a extremly foggy forest, somehow he forgot everything. He found a key in his pocket. Wonder what it is for..", DAL.Player.name);
            Console.WriteLine("He checks around him if he sees anything helpfull, but seems to be completely alone. He starts wandering around but shortly after that he founds something..");
            Console.WriteLine("It's a wooden sword!");
            Console.ReadLine();

            // give the sword to the player

            DAL.Level level = new DAL.Level();
            level.addItemToPlayer("Wooden sword", 3, 1, false);
            Console.WriteLine("Player also found an Wooden shield on the ground!");
            level.addArmorToPlayer("Wooden Shield", 5, 1, false);
            
           
            //the sword is 2 damage bonus

            Console.WriteLine("the player has come across a shady bridge. Because of the fog he can't see the end he can choose to go under it of trough it. Which one does the player choose");
            Console.WriteLine("Do you want to go Trough or Under? Trough/Under");
            string playerChoice = Console.ReadLine();
            level.level(playerChoice);

            // stage two

            Console.WriteLine("You have beaten the trooper! good job!");
            Console.WriteLine("Across the brigde you found an iron helmet! do you want to take it? Y/N");
            string armorChoice = Console.ReadLine();
            
            level.levelHellhound(armorChoice);
            Console.WriteLine("You did it! we can finally enter the castle!");
            level.EndLevel();
            Console.ReadLine();


            //the ending

            Console.WriteLine("You did it! you won!!! Your armor and item got upgraded!");
            level.addArmorToPlayer("iron helmet", 5, 1, true);
            level.addItemToPlayer("Wooden sword", 3, 1, true);

            Console.WriteLine("Thanks for playing! part two will be up soon...");
            Console.ReadLine();

            
        } 
        //public void level1(string name)
        //{
        //    Console.WriteLine("{0} woke up in a extremly foggy forest, somehow he forgot everything. He found a key in his pocket. Wonder what it is for..", name);
        //    Console.WriteLine("He checks around him if he sees anything helpfull, but seems to be completely alone. He starts wandering around but shortly after that he founds something..");
        //    Console.WriteLine("It's a wooden sword!");
        //    Console.ReadLine();
        //    DAL.Item items = new DAL.Item();
        //    items.setWoodenSword();
        //    DAL.Player.playerDamage = DAL.Player.playerDamage + DAL.Item.damage;
        //    the sword is 2 damage bonus

        //    shows the stats of the player
        //    showPlayerStats();

        //    Console.WriteLine("the player has come across a shady bridge. Because of the fog he can't see the end he can choose to go under it of trough it. Which one does the player choose");
        //    Console.WriteLine("Do you want to go Trough or Under? Trough/Under");
        //    string playerChoice = Console.ReadLine();
        //    DAL.Level level = new DAL.Level();
        //    level.level(playerChoice);
            
        //}
        //public void level2()
        //{


        //}
        public void login()
        {

            Console.WriteLine("enter your username");
            string username = Console.ReadLine();
            Console.WriteLine("enter your password");
            string password = Console.ReadLine();
            
            Data_access.Login login = new Data_access.Login();
            bool isLoggedIn = login.checkLogin(username, password);
            

            if (isLoggedIn == true)
            {
                Console.WriteLine("login succesfull, Welcome back {0}!", DAL.Player.name);
            }
            else
            {
                Console.WriteLine("Login unsuccessfull, please try again");
                Console.WriteLine("do you want to register a new account? Y/N");
                string playerLoginChoice = Console.ReadLine();
                if (playerLoginChoice == "Y")
                {
                    Console.WriteLine("Please enter a username");
                    username = Console.ReadLine();
                    Console.WriteLine("Please enter a password");
                    password = Console.ReadLine();

                    login.Register(username, password);
                }
                else
                {
                    this.login();
                }
            }
        }
        public void showPlayerStats()
        {
            Console.WriteLine("{0} has the following stats:", DAL.Player.name);
            Console.WriteLine("Lives:" + DAL.Player.lives);
            Console.WriteLine("Armor:" + DAL.Player.playerArmor);
            Console.WriteLine("attackPower:" + DAL.Player.playerDamage);
            Console.ReadLine();
        }
    }
}
