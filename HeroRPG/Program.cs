using System;
using System.Collections.Generic;

namespace HeroRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Entity player = null;
            int health;
            int dodge;
            int mana;
            int gold;
            int level = 1;
            string redo;
            string name;
            List<Item> inventory = new List<Item>();
            string chosenClass;
            //string shop = "";
            
            ConsoleEffects.TypeLine("Greeting, traveller\r\n");
            ConsoleEffects.TypeLine("I see you are looking for adventure.");
            do
            {
                

                
                health = 0;
                dodge = 0;
                mana = 0;
                gold = 0;
                chosenClass = "";
                bool stop = false;
                bool providedName;
                ConsoleEffects.TypeLine(" What should I call you?\r\n");
                do
                {
                    providedName = true;
                    name = Console.ReadLine();
                    if (string.IsNullOrEmpty(name))
                    {
                        Console.WriteLine("Everyone has a name!  What is yours?");
                        providedName = false;
                    }
                } while (providedName == false);

                name = ConsoleEffects.FirstCharToUpper(name);
                do
                {
                    ConsoleEffects.TypeLine("\r\nWhat class are you interested in?\r\n");
                    Console.WriteLine("Warrior");
                    Console.WriteLine("Mage");
                    Console.WriteLine("Rogue");
                    string study = Console.ReadLine();
                    switch (study.ToLower())
                    {
                        case "warrior":
                            player = new Warrior();
                            player.Name = name;
                            player.MaxHealth = player.RollHealth();
                            player.Health = player.MaxHealth;
                            health = player.Health;
                            dodge = player.Dodge;
                            level = player.Level;
                            gold = player.Gold;
                            chosenClass = "Warrior";
                            inventory = player.Inventory;
                            stop = true;
                            break;
                        case "mage":
                            player = new Mage();
                            player.Name = name;
                            player.MaxMana = player.RollMana();
                            mana = player.MaxMana;
                            player.Mana = mana;
                            health = player.Health;
                            dodge = player.Dodge;
                            level = player.Level;
                            gold = player.Gold;
                            chosenClass = "Mage";
                            inventory = player.Inventory;
                            stop = true;
                            break;
                        case "rogue":
                            player = new Rogue();
                            player.Name = name;
                            player.Dodge = player.RollDodge();
                            dodge = player.Dodge;
                            health = player.Health;
                            level = player.Level;
                            gold = player.Gold;
                            chosenClass = "Rogue";
                            inventory = player.Inventory;
                            stop = true;
                            break;
                        default:
                            ConsoleEffects.TypeLine("I am afraid I am not familiar with that line of study.  Please select again\r\n");
                            break;
                    }
                } while (stop == false);

                Actions.CheckCharacter(name, chosenClass, level, health, dodge, mana, gold);
                ConsoleEffects.TypeLine("\r\nIs this okay?\r\n");
                Console.WriteLine("-No, start over");
                Console.WriteLine("-Yes, that is correct");
                redo = Console.ReadLine();
                Console.Clear();
            } while (redo.ToLower().Contains("no"));

            Actions.SelectShop(player);
            Entity enemy = new Mage();
            enemy.Name = "Bad Guy";
            enemy.Health = health;
            StoryOne.FirstChapter(enemy, player);

        }
    }
}
