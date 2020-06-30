namespace TheYellowHouse
{
    class Enemy
    {
        private string name, description;
        private int health, armorClass, damage, score;
        private bool isAlive;

        public Enemy(string _name, int _health, int _armorClass, int _damage, string _description, bool _isAlive, int _score)
        {
            name = _name;
            health = _health;
            armorClass = _armorClass;
            damage = _damage;
            description = _description;
            isAlive = _isAlive;
            score = _score;
        }

        public string Name
        {
            get { return name;  }
        }

        public int Health
        {
            get { return health; }
            set { health = value; }
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
            set { isAlive = value; }
        }

        public int Score
        {
            get { return score; }
        }
    }
}
