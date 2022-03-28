using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGame._1
{
    class Heroe
    {
        public string Name { get; set; }
        public string Race { get; set; }
        public string CharacterClass { get; set; }
        public int LifePoints { get; set; }
        public int ManaPoints { get; set; }
        public int DamagePoints { get; set; }
        public int DefencePoints { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }
        public string SuperPower { get; set; }

        public Heroe(string name, string race, string characterClass, int lifePoints, int manaPoints, int damagePoints, int defencePoints,
            int strength, int agility, int intelligence, string superPower)
        {
            this.Name = name;
            this.Race = race;
            this.CharacterClass = characterClass;
            this.LifePoints = lifePoints;
            this.ManaPoints = manaPoints;
            this.DamagePoints = damagePoints;
            this.DefencePoints = defencePoints;
            this.Strength = strength;
            this.Agility = agility;
            this.Intelligence = intelligence;
            this.SuperPower = superPower;
        }
    }
}
