using System;
namespace HeroRPG
{
    public static class PotionShop
    {
        //input on what to do at the potion shop
        public static void VisitPotionShop(Entity player)
        {
            //ConsoleEffects.TypeLine("Welcome to the Potion Shop!\r\n");
            string buySell = Actions.SelectBuySell();
            if (buySell.Contains("buy"))
            {
                CheckGoldForPotion(player);
            }
            else if (buySell.Contains("sell"))
            {
                CheckPotionQuantity(player);
            }
            else if (buySell.Contains("leave"))
            {
                Actions.SelectShop(player);
            }
            else
            {
                ConsoleEffects.TypeLine("I am sorry.  I do not understand you.");
                Console.Clear();
                Actions.SelectBuySell();
            }
        }
        //input on how many potions to buy
        public static string BuyPotions()
        {
            ConsoleEffects.TypeLine("We have plenty of goods to buy.\r\n");
            Console.WriteLine("-1 Potion --- 5 gold");
            Console.WriteLine("-3 Potions --- 7 gold");
            Console.WriteLine("-Nevermind");
            string total = Console.ReadLine();
            Console.Clear();
            return total.ToLower();
        }
        //input on how many potions to sell
        public static string SellPotions()
        {
            ConsoleEffects.TypeLine("What do you have to sell?\r\n");
            Console.WriteLine("-1 Potion --- 2 gold");
            Console.WriteLine("-3 Potions --- 4 gold");
            Console.WriteLine("-Nevermind");
            string total = Console.ReadLine();
            Console.Clear();
            return total.ToLower();
        }

        //check if you have enough gold to buy potions
        public static Entity CheckGoldForPotion(Entity player)
        {
            bool stay = true;
            Item item = new Potion();
            do
            {
                string buyQuantity = BuyPotions();
                if (buyQuantity.Contains("1") || buyQuantity.Contains("one"))
                {
                    if (player.Gold >= item.Cost)
                    {
                        ConsoleEffects.TypeLine("Here you are!\r\n");
                        player.Gold -= item.Cost;
                        player.Inventory.Add(item);
                        Console.WriteLine("You received 1 " + item.Name + ". You now have " + player.Gold + " gold and " + Entity.CountInventory(player, item) + " potions"); 
                    }
                    else
                    {
                        ConsoleEffects.TypeLine("You do not have enough gold.");
                    }
                }
                else if (buyQuantity.Contains("3") || buyQuantity.Contains("three"))
                {
                    int itemDiscount = item.Cost + 2;
                    if (player.Gold >= itemDiscount)
                    {
                        ConsoleEffects.TypeLine("Here you are!\r\n");
                        player.Gold -= itemDiscount;
                        for (int i = 0; i < 3; i++)
                        {
                            player.Inventory.Add(item);
                        }
                        Console.WriteLine("You received 3 potions.  You now have " + player.Gold + " gold and " + Entity.CountInventory(player, item) + " potions");
                    }
                    else
                    {
                        ConsoleEffects.TypeLine("You do not have enough gold\r\n");
                    }
                }
                else if (buyQuantity.Contains("nevermind"))
                {
                    Console.Clear();
                    ConsoleEffects.TypeLine("Ah!  Maybe another time.\r\n");
                    stay = false;
                }
                else
                {
                    ConsoleEffects.TypeLine("Im sorry.  I do not know what you are trying to tell me.\r\n");
                }
            } while (stay);
            VisitPotionShop(player);
            return player;
        }

        //Check if you have enough potions to sell
        public static Entity CheckPotionQuantity(Entity player)
        {
            bool stay = true;
            Item item = new Potion();
            do
            {
                string potionQuantity = SellPotions();
                if (potionQuantity.Contains("1") || potionQuantity.Contains("one"))
                {
                    if (Entity.CountInventory(player, item) >= 1)
                    {
                        player.Gold += 2;
                        player.Inventory.Remove(item);
                        ConsoleEffects.TypeLine("Here you are!\r\n");
                        ConsoleEffects.TypeLine(player.Name + " received 2 gold. " + player.Name + " now has " + player.Gold + " gold and " + Entity.CountInventory(player, item) + " potions.\r\n");
                    }
                    else
                    {
                        ConsoleEffects.TypeLine("You do not have enough potions to sell");
                    }
                }
                else if (potionQuantity.Contains("3") || potionQuantity.Contains("three"))
                {
                    if (Entity.CountInventory(player, item) >= 3)
                    {
                        
                        player.Gold += 4;
                        for (int i = 0; i < 3; i++)
                        {
                            player.Inventory.Remove(item);
                        }
                        ConsoleEffects.TypeLine("Here you are!\r\n");
                        ConsoleEffects.TypeLine(player.Name + " received 4 gold. " + player.Name + " now has " + player.Gold + " gold and " + Entity.CountInventory(player, item) + " potions.\r\n");

                    }
                    else
                    {
                        ConsoleEffects.TypeLine("You do not have enough potions to sell\r\n");
                    }
                }
                else if (potionQuantity.Contains("nevermind"))
                {
                    Console.Clear();
                    ConsoleEffects.TypeLine("Ah!  Maybe another time.\r\n");
                    stay = false;
                }
                else
                {
                    ConsoleEffects.TypeLine("Im sorry.  I do not know what you are trying to tell me.\r\n");
                }
            } while (stay);
                VisitPotionShop(player);
                return player;
        }
    }
}

