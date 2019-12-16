using System;
using System.Linq;

namespace HeroRPG
{
    public static class WeaponShop
    {
        public static void VisitWeaponShop(Entity player)
        {
            //ConsoleEffects.TypeLine("Welcome to the Potion Shop!\r\n");
            string buySell = Actions.SelectBuySell();
            if (buySell.Contains("buy"))
            {
                CheckGoldToBuy(player, CreateItemSelected(player));
            }
            else if (buySell.Contains("sell"))
            {
                CheckQuantityToSell(player, CheckItemSelected(player));
            }
            else if (buySell.Contains("leave"))
            {
                Actions.SelectShop(player);
            }
            else
            {
                ConsoleEffects.TypeLine("I am sorry.  I do not understand you.");
                Console.Clear();
                VisitWeaponShop(player);
            }
            VisitWeaponShop(player);
        }

        public static string BuyWeapons()
        {
            ConsoleEffects.TypeLine("We have plenty of goods to buy.\r\n");
            Console.WriteLine("Axe --- 12 gold");
            Console.WriteLine("Sword --- 10 gold");
            Console.WriteLine("Staff --- 15 gold");
            Console.WriteLine("Sceptor --- 15 gold");
            Console.WriteLine("Dagger --- 13 gold");
            Console.WriteLine("-Nevermind");
            string total = Console.ReadLine();
            Console.Clear();
            return total.ToLower();
        }

        public static string SellWeapons()
        {
            ConsoleEffects.TypeLine("What do you have to sell?\r\n");
            Console.WriteLine("Axe --- 6 gold");
            Console.WriteLine("Sword --- 5 gold");
            Console.WriteLine("Staff --- 7 gold");
            Console.WriteLine("Sceptor --- 7 gold");
            Console.WriteLine("Dagger --- 4 gold");
            Console.WriteLine("-Nevermind");
            string total = Console.ReadLine();
            Console.Clear();
            return total.ToLower();
        }

        //this should check for any item
        //why not have one shop?
        public static Item CreateItemSelected(Entity player)
        {
            string itemType = BuyWeapons();
            Item item;
            if (itemType.Contains("nevermind"))
            {
                VisitWeaponShop(player);
            }
            //if (itemType.Contains("axe"))
            //{
            //    item = new Axe();
            //    return item;
            //}
            if (itemType.Contains("sword"))
            {
                item = new Sword();
                return item;
            }
            ConsoleEffects.TypeLine("I am sorry.  I do not understand what you want.");
            return CreateItemSelected(player);
        }

        public static Item CheckItemSelected(Entity player)
        {
            
            string itemType = SellWeapons();
            Item item = player.Inventory.FirstOrDefault(o => o.Name == itemType);
            if (itemType.Contains("axe") && item.Name == "axe")
            {
                return item;
            }
            ConsoleEffects.TypeLine("You do not own " + itemType + ".\r\n");
            CheckItemSelected(player);
            return null;
            

        }


        public static Entity CheckGoldToBuy(Entity player, Item item)
        {
            if (player.Gold >= item.Cost)
            {
                ConsoleEffects.TypeLine("Here you are!\r\n");
                player.Gold -= item.Cost;
                player.Inventory.Add(item);
                Console.WriteLine("You received 1 " + item.Name + ". You now have " + player.Gold + " gold and " + Entity.CountInventory(player, item) + " " + item.Name);
                //CheckItemSelected();
            }
            else
            {
                ConsoleEffects.TypeLine("You do not have enough gold.");
                //CheckItemSelected();
            }
            CreateItemSelected(player);
            return player;
        }


        //check the quantity of the item
        public static Entity CheckQuantityToSell(Entity player, Item item)
        {
            if (Entity.CountInventory(player, item) >= 1)
            {
                Console.WriteLine("Great!  Thanks!\r\n");
                player.Gold += item.SalePrice;
                player.Inventory.Remove(item);
                ConsoleEffects.TypeLine("You received " + item.SalePrice + " gold.\r\n");
            }
            else
            {
                ConsoleEffects.TypeLine("You do not own any " + item.Name + "s\r\n");
                VisitWeaponShop(player);
            }
            return player;
        }

    }
}
