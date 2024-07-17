using System;
using System.IO;
using System.IO.Enumeration;

public class UI
{
    string filename = "characters.txt";
    private Battle battle = new Battle();
    private List<Classtype> characters = new List<Classtype>();
    public UI() 
    {
        LoadCharacters();
    }
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
            CPU player02 = new CPU("Guard", 50, 50, 15, 15, true, 1, 20);
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
            Console.WriteLine($"     Health: {character.GetTotalHealth()}, Attack: {character.GetAttack()}, Defense: {character.GetDefense()}, Exp: {character.GetExp()}/100");
            i++;
        }
        Console.Write("Press enter when done. ");
        Console.ReadLine();
    }
    public void LoadCharacters()
    {
        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(",");

                string characterType = parts[0];
                string characterName = parts[1];
                int health = int.Parse(parts[2]);
                int totalHealth = int.Parse(parts[3]);
                int attack = int.Parse(parts[4]);
                int defense = int.Parse(parts[5]);
                bool alive = bool.Parse(parts[6]);
                int level = int.Parse(parts[7]);
                int exp = int.Parse(parts[8]);

                if (characterType == "Swordsman")
                {
                    Swordsman swordsman = new Swordsman(characterName, health, totalHealth, attack, defense, alive, level, exp);
                    characters.Add(swordsman);
                }
                else if (characterType == "Wizard")
                {
                    int lives = int.Parse(parts[9]);
                    Wizard wizard = new Wizard(characterName, health, totalHealth, attack, defense, alive, level, exp, lives);
                    characters.Add(wizard);
                }
                else if (characterType == "Archer")
                {
                    Archer archer = new Archer(characterName, health, totalHealth, attack, defense, alive, level, exp);
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
            Swordsman swordsman = new Swordsman(characterName, 100, 100, 30, 10, true, 1, 0);
            SaveCharacter(swordsman);
            characters.Add(swordsman);
        }
        else if (characterType == "2")
        {
            Wizard wizard = new Wizard(characterName, 80, 80, 25, 15, true, 1, 0, 2);
            SaveCharacter(wizard);
            characters.Add(wizard);
        }
        else if (characterType == "3")
        {
            Archer archer = new Archer(characterName, 80, 80, 25, 15, true, 1, 0);
            SaveCharacter(archer);
            characters.Add(archer);
        }
    }
    public void SaveCharacter(Classtype character)
    {
        using (StreamWriter outputFile = new StreamWriter(filename, true))
        {
            if (character.GetType() == typeof(Swordsman))
            {
                outputFile.WriteLine($"Swordsman,{character.GetName()},{character.GetHealth()},{character.GetTotalHealth()},{character.GetAttack()},{character.GetDefense()},{character.GetAlive()},{character.GetLevel()},{character.GetExp()}");
            }
            else if (character.GetType() == typeof(Wizard))
            {
                outputFile.WriteLine($"Wizard,{character.GetName()},{character.GetHealth()},{character.GetTotalHealth()},{character.GetAttack()},{character.GetDefense()},{character.GetAlive()},{character.GetLevel()},{character.GetExp()},{character.GetLives()}");
            }
            else if (character.GetType() == typeof(Archer))
            {
                outputFile.WriteLine($"Archer,{character.GetName()},{character.GetHealth()},{character.GetTotalHealth()},{character.GetAttack()},{character.GetDefense()},{character.GetAlive()},{character.GetLevel()},{character.GetExp()},{character.GetDodge()}");
            }
        }
    }
}