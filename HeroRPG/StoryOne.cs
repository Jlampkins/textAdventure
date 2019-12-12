using System;
namespace HeroRPG
{
    public static class StoryOne
    {
        public static void CreateCharacter()
        {

        }


        public static void FirstChapter(Entity enemy, Entity player)
        {
            ConsoleEffects.TypeLine("FIGHT!!!\r\n");
            Battles.Fight(enemy, player);


        }
            

        
    }
}
