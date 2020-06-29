using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheYellowHouse
{
    class Item
    {

        public string name;
        private bool useable;
        private bool needsItem;
        private string description;
        private bool equipable;
        private int rating;
        private string type;

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