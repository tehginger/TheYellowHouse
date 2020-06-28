using System;
using System.Collections.Generic;
using System.Text;

namespace TheYellowHouse
{
    class Enemy
    {
        private string name;
        private int health;
        private int armorClass;
        private int damage;
        private string description;
        private bool isAlive;


        public Enemy(string _name, int _health, int _armorClass, int _damage, string _description, bool _isAlive)
        {
            name = _name;
            health = _health;
            armorClass = _armorClass;
            damage = _damage;
            description = _description;
            isAlive = _isAlive;
        }

        public string Name
        {
            get { return name;  }
        }

        public int Health
        {
            get { return health; }
        }

        public void setHealth(int amount)
        {
            health = amount;
        }

        public int ArmorClass
        {
            get { return armorClass; }
        }

        public int Damage
        {
            get { return damage; }
        }

        public string Description
        {
            get { return description; }
        }

        public bool IsAlive
        {
            get { return isAlive; }
        }

        public void setAlive(bool status)
        {
            isAlive = status;
        }
    }
}
