namespace TheYellowHouse
{
    class Item
    {

        private string name, description, type;
        private bool useable, equipable;
        private int rating;

        public Item(string _name, bool canUse, string _description)
        {
            name = _name;
            useable = canUse;
            description = _description;
        }

        public Item(string _name, bool _equipable, int _rating, string _type, string _description)
        {
            name = _name;
            equipable = _equipable;
            rating = _rating;
            type = _type;
            description = _description;
        }

        public string Name
        {
            get { return name; }
        }

        public bool Useable
        {
            get { return useable; }
        }

        public string Description
        {
            get { return description; }
        }

        public bool Equipable
        {
            get { return equipable; }
        }

        public int Rating
        {
            get { return rating; }
        }

        public string Type
        {
            get { return type; }
        }
    }
}