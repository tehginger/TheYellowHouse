using System;
using System.Collections.Generic;
using System.Text;

namespace TheYellowHouse
{
    class Player
    {
        private int health, armorClass, damage;
        private string helm, armor, boots, weapon;
		public List<Item> inventory;
        


		public Player(int _health, int _armorClass, int _damage, string _helm, string _armor, string _boots, string _weapon)
        {
            health = _health;
            armorClass = _armorClass;
            damage = _damage;
            helm = _helm;
            armor = _armor;
            boots = _boots;
            weapon = _weapon;
            inventory = new List<Item>();
        }

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public int ArmorClass
        {
            get { return armorClass; }
            set { armorClass = value; }
        }

        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        public string Helm
        {
            get { return helm; }
            set { helm = value; }
        }

        public string Armor
        {
            get { return armor; }
            set { armor = value; }
        }

        public string Boots
        {
            get { return boots; }
            set { boots = value; }
        }

        public string Weapon
        {
            get { return weapon; }
            set { weapon = value; }
        }

        public void showInventory()
        {
            if (inventory.Count > 0)
            {
                Console.WriteLine("\nA quick look in your bag reveals the following:\n");

                foreach (Item item in inventory)
                {
                    Console.WriteLine(item.Name);
                }
            }
            else
            {
                Console.WriteLine("\nYour bag is empty.\n");
            }
        }

        public List<Item> getInventory()
		{
			return new List<Item>(inventory);
		}

		public void addItem(Item itemToAdd)
		{
			inventory.Add(itemToAdd);
		}

		public void removeItem(Item itemToRemove)
		{
			if (inventory.Contains(itemToRemove))
			{
				inventory.Remove(itemToRemove);
			}
		}

		public Item takeItem(string name)
		{
			foreach (Item _item in inventory)
			{
				if (_item.Name.ToLower() == name)
				{
					Item temp = _item;
					inventory.Remove(temp);
					return temp;
				}
			}

			return null;
		}


	}
}
