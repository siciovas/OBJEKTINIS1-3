using System;
using System.Collections.Generic;
using System.IO;

namespace VideoGame._1
{
    class Program
    {
        static void Main(string[] args)
        {
            File.Delete(@"Trūkstami.csv");

            CharacterContainer allCharacters = InOut.ReadCharacters(@"Troll.csv");
            InOut.ReadCharacters(@"Human.csv", allCharacters);

            CharacterRegister register = new CharacterRegister(allCharacters);

            //List<Character> allCharacters = InOutUtils.ReadCharacters(@"Troll.csv");
            //InOutUtils.ReadCharacters(@"Human.csv", allCharacters);

            Console.WriteLine("Veikėjų informacija: ");
            InOut.PrintCharacters(allCharacters);

            Character mostLifePoints = register.FindCharacterWithMostLifePoints(allCharacters);
            Console.WriteLine("Veikėjas su daugiausia gyvybės taškų: ");
            Console.WriteLine("Vardas: {0}, Rasė: {1}, Klasė: {2}, Gyvybės taškai: {3}", mostLifePoints.Name, mostLifePoints.Race, mostLifePoints.CharacterClass, mostLifePoints.LifePoints);
            Console.WriteLine();

            Character smallestPointDiffernce = register.CharacterWithSmallestPointDifference(allCharacters);
            Console.WriteLine("Veikėjas su mažiausiu taškų skirtumu tarp gynybos ir žalos taškų: ");
            Console.WriteLine("Vardas: {0}, Rasė: {1}, Klasė: {2}, Gyvybės taškai: {3}, Mana: {4}, Žalos taškai: {5}, Gynybos taškai: {6}, Jėga: {7}, Vikrumas: {8}, Intelektas: {9}, Ypatinga galia: {10}",
                smallestPointDiffernce.Name, smallestPointDiffernce.Race, smallestPointDiffernce.CharacterClass, smallestPointDiffernce.LifePoints, smallestPointDiffernce.ManaPoints, smallestPointDiffernce.DamagePoints,
                smallestPointDiffernce.DefencePoints, smallestPointDiffernce.Strength, smallestPointDiffernce.Agility, smallestPointDiffernce.Intelligence, smallestPointDiffernce.SuperPower);
            Console.WriteLine();

            string fileName = "Klasės.csv";
            InOut.PrintCharacterClassesToCSV(fileName, register.FindCharacterClasses());
            InOut.PrintCharacteresToTxtFile("StartingData.txt", allCharacters);

            List<string> race = register.Race();
            register.ClassesInRace(race[0]);
            register.ClassesInRace(race[1]);
            Character strongest = register.StrongestCharacter(allCharacters);
            InOut.PrintStrongest(strongest);

            allCharacters.Sort();
            List<Heroe> heroes = register.FindHeroes();
            InOut.PrintHeroesCSV(@"Herojai.csv", heroes);
            

            Console.ReadKey();
        }
    }
}
