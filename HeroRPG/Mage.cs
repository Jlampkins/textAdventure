using System;
namespace HeroRPG
{
    public class Mage : Entity
    {
        //public new bool IsMage = true;
        //public new bool IsMagicClass = true;
        //public int MagicAttack;

        public override bool IsMage()
        {
            return true;
        }

        public override bool IsMagicClass()
        {
            return true;
        }

        public override int RollMana()
        {
            int maxMana = ConsoleEffects.RandomNumber(25, 33);
            return MaxMana = maxMana;
        }



        public int CastFire()
        {
            int attack = ConsoleEffects.RandomNumber(10, 15);
            return MagicAttack = attack;
        }

        public int CastFreeze()
        {
            int attack = ConsoleEffects.RandomNumber(5, 8);
            return MagicAttack = attack;
            //should also freeze the enemy causing it to lose a turn.  Enabled at higher level
        }

        public override int UseAttack()
        {
            int attack = ConsoleEffects.RandomNumber(3, 5);
            return Attack = attack;
        }





    }


}
