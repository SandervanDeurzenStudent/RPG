using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_console.DAL
{
   public class Battle
    {
        List<Enemy> Enemylist = new List<Enemy>();

        public void SetBattle(List<Enemy> enemies)
        {
            Random rnd = new Random();
            foreach (var enemy in enemies)
            {
                int playerAttackDamage = rnd.Next(1, Player.playerDamage);
                int enemyAttackDamage = rnd.Next(1, enemy.Damage);
                //enemy armor?
                while (enemy.Armor > 0)
                {
                    if (Player.playerArmor <= 0)
                    {
                        Console.WriteLine("player armor has broke");
                        break;
                    }
                    enemy.Armor = enemy.Armor - playerAttackDamage;
                    Console.WriteLine(" Player attacks with {0} Damage!", playerAttackDamage);
                    Console.WriteLine("{0} has {1} armor left!", enemy.name, enemy.Armor);
                    Console.ReadLine();



                    if (enemy.Armor <= 0)
                    {
                        Console.WriteLine("Enemy armor has broke!");
                        break;
                    }
                    Console.WriteLine(enemy.name + " attacks with {0} Damage!", enemyAttackDamage);
                    Player.playerArmor = Player.playerArmor - enemyAttackDamage;
                    Console.WriteLine("{0} has {1} Armor left!", Player.name, Player.playerArmor);
                    Console.ReadLine();
                }
                while (enemy.lives > 0)
                {
                       
                    //first player gets to attack

                    if (Player.lives <= 0)
                    {
                        Player player = new Player();
                        player.playerLivesUp();
                        break;
                    }
                    if (enemy.Armor <= 0)
                    {
                        Console.WriteLine(" Player attacks with {0} Damage!", playerAttackDamage);
                        enemy.lives = enemy.lives - playerAttackDamage;
                        Console.WriteLine("{0} has {1} lives left!", enemy.name, enemy.lives);
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine(" Player attacks with {0} Damage!", playerAttackDamage);
                        enemy.Armor = enemy.Armor - playerAttackDamage;
                        Console.WriteLine("{0} has {1} armor left!", enemy.name, enemy.Armor);
                        Console.ReadLine();
                    }
                    


                    //then enemy gets to attack

                    //check if enemies been defeated
                    if (enemy.lives <= 0)
                    {
                        Console.WriteLine("{0} is defeated!", enemy.name);
                        break;
                    }
                    if(Player.playerArmor <= 0)
                    {
                        Console.WriteLine(enemy.name + " attacks with {0} Damage!", enemyAttackDamage);
                        Player.lives = Player.lives - enemyAttackDamage;
                        Console.WriteLine("{0} has {1} lives left!", Player.name, Player.lives);
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine(enemy.name + " attacks with {0} Damage!", enemyAttackDamage);
                        Player.playerArmor = Player.playerArmor - enemyAttackDamage;
                        Console.WriteLine("{0} has {1} armor left!", Player.name, Player.playerArmor);
                        Console.ReadLine();
                    }

                    

                    //all enemies died before the player so win message
                }
                //Console.WriteLine(enemy.name + " " + enemy.lives);
                //Console.ReadLine();
            }
                //the trooper died so his name is passed
                SetWinner();
        }
        public void addEnemy(string name, int lives, int Damage, int Armor)
        {
            Enemylist.Add(new Enemy(name, lives, Damage, Armor));
        }
        public void SetWinner()
        {
            Console.WriteLine("All Enemies have been defeated!");
            Console.ReadLine();
            //Program program = new Program();
            //program.level2();
        }
    }
}
