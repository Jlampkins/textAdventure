using System;
namespace HeroRPG
{
    public class Potion : Item
    {
        public Potion()
        {
            Name = "potion";
            Cost = 5;
            Heal = 8;
            SalePrice = 2;
        }
    }
}
