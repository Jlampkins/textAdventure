using System;
namespace HeroRPG
{
    public class Inn
    {
        public static void VisitInn(Entity player)
        {
            
            string sleepTalk = Actions.SelectSleep();
            if (sleepTalk.Contains("rent"))
            {
                Sleep(player);
            }
            else if (sleepTalk.Contains("talk"))
            {
                //provide additional information based on story.
            }
            else if (sleepTalk.Contains("leave"))
            {
                Actions.SelectShop(player);
            }
            else
            {
                ConsoleEffects.TypeLine("I am sorry.  I do not understand you.");
                Console.Clear();
                VisitInn(player);
            }
            return;
        }




        public static (int,int) Sleep(Entity player)
        {
            
            ConsoleEffects.SpeedLine("zz..zzzz..zzz...zzz.zzzzzz\r\n", 100);
            ConsoleEffects.PressEnter();
            player.Health = player.MaxHealth;
            ConsoleEffects.TypeLine(player.Name + "'s health is now at " + player.Health +"\r\n");
            if (player.IsMagicClass())
            {
                player.Mana = player.MaxMana;
                ConsoleEffects.TypeLine(player.Name + "'s mana is now at " + player.Mana +"\r\n");
            }
            ConsoleEffects.PressEnter();
            VisitInn(player);
            return (player.Health, player.Mana);
            
        }
    }
}
