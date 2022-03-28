using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGame._1
{
    class Character
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

        public string City { get; set; }

        /// <summary>
        /// Stored information about a specific character and his stats
        /// </summary>
        /// <param name="name">Character's name</param>
        /// <param name="race">Character's race</param>
        /// <param name="characterClass">Character's class</param>
        /// <param name="lifePoints">Amount of life points a character has</param>
        /// <param name="manaPoints">Amount of mana points a character has</param>
        /// <param name="damagePoints">Amount of damage points a character can inflict</param>
        /// <param name="defencePoints">Amount of defence points a character has</param>
        /// <param name="strength">Amount of strength points a character has</param>
        /// <param name="agility">Amount of agility points a character has</param>
        /// <param name="intelligence">Amount of intelligence points a character has</param>
        /// <param name="superPower">The name of a super power that a character has</param>
        public Character(string name, string race, string characterClass, int lifePoints, int manaPoints, int damagePoints, int defencePoints,
            int strength, int agility, int intelligence, string superPower, string city)
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
            this.City = city;
        }

        public Character(string race, string characterClass)
        {
            this.Race = race;
            this.CharacterClass = characterClass;
        }
        /// <summary>
        /// The difference between damage and defence points is counted
        /// </summary>
        /// <returns>The point difference between damage and defence points</returns>
        public int DifferenceBetweenPoints()
        {
            int pointDifference;
            if(this.DamagePoints > this.DefencePoints)
            {
                pointDifference = this.DamagePoints - this.DefencePoints;
            }
            else if (this.DamagePoints < this.DefencePoints)
            {
                pointDifference = this.DefencePoints - this.DamagePoints;
            }
            else
            {
                pointDifference = 0;
            }
            return pointDifference;
        }

        public int CompareTo(Character other)
        {
            int comp = this.LifePoints.CompareTo(other.LifePoints);
           
            if(comp == 0)
            {
                comp = this.DefencePoints.CompareTo(other.DefencePoints);
            }

            if(comp == 0)
            {
                comp = this.Name.CompareTo(other.Name);
            }

            return comp;
        }
    }
}
