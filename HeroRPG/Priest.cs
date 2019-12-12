using System;
namespace HeroRPG
{
    public class Priest : Entity
    {
        public bool IsPriest = true;
        public new bool IsMagicClass = true;
        public int MagicAttack { get; set; }



        public override int RollMana()
        {
            int maxMana = ConsoleEffects.RandomNumber(30, 38);
            return MaxMana = maxMana;
        }

        public int CastShield()
        {
            //should replenish health for a short time.
            return 0;
        }

        public int CastHeal()
        {
            int heal = ConsoleEffects.RandomNumber(5, 8);
            return Health += heal;
        }

        public int CastSmite()
        {
            int attack = ConsoleEffects.RandomNumber(5, 8);
            return MagicAttack = attack;
              
        }

    }
}
