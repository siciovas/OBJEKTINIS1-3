using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace VideoGame._1
{
    static class InOut
    {
        /// <summary>
        /// All characters and their information are read from a provided file
        /// </summary>
        /// <param name="fileName">Name of the file being used in the process</param>
        /// <returns>Different types of information about a character taken from a given file</returns>

        public static CharacterContainer ReadCharacters (string fileName)
        {
            CharacterContainer characters = new CharacterContainer();
            var firstLines = File.ReadLines(fileName, Encoding.UTF8).Take(2).ToList();
            string race = firstLines[0];
            string city = firstLines[1];
            string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in lines.Skip(2))
            {
                string[] values = line.Split(',');
                string name = values[0];
                string characterClass = values[1];
                int lifePoints = int.Parse(values[2]);
                int manaPoints = int.Parse(values[3]);
                int damagePoints = int.Parse(values[4]);
                int defencePoints = int.Parse(values[5]);
                int strength = int.Parse(values[6]);
                int agility = int.Parse(values[7]);
                int intelligence = int.Parse(values[8]);
                string superPower = values[9];
                Character character = new Character(name, race, characterClass, lifePoints, manaPoints, damagePoints,
                   defencePoints, strength, agility, intelligence, superPower, city);
                characters.Add(character);

            }
            return characters;
        }
        /// <summary>
        /// Characters a read from file and added to already created list
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="characters"></param>
        /// <returns></returns>
        public static CharacterContainer ReadCharacters(string fileName, CharacterContainer characters)
        {
            var firstLines = File.ReadLines(fileName, Encoding.UTF8).Take(2).ToList();
            string race = firstLines[0];
            string city = firstLines[1];
            string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in lines.Skip(2))
            {
                string[] values = line.Split(',');
                string name = values[0];
                string characterClass = values[1];
                int lifePoints = int.Parse(values[2]);
                int manaPoints = int.Parse(values[3]);
                int damagePoints = int.Parse(values[4]);
                int defencePoints = int.Parse(values[5]);
                int strength = int.Parse(values[6]);
                int agility = int.Parse(values[7]);
                int intelligence = int.Parse(values[8]);
                string superPower = values[9];
                Character character = new Character(name, race, characterClass, lifePoints, manaPoints, damagePoints,
                    defencePoints, strength, agility, intelligence, superPower, city);
                characters.Add(character);

            }
            return characters;
        }
        /// <summary>
        /// All characters and their stats are printed to the console
        /// </summary>
        /// <param name="characters">All characters</param>
        public static void PrintCharacters(CharacterContainer characters)
        {
            Console.WriteLine(new string('-', 204));
            Console.WriteLine("| {0,15} | {1,-15} |  {2,-10} | {3,-15} | {4,-15} | {5,-11} | {6,-15} | {7,-15} | {8,-10} | {9,-10} | {10,-10} | {11,-20} |",
                "Vardas", "Rasė","Miestas", "Klasė", "Gyvybės taškai", "Mana", "Žalos taškai", "Gynybos taškai", "Jėga", "Vikrumas", "Intelektas",
                "Ypatinga galia");
            Console.WriteLine(new string('-', 204));
            for(int i = 0; i < characters.Count; i++)
            {
                Character character = characters.Get(i);
                Console.WriteLine("| {0,15} | {1,-15} |  {2,-10} | {3,-15} | {4,-15} | {5,-11} | {6,-15} | {7,-15} | {8,-10} | {9,-10} | {10,-10} | {11,-20} | ",
                    character.Name, character.Race, character.City, character.CharacterClass, character.LifePoints, character.ManaPoints, character.DamagePoints,
                    character.DefencePoints, character.Strength, character.Agility, character.Intelligence, character.SuperPower);
            }
            Console.WriteLine(new string('-', 204));

        }
        /// <summary>
        /// All character classes are printed to a CSV file
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <param name="characters">All characters</param>
        public static void PrintCharacterClassesToCSV(string fileName, List<string> characters)
        {
            string[] lines = new string[characters.Count];
            for (int i = 0; i < characters.Count; i++)
            {
                lines[i] = String.Format("{0}", characters[i]);
            }
            File.WriteAllLines(fileName, lines);
            
        }
        /// <summary>
        /// Prints the information take from the given CSV file to a new txt file
        /// </summary>
        /// <param name="fileName">Name of the file being used</param>
        /// <param name="characters">All characters</param>
        public static void PrintCharacteresToTxtFile(string fileName, CharacterContainer characters)
        {
            string[] lines = new string[characters.Count + 4];
            lines[0] = String.Format(new string('-', 204));
            lines[1] = String.Format("| {0,15} | {1,-15} | {2,-15} | {3,-15} | {4,-15} | {5,-15} | {6,-15} | {7,-15} | {8,-15} | {9,-15} | {10,-20} |", "Vardas", "Rasė",
                "Klasė", "Gyvybės taškai", "Mana", "Žalos taškai", "Gynybos taškai", "Jėga", "Vikrumas", "Intelektas", "Ypatinga galia");
            lines[2] = String.Format(new string('-', 204));
            for (int i = 0; i < characters.Count; i++)
            {
                Character character = characters.Get(i);
                lines[i + 3] = String.Format("| {0,15} | {1,-15} | {2,-15} | {3,-15} | {4,-15} | {5,-15} | {6,-15} | {7,-15} | {8,-15} | {9,-15} | {10,-20} |",
                    character.Name, character.Race, character.CharacterClass, character.LifePoints, character.ManaPoints,
                    character.DamagePoints, character.DefencePoints, character.Strength, character.Agility, character.Intelligence,
                    character.SuperPower);
            }
            lines[characters.Count +  3] = String.Format(new string('-', 204));
            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }
        /// <summary>
        /// Prints missing classes in race
        /// </summary>
        /// <param name="race"></param>
        /// <param name="missingClasses"></param>
        public static void PrintMissingClass(string race, List<string> missingClasses)
        {
            string filename = "Trūkstami.csv";
            using (StreamWriter writer = File.AppendText(filename))
            {
                writer.WriteLine("{0}:", race);
                foreach (var VARIABLE in missingClasses)
                {
                    writer.WriteLine(VARIABLE);
                }
            }
        }
        /// <summary>
        /// this method gets called instead if race isn't missing any classes
        /// </summary>
        /// <param name="race"></param>
        public static void PrintMissingClass(string race)
        {
            string filename = "Trūkstami.csv";
            using (StreamWriter writer = File.AppendText(filename))
            {
                writer.WriteLine("{0}:", race);
                writer.WriteLine("VISI");
            }
        }
        /// <summary>
        /// Prints strongest character in game
        /// </summary>
        /// <param name="strongest"></param>
        public static void PrintStrongest(Character strongest)
        {
            Console.WriteLine("Strongest character:");
            Console.WriteLine("| {0,-15} | {1,-15} | {2,-15} | {3,15} | {4,15} | {5,15} | {6,15} | {7,15} | {8,-15} | {9,-15} | {10,20} |", "Vardas", "Rasė",
                "Klasė", "Gyvybės taškai", "Mana", "Žalos taškai", "Gynybos taškai", "Jėga", "Vikrumas", "Intelektas", "Ypatinga galia");
           
                Console.WriteLine("| {0,-15} | {1,-15} | {2,-15} | {3,15} | {4,15} | {5,15} | {6,15} | {7,15} | {8,-15} | {9,-15} | {10,20} |",
                strongest.Name, strongest.Race, strongest.CharacterClass, strongest.LifePoints, strongest.ManaPoints,
                strongest.DamagePoints, strongest.DefencePoints, strongest.Strength, strongest.Agility, strongest.Intelligence,
                strongest.SuperPower);   
        }
        /// <summary>
        /// Prints heroes who has more life points than defence points
        /// </summary>
        /// <param name="fileName">current file name</param>
        /// <param name="heroes">heroes</param>
        public static void PrintHeroesCSV(string fileName, List<Heroe> heroes)
        {
            string[] lines = new string[heroes.Count];

            for (int i = 0; i < heroes.Count; i++)
            {
                Heroe temp = heroes[i];
                lines[i] = String.Format(" {0} ; {1} ; {2} ; {3} ; {4} ; {5} ; {6} ; {7} ; {8} ; {9} ; {10}",
                    temp.Name, temp.Race, temp.CharacterClass, temp.LifePoints, temp.ManaPoints, temp.DamagePoints,
                    temp.DefencePoints, temp.Strength, temp.Agility, temp.Intelligence, temp.SuperPower);
            }
            File.WriteAllLines(fileName, lines);

        }

    }
}
