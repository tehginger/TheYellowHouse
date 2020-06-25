using System;
using System.Collections.Generic;
using System.Text;

namespace TheYellowHouse
{
    class Enemy
    {
        string name;
        int health;
        int armorClass;
        string description;
        bool isAlive;


        public Enemy(string _name, int _health, int _armorClass, string _description, bool _isAlive)
        {
            name = _name;
            health = _health;
            armorClass = _armorClass;
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

        public int ArmorClass
        {
            get { return armorClass; }
        }

        public string Description
        {
            get { return description; }
        }

        public bool IsAlive
        {
            get { return isAlive; }
        }
    }
}
