using System;
namespace HeroRPG
{
    public class Rogue : Entity
    {
        public bool IsRogue = true;
        
        public override int RollDodge()
        {
            Random rnd = new Random();
            int dodge = rnd.Next(30, 45);
            return Dodge = dodge;
        }
    }
}
