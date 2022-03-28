using System;
using System.Collections.Generic;


namespace VideoGame._1
{
    class CharacterRegister
    {
        private CharacterContainer allChars = new CharacterContainer();
        /// <summary>
        /// character calculations class constructor
        /// </summary>
        /// <param name="chars"></param>
        public CharacterRegister(CharacterContainer characters)
        {
            for(int i = 0; i < characters.Count; i++)
            {
                this.allChars.Add(characters.Get(i));
            }
        }

        /// <summary>
        /// Counts how many characters are in the data
        /// </summary>
        /// <returns>Number of characters</returns>
        public int CharCount()
        {
            return this.allChars.Count;
        }

        /// <summary>
        /// The character with most life points is found
        /// </summary>
        /// <param name="characters">All characters</param>
        /// <returns>The character who has the most life points</returns>
        /// 
        public Character FindCharacterWithMostLifePoints(CharacterContainer characters)
        {
            Character mostLifePoints = characters.Get(0);
            for (int i = 1; i < CharCount(); i++)
            {
                Character current = characters.Get(i);
                if (mostLifePoints.LifePoints < current.LifePoints)
                {
                    mostLifePoints = current;
                }
            }
            return mostLifePoints;
        }
        /// <summary>
        /// The character with the smallest difference between damage and defense points is found
        /// </summary>
        /// <param name="characters">All characters</param>
        /// <returns>The character with the smallest difference between damage and defence points</returns>
        public Character CharacterWithSmallestPointDifference(CharacterContainer characters)
        {
            Character smallestDifference = characters.Get(0);
            for (int i = 1; i < characters.Count; i++)
            {
                Character current = characters.Get(i);
                if (smallestDifference.DifferenceBetweenPoints() > current.DifferenceBetweenPoints())
                {
                    smallestDifference = current;
                }
            }
            return smallestDifference;
        }

        /// <summary>
        /// All character classes are found
        /// </summary>
        /// <param name="characters">All characters</param>
        /// <returns>A list of classes that the provided characters have</returns>
        public List<string> FindCharacterClasses()
        {
            List<string> characterClasses = new List<string>();
            for(int i = 0; i < CharCount(); i++)
            {
                string characterClass = allChars.Get(i).CharacterClass;
                if (!characterClasses.Contains(characterClass))
                {
                    characterClasses.Add(characterClass);
                }
            }
            return characterClasses;
        }
        /// <summary>
        /// Fins all different races in game
        /// </summary>
        /// <param name="chars"></param>
        /// <returns></returns>
        public List<string> Race()
        {
            HashSet<string> races = new HashSet<string>();
            for(int i = 0; i < CharCount(); i++)
            {
                races.Add(allChars.Get(i).Race);
            }
            List<string> race = new List<string>();
            foreach (var character in races)
            {
                race.Add(character);
            }
            return race;
        }
        /// <summary>
        /// Finds all different classes in race and calls method to find missing classes
        /// </summary>
        /// <param name="chars"></param>
        /// <param name="race"></param>
        public void ClassesInRace(string race)
        {

            HashSet<string> raceClassSet = new HashSet<string>();
           for(int i = 0; i < CharCount(); i++)
            {
                if (race.Equals(allChars.Get(i).Race))
                {
                    raceClassSet.Add(allChars.Get(i).CharacterClass);
                }

            }

            MissingClasses(FindCharacterClasses(), raceClassSet, race);
        }
        /// <summary>
        /// Finds missing classes in race
        /// And calls methot to print them out
        /// </summary>
        /// <param name="classes"></param>
        /// <param name="raceClassSet"></param>
        /// <param name="race"></param>
        private void MissingClasses(List<string> classes, HashSet<string> raceClassSet, string race)
        {

            List<string> missingClass = new List<string>();
            foreach (var charClass in classes)
            {
                if (!raceClassSet.Contains(charClass))
                {
                    missingClass.Add(charClass);
                }
            }

            if (missingClass.Count == 0)
            {
                InOut.PrintMissingClass(race);
            }
            else
            {
                InOut.PrintMissingClass(race, missingClass);
            }


        }
        /// <summary>
        /// Finds strongest character in game
        /// </summary>
        /// <param name="chars"></param>
        /// <returns>strongest character</returns>
        public Character StrongestCharacter(CharacterContainer allChars)
        {
            int mostPoints = Int32.MinValue;
            int index = 0;
            for (int i = 0; i < CharCount(); i++)
            {
                int value = allChars.Get(i).LifePoints + allChars.Get(i).DefencePoints - allChars.Get(i).DamagePoints;
                if (value > mostPoints)
                {
                    index = i;
                    mostPoints = value;
                }
            }
            Character temp = allChars.Get(index);
            Character strongest = new Character(temp.Name, temp.Race, temp.CharacterClass, temp.LifePoints,
                temp.ManaPoints, temp.DamagePoints, temp.DefencePoints, temp.Strength, temp.Agility, temp.Intelligence,
                temp.SuperPower, temp.City);

            return strongest;
        }

        /// <summary>
        /// Method finds which characters has more life points(HP) than defence points(DEF)
        /// </summary>
        /// <returns>Heroes has more life poi </returns>

        public List<Heroe> FindHeroes()
        {
            List<Heroe> Heroes = new List<Heroe>();

            for(int i = 0; i < CharCount(); i++)
            {
                if(allChars.Get(i).LifePoints > allChars.Get(i).DefencePoints)
                {
                    Character temp = allChars.Get(i);
                   Heroes.Add(new Heroe(temp.Name, temp.Race, temp.CharacterClass, temp.LifePoints,
                temp.ManaPoints, temp.DamagePoints, temp.DefencePoints, temp.Strength, temp.Agility, temp.Intelligence,
                temp.SuperPower));
                }
            }

            return Heroes;
        }
    }
}
