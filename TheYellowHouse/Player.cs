using System;
using System.Collections.Generic;
using System.Text;

namespace TheYellowHouse
{
    class Player
    {
        private int health;
        private int armorClass;
        private bool isAlive;
		public List<Item> inventory;
        


		public Player(int _health, int _armorClass, bool _isAlive)
        {
            health = _health;
            armorClass = _armorClass;
            isAlive = _isAlive;
            inventory = new List<Item>();
        }

        public int Health
        {
            get { return health; }
        }

        public int ArmorClass
        {
            get { return armorClass; }
        }

        public bool IsAlive
        {
            get { return isAlive; }
        }


        //This may be wrong
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
