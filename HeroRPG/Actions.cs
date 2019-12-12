using System;
namespace HeroRPG
{
    public static class Actions
    {

        public static void SelectAttackOptions(Entity player)
        {
            Console.WriteLine("-Attack");
            if (player.IsMagicClass())
            {
                Console.WriteLine("-Magic");
            }
            Console.WriteLine("-Items");
            Console.WriteLine("-Run");
        }

        //inspects a character
        public static void CheckCharacter(string name, string chosenClass, int level, int health, int dodge, int mana, int gold)
        {
            Console.Clear();
            Console.WriteLine(name + " the " + chosenClass + ".");
            Console.WriteLine("Your current level is " + level + ".");
            Console.WriteLine("You have " + gold + " gold.");
            Console.WriteLine("Your Health is " + health + ".");
            Console.WriteLine("Your dodge is " + dodge + ".");
            Console.WriteLine("Your mana is " + mana + ".");
        }

        //inpsects the town
        public static string CheckTown()
        {
            Console.Clear();
            ConsoleEffects.TypeLine("You are now in town. Where would you like to go?\r\n");
            Console.WriteLine("-Potion Shop");
            Console.WriteLine("-Weapon Shop");
            Console.WriteLine("-Inn");
            Console.WriteLine("-Leave town");
            string shop = Console.ReadLine();
            Console.Clear();
            return shop.ToLower();
        }

        //selects which shop you want to visit: Potion, Weapon or Inn
        public static void SelectShop(Entity player)
        {
                string shopChoice = CheckTown();
                if (shopChoice.Contains("potion"))
                {
                    PotionShop.VisitPotionShop(player);
                }
                else if (shopChoice.Contains("weapon"))
                {
                    WeaponShop.VisitWeaponShop(player);
                }
                else if (shopChoice.Contains("inn"))
                {
                    Inn.VisitInn(player);
                }
                else if (shopChoice.Contains("leave"))
                {
                    ConsoleEffects.TypeLine("Good luck out there!\r\n");
                    ConsoleEffects.PressEnter();
                return;
                
                }
                else
                {
                    SelectShop(player);
                }
        }

        //choose to buy or sell
        public static string SelectBuySell()
        {
            ConsoleEffects.TypeLine("What can I do for you?\r\n");
            Console.WriteLine("-Buy");
            Console.WriteLine("-Sell");
            Console.WriteLine("-Leave");
            string buySell = Console.ReadLine();
            Console.Clear();
            return buySell.ToLower();
        }

        public static string SelectSleep()
        {
            ConsoleEffects.TypeLine("What can I do for you?\r\n");
            Console.WriteLine("-Rent a room");
            Console.WriteLine("-Leave");
            string sleepChoice = Console.ReadLine();
            Console.Clear();
            return sleepChoice.ToLower();
        }



        public static string SelectBattlePlan(Entity player)
        {
            ConsoleEffects.TypeLine("What would you like to do?\r\n");
            Console.WriteLine("-attack");
            //shows magic option if mage
            if (player.IsMagicClass())
            {
                Console.WriteLine("-magic");
            }

            Console.WriteLine("-potion");
            string battleChoice = Console.ReadLine();
            return battleChoice.ToLower();
        }


    }
}