using System;
using System.Collections.Generic;

namespace HeroRPG
{
    public abstract class Entity
    {
        public int MaxHealth = 25;
        public int Health = 25;
        public int MaxMana { get; set; }
        public int Mana { get; set; }
        public int Gold = 25;
        public int Dodge = 25;
        public int Experience { get; set; }
        public int Level = 1;
        public int Attack { get; set; }
        public int MagicAttack { get; set; }
        public int Defence { get; set; }
        public string Name { get; set; }
        public List<Item> Inventory = new List<Item>();


        public virtual int RollDodge() { return 0; }
        public virtual int RollHealth() { return 0; }
        public virtual int RollMana() { return 0; }
        public virtual bool IsMage() { return false; }
        public virtual bool IsMagicClass() { return false; }
        public virtual int UseAttack() { return 0; }
        public virtual int UseMana(int manaUsed)
        {
            return Mana -= manaUsed;
        }

        public static bool CheckInventory(Entity player, string item)
        {
            for (int i = 0; i < player.Inventory.Count; i++)
            {
                if (player.Inventory[i].Name == item)
                {
                    return true;
                }
            }
            return false;
        }

        public static Item GetItemFromInventory(Entity player, string item)
        {
            for (int i = 0; i < player.Inventory.Count; i++)
            {
                if (player.Inventory[i].Name == item)
                {
                    return player.Inventory[i];
                }
            }
            return null;
        }

        //counts an item in the players inventory
        public static int CountInventory(Entity player, Item item)
        {
            int itemCount = 0;
            for (int i = 0; i < player.Inventory.Count; i++)
            {
                if (player.Inventory[i].Name == item.Name)
                {
                    itemCount += 1;
                }
            }
            return itemCount;
        }

        public static Entity UsePotion(Entity entity, Item potion)
        {
            int entityHealth = entity.Health += potion.Heal;
            entity.Inventory.Remove(potion);

            int overHeal;
            int potionHeal;
            if (entityHealth > entity.MaxHealth)
            {
                overHeal = entity.Health - entity.MaxHealth;
                potionHeal = potion.Heal - overHeal;
                entity.Health = entity.MaxHealth;
            }
            else
            {
                potionHeal = potion.Heal;
            }
            ConsoleEffects.TypeLine("\r\n" + entity.Name + " used " + potion.Name + " and gained " + potionHeal + " health.\r\n");
            ConsoleEffects.TypeLine(entity.Name + " now has " + entity.Health + " health.\r\n\r\n");
            return entity;
        }

    }
}
