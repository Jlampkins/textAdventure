using System;
namespace HeroRPG
{
    public static class Battles
    {

        //Battle Process
        public static void Fight(Entity enemy, Entity player)
        {
            do
            {
                bool wrongAnswer;
                do
                {
                    wrongAnswer = false;
                    string selectBattlePlan = Actions.SelectBattlePlan(player);
                    if (selectBattlePlan.Contains("attack"))
                    {
                        AttackEnemy(enemy, player);
                    }
                    //uses magic if magic
                    else if (selectBattlePlan.Contains("magic") && player.IsMage())
                    {
                        UseMagicFire((Mage)player, enemy);
                    }
                    else if (selectBattlePlan.Contains("potion"))
                    {
                        if (Entity.CheckInventory(player, "potion"))
                        {
                            Item potion = Entity.GetItemFromInventory(player, "potion");
                            Entity.UsePotion(player, potion);
                        }
                        else
                        {
                            ConsoleEffects.TypeLine("I am afraid you do not have any potions.\r\n");
                            wrongAnswer = true;
                        }
                    }
                    else
                    {
                        ConsoleEffects.TypeLine("\r\nI'm afraid that isn't an option.\r\n");
                        wrongAnswer = true;
                    }
                } while (wrongAnswer);

                if (enemy.Health > 0 && player.Health > 0)
                {
                    AttackPlayer(enemy, player);
                }

            } while (enemy.Health > 0 && player.Health > 0);

            if (enemy.Health <= 0)
            {
                ConsoleEffects.TypeLine(player.Name + " wins!\r\n");
                LootEnemy(player, enemy);
            }
            else if (player.Health <= 0)
            {
                ConsoleEffects.TypeLine(player.Name + " has fainted.\r\n");
                Inn.Sleep(player);
            }
        }
//End Fight Process



        public static int LootEnemy(Entity player, Entity enemy)
        {
            int goldAmount = ConsoleEffects.RandomNumber(8, enemy.Gold);
            ConsoleEffects.TypeLine(enemy.Name + " dropped " + goldAmount + " gold.\r\n");
            player.Gold += goldAmount;
            ConsoleEffects.TypeLine(player.Name + " now has " + player.Gold + " gold.");

            return player.Gold;
        }


        public static (int,int) UseMagicSmite(Priest player, Entity enemy)
        {
            if (player.Mana < 8)
            {
                ConsoleEffects.TypeLine("You do not have enough mana to do this.\r\n");
                return (enemy.Health, player.Mana);
            }
            int playerAttack = player.CastSmite();
            ConsoleEffects.TypeLine(player.Name + " cast smite. " + enemy.Name + " has been hit for " + playerAttack + "\r\n");
            enemy.Health -= playerAttack;
            player.Mana -= 8;
            CheckHealth(enemy);
            ConsoleEffects.TypeLine(player.Name + " has " + player.Mana + " left.\r\n");
            ConsoleEffects.TypeLine(enemy.Name + " has " + enemy.Health + " health.\r\n\r\n");
            return (enemy.Health, player.Mana);
        }

        public static (int, int) UseMagicFire(Mage player, Entity enemy)
        {
            if (player.Mana < 8)
            {
                ConsoleEffects.TypeLine("You do not have enough mana to do this.\r\n");
                return (enemy.Health, player.Mana);
            }
            int playerAttack = player.CastFire();
            ConsoleEffects.TypeLine("\r\n" + player.Name + " casts fire. " + enemy.Name + " has been hit for " + playerAttack + "\r\n");
            enemy.Health -= playerAttack;

            int playerMana = player.UseMana(8);
            CheckHealth(enemy);
            ConsoleEffects.TypeLine(player.Name + " has " + playerMana+ " mana left.\r\n");
            ConsoleEffects.TypeLine(enemy.Name + " has " + enemy.Health + " health.\r\n\r\n");
            return (enemy.Health, playerMana);
        }

        //used when an enemy attacks a player
        public static int AttackPlayer(Entity enemy, Entity player)
        {
            int enemyAttack = enemy.UseAttack();
            int chance = ConsoleEffects.RandomNumber(1, 5);
            if (chance <= 3)
            {
                player.Health -= enemyAttack;
                CheckHealth(player);
                Console.WriteLine(enemy.Name + " hit " + player.Name + " for " + enemyAttack + ".");
                ConsoleEffects.TypeLine(player.Name + " has " + player.Health + " health.\r\n\r\n");
                return player.Health;
            }
            //enemy hits twice
            if (chance == 4)
            {
                ConsoleEffects.TypeLine(enemy.Name + " hit " + player.Name + " for " + enemyAttack + ".\r\n");
                //possible random to decide damage
                int secondEnemyAttack = enemy.UseAttack();
                player.Health -= (enemyAttack + secondEnemyAttack);
                CheckHealth(player);
                System.Threading.Thread.Sleep(500);
                ConsoleEffects.ColorTextRed(enemy.Name + " hits for a second attacks. " + enemy.Name + " hit " + player.Name + " for " + secondEnemyAttack + ".");
                ConsoleEffects.TypeLine(player.Name + " has " + player.Health + " health.\r\n\r\n");
                return player.Health;
            }
            Console.WriteLine(player.Name + " dodged the attack.\r\n");
            return player.Health;
        }

        //used when a player attacks an enemy
        public static int AttackEnemy(Entity enemy, Entity player)
        {
            int playerAttack = player.UseAttack();
            int chance = ConsoleEffects.RandomNumber(1, 5);
            if (chance <= 3)
            {
                enemy.Health -= player.Attack;
                Console.WriteLine("\r\n" + player.Name + " hit " + enemy.Name + " for " + playerAttack + ".");
                CheckHealth(enemy);
                ConsoleEffects.TypeLine(enemy.Name + " has " + enemy.Health + " health.\r\n\r\n");
                return enemy.Health;
            }
            //double attack
            else if (chance == 4)
            {
                Console.WriteLine("\r\n" + player.Name + " hit " + enemy.Name + " for " + playerAttack + ".");
                System.Threading.Thread.Sleep(500);
                //possible random to decide damage
                int secondPlayerAttack = player.UseAttack();
                enemy.Health -= (playerAttack + secondPlayerAttack);
                ConsoleEffects.ColorTextGreen(player.Name + " hits for a second attacks. " + player.Name + " hit " + enemy.Name + " for " + secondPlayerAttack + ".");
                CheckHealth(enemy);
                ConsoleEffects.TypeLine(enemy.Name + " has " + enemy.Health + " health.\r\n\r\n");
                
                return enemy.Health;
            }
            else if(chance == 5)
            {
                Console.WriteLine(enemy.Name + " dodged the attack.\r\n\r\n");
                return enemy.Health;
            }
            return enemy.Health;
        }

        public static (bool, int) CheckHealth(Entity victim)
        {
            if (victim.Health < 0)
            {
                victim.Health = 0;
                return (true, victim.Health);
            }
            return (false, victim.Health);
        }

    }
}
