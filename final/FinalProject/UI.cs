using System;
using System.IO;
using System.IO.Enumeration;

public class UI
{
    private int characterAmount = 1;
    string filename = "characters.txt";
    Battle battle = new Battle();
    public UI() {}
    private List<Classtype> characters = new List<Classtype>();
    public void BattleSetUp()
    {
        Console.Clear();
        Console.WriteLine("Battle Types: ");
        Console.WriteLine("  1. Character VS. Character");
        Console.WriteLine("  2. Character VS. CPU");
        Console.Write("What type of battle would you like to do? ");
        string battleChoice = Console.ReadLine();

        Console.Clear();
        int i = 1;
        Console.WriteLine("Loaded characters:");
        foreach (Classtype character in characters)
        {
            Console.WriteLine($"  {i}. {character.GetName()} - Level {character.GetLevel()}, {character.GetType()}");
            i++;
        }
        Console.Write("Which character would you like to load as player 1? ");
        string characterChoice01 = Console.ReadLine();
        Classtype player01 = characters[int.Parse(characterChoice01) - 1];

        if (battleChoice == "1")
        {
            Console.Clear();
            i = 1;
            Console.WriteLine($"Player 1: {player01.GetName()} - Level {player01.GetLevel()}, {player01.GetType()}");
            foreach (Classtype character in characters)
            {
                Console.WriteLine($"  {i}. {character.GetName()} - Level {character.GetLevel()}, {character.GetType()}");
                i++;
            }
            Console.Write("Which character would you like to load as player 2? ");
            string characterChoice02 = Console.ReadLine();
            Classtype player02 = characters[int.Parse(characterChoice02) - 1];
            battle.BattleLoop(player01, player02);
        }
        else if (battleChoice == "2")
        {
            CPU player02 = new CPU("Guard", 50, 15, 15, true, 1, 50);
            battle.BattleLoop(player01, player02);
        }
    }
    public void DisplayCharacters()
    {
        Console.Clear();
        int i = 1;
        Console.WriteLine("Loaded characters:");
        foreach (Classtype character in characters)
        {
            Console.WriteLine($"  {i}. {character.GetName()} - Level {character.GetLevel()}, {character.GetType()}");
            i++;
        }
        Console.Write("Press enter when done. ");
        Console.ReadLine();
    }
    public void LoadCharacter()
    {
        Console.Clear();
        Console.WriteLine("Character Selection: ");
        string[] lines = System.IO.File.ReadAllLines(filename);
        int i = 1;
        foreach (String line in lines)
        {
            string[] parts = line.Split(",");
            string characterName = parts[2];
            Console.WriteLine($"  {i}. {characterName} - Level {parts[7]}, {parts[1]}");
            i++;
        }
        Console.Write("Which character number would you like to load? ");
        string characterChoice = Console.ReadLine();
        
        foreach (String line in lines)
        {
            string[] parts = line.Split(",");
            if (characterChoice == parts[0])
            {
                if (parts[1] == "Swordsman")
                {
                    Swordsman swordsman = new Swordsman(parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), bool.Parse(parts[6]), int.Parse(parts[7]), int.Parse(parts[8]));
                    characters.Add(swordsman);
                }
                else if (parts[1] == "Wizard")
                {
                    Wizard wizard = new Wizard(parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), bool.Parse(parts[6]), int.Parse(parts[7]), int.Parse(parts[8]), int.Parse(parts[9]));
                    characters.Add(wizard);
                }
                if (parts[1] == "Archer")
                {
                    Archer archer = new Archer(parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), bool.Parse(parts[6]), int.Parse(parts[7]), int.Parse(parts[8]), int.Parse(parts[9]));
                    characters.Add(archer);
                }
            }
        }
    }
    public void CreateCharacter()
    {
        Console.Clear();
        Console.WriteLine("The types of Characters are:");
        Console.WriteLine("  1. Swordsman");
        Console.WriteLine("  2. Wizard");
        Console.WriteLine("  3. Archer");
        Console.Write("Which type of character would you like to create? ");
        string characterType = Console.ReadLine();
        Console.Write("What is the name of your character? ");
        string characterName = Console.ReadLine();

        if (characterType == "1")
        {
            Swordsman swordsman = new Swordsman(characterName, 100, 25, 50, true, 1, 0);
            SaveCharacter(swordsman);
            Console.Write($"Would you like to the load {swordsman.GetName()} into the game?(yes/no) ");
            string userLoadChoice = Console.ReadLine();
            if (userLoadChoice == "yes")
            {
                characters.Add(swordsman);
                Console.WriteLine("Character loaded.");
            }
            characterAmount++;
        }
        else if (characterType == "2")
        {
            Wizard wizard = new Wizard(characterName, 80, 15, 60, true, 1, 0, 2);
            SaveCharacter(wizard);
            Console.Write($"Would you like to the load {wizard.GetName()} into the game?(yes/no) ");
            string userLoadChoice = Console.ReadLine();
            if (userLoadChoice == "yes")
            {
                characters.Add(wizard);
                Console.WriteLine("Character loaded.");
            }
            characterAmount++;
        }
        else if (characterType == "3")
        {
            Archer archer = new Archer(characterName, 80, 20, 40, true, 1, 0, 25);
            SaveCharacter(archer);
            Console.Write($"Would you like to the load {archer.GetName()} into the game?(yes/no) ");
            string userLoadChoice = Console.ReadLine();
            if (userLoadChoice == "yes")
            {
                characters.Add(archer);
                Console.WriteLine("Character loaded.");
            }
            characterAmount++;
        }
    }
    public void SaveCharacter(Classtype character)
    {
        using (StreamWriter outputFile = new StreamWriter(filename, true))
        {
            if (character.GetType() == typeof(Swordsman))
            {
                outputFile.WriteLine($"{characterAmount},Swordsman,{character.GetName()},{character.GetHealth()},{character.GetAttack()},{character.GetDefense()},{character.GetAlive()},{character.GetLevel()},{character.GetExp()}");
            }
            else if (character.GetType() == typeof(Wizard))
            {
                outputFile.WriteLine($"{characterAmount},Wizard,{character.GetName()},{character.GetHealth()},{character.GetAttack()},{character.GetDefense()},{character.GetAlive()},{character.GetLevel()},{character.GetExp()},{character.GetLives()}");
            }
            else if (character.GetType() == typeof(Archer))
            {
                outputFile.WriteLine($"{characterAmount},Archer,{character.GetName()},{character.GetHealth()},{character.GetAttack()},{character.GetDefense()},{character.GetAlive()},{character.GetLevel()},{character.GetExp()},{character.GetDodge()}");
            }
        }
    }
}