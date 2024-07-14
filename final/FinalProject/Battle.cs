using System;

public class Battle
{
    string filename = "characters.txt";
    public Battle() {}
    public void BattleLoop(Classtype player01, Classtype player02)
    {
        if (player02.GetType() == typeof(Swordsman) || player02.GetType() == typeof(Wizard) || player02.GetType() == typeof(Archer))
        {
            // while (player01.GetAlive() == true && player02.GetAlive() == true)
            for (int i = 0; i < 5; i++)
            {
                DoTurn(player01, player02);
            }
            if (player01.GetAlive() == true)
            {
                RewardExp(player01, player02);
            }
            else if (player02.GetAlive() == true)
            {
                RewardExp(player02, player01);
            }
            OverwriteSave(player01);
            OverwriteSave(player02);
        }
        else if (player02.GetType() == typeof(CPU))
        {
            while (player01.GetAlive() == true && player02.GetAlive() == true)
            {
                DoCPUTurn();
            }
            if (player01.GetAlive() == true)
            {
                RewardExp(player01, player02);
            }
            else if (player02.GetAlive() == true)
            {
                Console.WriteLine("Battle lost.");
            }
            OverwriteSave(player01);
        }
    }
    public void DoTurn(Classtype player01, Classtype player02)
    {
        // player 1's turn
        Console.Clear();
        Console.WriteLine($"{player01.GetName()}({player01.GetLevel()}) - {player01.GetHealth()} HP");
        Console.WriteLine($"{player02.GetName()}({player02.GetLevel()}) - {player02.GetHealth()} HP");
        Console.WriteLine();
        Console.WriteLine($"It is {player01.GetName()}'s turn: ");
        if (player01.GetType() == typeof(Wizard))
        {
            Console.WriteLine("  1. Use Simple Attack");
            Console.WriteLine("  2. Use Special Attack");
            Console.WriteLine("  3. Use Item");
            Console.WriteLine("  4. Use Spell");
        }
        else 
        {
            Console.WriteLine("  1. Use Simple Attack");
            Console.WriteLine("  2. Use Special Attack");
            Console.WriteLine("  3. Use Item");
        }
        Console.Write("What action would you like to do? ");
        string action01 = Console.ReadLine();
        if (action01 == "1")
        {

        }
        else if (action01 == "2")
        {

        }
        else if (action01 == "3")
        {

        }
        else if (action01 == "4" && player01.GetType() == typeof(Wizard))
        {

        }
        else
        {
            Console.WriteLine("Invalid action. Your attack missed.");
        }

        Console.Clear();
        // player 2's turn
        Console.WriteLine($"{player01.GetName()}({player01.GetLevel()}) - {player01.GetHealth()} HP");
        Console.WriteLine($"{player02.GetName()}({player02.GetLevel()}) - {player02.GetHealth()} HP");
        Console.WriteLine();
        Console.WriteLine($"It is {player02.GetName()}'s turn: ");
        if (player02.GetType() == typeof(Wizard))
        {
            Console.WriteLine("  1. Use Simple Attack");
            Console.WriteLine("  2. Use Special Attack");
            Console.WriteLine("  3. Use Item");
            Console.WriteLine("  4. Use Spell");
        }
        else 
        {
            Console.WriteLine("  1. Use Simple Attack");
            Console.WriteLine("  2. Use Special Attack");
            Console.WriteLine("  3. Use Item");
        }
        Console.Write("What action would you like to do? ");
        string action02 = Console.ReadLine();
        if (action02 == "1")
        {

        }
        else if (action02 == "2")
        {

        }
        else if (action02 == "3")
        {

        }
        else if (action02 == "4" && player02.GetType() == typeof(Wizard))
        {

        }
        else
        {
            Console.WriteLine("Invalid action. Your attack missed.");
        }
        Console.Clear();
        Console.WriteLine($"{player01.GetName()}({player01.GetLevel()}) - {player01.GetHealth()} HP");
        Console.WriteLine($"{player02.GetName()}({player02.GetLevel()}) - {player02.GetHealth()} HP");
        Console.Write("Press enter to continue ");
        Console.ReadLine();
        // player01.UseAttack();

        // player01.SetHealth(player01.GetHealth() - 25);
    }
    public void DoCPUTurn()
    {

    }
    public void CalculateDamage()
    {

    }
    public void RewardExp(Classtype winner, Classtype loser)
    {
        if (loser.GetType() == typeof(Swordsman) || loser.GetType() == typeof(Wizard) || loser.GetType() == typeof(Archer))
        {
            int totalExp = loser.GetLevel() * 25 / winner.GetLevel();
            winner.SetExp(totalExp);
        }
        else if (loser.GetType() == typeof(CPU))
        {
            int totalExp = loser.GetExp() / winner.GetLevel();
            winner.SetExp(totalExp);
        }
    }
    public void OverwriteSave(Classtype character)
    {
        // Read all lines from the file into a list
        List<string> lines = new List<string>(File.ReadAllLines(filename));

        // Find the line to replace
        for (int i = 0; i < lines.Count; i++)
        {
            string[] parts = lines[i].Split(",");
            if (parts[2] == character.GetName())
            {
                // Replace the line with the new character data
                if (character.GetType() == typeof(Swordsman))
                {
                    lines[i] = $"{parts[0]},Swordsman,{character.GetName()},{character.GetHealth()},{character.GetAttack()},{character.GetDefense()},{character.GetAlive()},{character.GetLevel()},{character.GetExp()}";
                }
                else if (character.GetType() == typeof(Wizard))
                {
                    lines[i] = $"{parts[0]},Wizard,{character.GetName()},{character.GetHealth()},{character.GetAttack()},{character.GetDefense()},{character.GetAlive()},{character.GetLevel()},{character.GetExp()},{character.GetLives()}";
                }
                else if (character.GetType() == typeof(Archer))
                {
                    lines[i] = $"{parts[0]},Archer,{character.GetName()},{character.GetHealth()},{character.GetAttack()},{character.GetDefense()},{character.GetAlive()},{character.GetLevel()},{character.GetExp()},{character.GetDodge()}";
                }
                break; // Exit the loop after finding the first match
            }
        }

        // Write all lines back to the file
        File.WriteAllLines(filename, lines);
    }
}