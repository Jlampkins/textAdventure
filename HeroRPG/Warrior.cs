using System;
namespace HeroRPG
{
    public class Warrior : Entity
    {

        public bool IsWarrior = true;


        public override int RollHealth()
        {
            int maxHealth = ConsoleEffects.RandomNumber(125, 150);
            return MaxHealth = maxHealth;
        }

        public override int UseAttack()
        {
            int attack = ConsoleEffects.RandomNumber(8, 10);
            return Attack = attack;
        }


    }

    


}
