using System;
using System.Security;

public class Battle
{
    string filename = "characters.txt";
    public Battle() {}
    Item item = new Item();
    public void BattleLoop(Classtype player01, Classtype player02)
    {
        int initialDefensePlayer01 = player01.GetDefense();
        int initialDefensePlayer02 = player02.GetDefense();
        int initialAttackPlayer01 = player01.GetAttack();
        int initialAttackPlayer02 = player02.GetAttack();

        if (player02.GetType() == typeof(Swordsman) || player02.GetType() == typeof(Wizard) || player02.GetType() == typeof(Archer))
        {
            while (player01.GetAlive() == true && player02.GetAlive() == true)
            {
                DoTurn(player01, player02);
            }
            if (player01.GetAlive() == true)
            {
                player01.ResetStats(player01, initialAttackPlayer01, initialDefensePlayer01);
                player02.ResetStats(player02, initialAttackPlayer02, initialDefensePlayer02);
                player01.SetHealth(player01.GetTotalHealth());
                player02.SetHealth(player02.GetTotalHealth());
                RewardExp(player01, player02);
            }
            else if (player02.GetAlive() == true)
            {
                player01.ResetStats(player01, initialAttackPlayer01, initialDefensePlayer01);
                player02.ResetStats(player02, initialAttackPlayer02, initialDefensePlayer02);
                player01.SetHealth(player01.GetTotalHealth());
                player02.SetHealth(player02.GetTotalHealth());
                RewardExp(player02, player01);
            }
            OverwriteSave(player01);
            player01.SetAlive(true);
            OverwriteSave(player02);
            player02.SetAlive(true);
        }
        else if (player02.GetType() == typeof(CPU))
        {
            while (player01.GetAlive() == true && player02.GetAlive() == true)
            {
                DoCPUTurn(player01, player02);
            }
            if (player01.GetAlive() == true)
            {
                player01.ResetStats(player01, initialAttackPlayer01, initialDefensePlayer01);
                player01.SetHealth(player01.GetTotalHealth());
                RewardExp(player01, player02);
            }
            else if (player02.GetAlive() == true)
            {
                Console.WriteLine("Battle lost.");
            }
            OverwriteSave(player01);
            player01.SetAlive(true);
        }
    }
    public void DoTurn(Classtype player01, Classtype player02)
    {
        // player 1's turn
        Console.Clear();
        Console.WriteLine($"{player01.GetName()}(Level {player01.GetLevel()}) - {player01.GetHealth()}/{player01.GetTotalHealth()} HP");
        Console.WriteLine($"{player02.GetName()}(Level {player02.GetLevel()}) - {player02.GetHealth()}/{player02.GetTotalHealth()} HP");
        Console.WriteLine();
        Console.WriteLine($"It is {player01.GetName()}'s turn: ");
        if (player01.GetType() == typeof(Swordsman))
        {
            Console.WriteLine("  1. Use Simple Attack");
            Console.WriteLine("  2. Use Special Attack");
            Console.WriteLine("  3. Use Item");
            Console.WriteLine("  4. Defend");
        }
        else if (player01.GetType() == typeof(Archer))
        {
            Console.WriteLine("  1. Use Simple Attack");
            Console.WriteLine("  2. Use Special Attack");
            Console.WriteLine("  3. Use Item");
            Console.WriteLine("  4. Charge");
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
            int damageDealt = player01.UseAttack(player01, player02);
            if (damageDealt > 0)
            {
                player02.SetHealth(player02.GetHealth() - damageDealt);
            }
            else
            {
                player02.SetHealth(player02.GetHealth() - 1);
                damageDealt = 1;
            }
            Console.WriteLine($"{player01.GetName()} used a Simple Attack and did {damageDealt} damage. ");
            Console.Write("Press enter to continue. ");
            Console.ReadLine();
        }
        else if (action01 == "2")
        {
            int damageDealt = player01.UseSpecialAttack(player01, player02);
                if (damageDealt == 0)
                {
                    Console.WriteLine("Attack Missed! Press enter to continue ");
                    Console.ReadLine();
                }
                else 
                {
                if (damageDealt > 0)
                {
                    player02.SetHealth(player02.GetHealth() - damageDealt);
                }
                else
                {
                    player02.SetHealth(player02.GetHealth() - 1);
                    damageDealt = 1;
                }
                    Console.WriteLine($"{player01.GetName()} used a Special Attack and did {damageDealt} damage. ");
                    Console.Write("Press enter to continue. ");
                    Console.ReadLine();
                }
        }
        else if (action01 == "3")
        {
            item.UseItem(player01);
        }
        else if (action01 == "4" && player01.GetType() == typeof(Swordsman))
        {
            player01.Defend(player01);
            Console.WriteLine($"{player01.GetName()}'s defense increased by 3. ");
            Console.Write("Press enter to continue. ");
            Console.ReadLine();
        }
        else if (action01 == "4" && player01.GetType() == typeof(Archer))
        {
            player01.Charge(player01);
            Console.WriteLine($"{player01.GetName()}'s attack increased by 4. ");
            Console.Write("Press enter to continue. ");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Invalid action. Your attack missed.");
            Console.Write("Press enter to continue. ");
            Console.ReadLine();
        }
        // player 2's turn
        if (player02.GetAlive() == true)
        {
            Console.Clear();
            Console.WriteLine($"{player01.GetName()}(Level {player01.GetLevel()}) - {player01.GetHealth()}/{player01.GetTotalHealth()} HP");
            Console.WriteLine($"{player02.GetName()}(Level {player02.GetLevel()}) - {player02.GetHealth()}/{player02.GetTotalHealth()} HP");
            Console.WriteLine();
            Console.WriteLine($"It is {player02.GetName()}'s turn: ");
            if (player02.GetType() == typeof(Swordsman))
        {
            Console.WriteLine("  1. Use Simple Attack");
            Console.WriteLine("  2. Use Special Attack");
            Console.WriteLine("  3. Use Item");
            Console.WriteLine("  4. Defend");
        }
        else if (player02.GetType() == typeof(Archer))
        {
            Console.WriteLine("  1. Use Simple Attack");
            Console.WriteLine("  2. Use Special Attack");
            Console.WriteLine("  3. Use Item");
            Console.WriteLine("  4. Charge");
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
            int damageDealt = player02.UseAttack(player02, player01);
            if (damageDealt > 0)
            {
                player01.SetHealth(player01.GetHealth() - damageDealt);
            }
            else
            {
                player01.SetHealth(player01.GetHealth() - 1);
                damageDealt = 1;
            }
            Console.WriteLine($"{player02.GetName()} used a Simple Attack and did {damageDealt} damage. ");
            Console.Write("Press enter to continue. ");
            Console.ReadLine();
        }
        else if (action02 == "2")
        {
            int damageDealt = player02.UseSpecialAttack(player02, player01);
                if (damageDealt == 0)
                {
                    Console.WriteLine("Attack Missed! Press enter to continue ");
                    Console.Write("Press enter to continue. ");
                    Console.ReadLine();
                }
                else 
                {
                if (damageDealt > 0)
                {
                    player01.SetHealth(player01.GetHealth() - damageDealt);
                }
                else
                {
                    player01.SetHealth(player01.GetHealth() - 1);
                    damageDealt = 1;
                }
                    Console.WriteLine($"{player02.GetName()} used a Special Attack and did {damageDealt} damage. ");
                    Console.Write("Press enter to continue. ");
                    Console.ReadLine();
                }
        }
        else if (action02 == "3")
        {
            item.UseItem(player02);
        }
        else if (action02 == "4" && player02.GetType() == typeof(Swordsman))
        {
            player02.Defend(player02);
            Console.WriteLine($"{player02.GetName()}'s defense increased by 3. ");
            Console.Write("Press enter to continue. ");
            Console.ReadLine();
        }
        else if (action02 == "4" && player02.GetType() == typeof(Archer))
        {
            player02.Charge(player02);
            Console.WriteLine($"{player02.GetName()}'s attack increased by 4. ");
            Console.Write("Press enter to continue. ");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Invalid action. Your attack missed.");
            Console.Write("Press enter to continue. ");
            Console.ReadLine();
        }
        Console.Clear();
        }
        else
        {
            Console.Clear();
            Console.WriteLine($"{player02.GetName()} has fainted");
            Console.WriteLine();
        }
    }
    public void DoCPUTurn(Classtype player01, Classtype cpu)
    {
        Console.Clear();
        Console.WriteLine($"{player01.GetName()}(Level {player01.GetLevel()}) - {player01.GetHealth()}/{player01.GetTotalHealth()} HP");
        Console.WriteLine($"{cpu.GetName()}(Level {cpu.GetLevel()}) - {cpu.GetHealth()}/{cpu.GetTotalHealth()} HP");
        Console.WriteLine();
        Console.WriteLine($"It is {player01.GetName()}'s turn: ");
        if (player01.GetType() == typeof(Swordsman))
        {
            Console.WriteLine("  1. Use Simple Attack");
            Console.WriteLine("  2. Use Special Attack");
            Console.WriteLine("  3. Use Item");
            Console.WriteLine("  4. Defend");
        }
        else if (player01.GetType() == typeof(Archer))
        {
            Console.WriteLine("  1. Use Simple Attack");
            Console.WriteLine("  2. Use Special Attack");
            Console.WriteLine("  3. Use Item");
            Console.WriteLine("  4. Charge");
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
            int damageDealt = player01.UseAttack(player01, cpu);
            if (damageDealt > 0)
            {
                cpu.SetHealth(cpu.GetHealth() - damageDealt);
            }
            else
            {
                cpu.SetHealth(cpu.GetHealth() - 1);
                damageDealt = 1;
            }
            Console.WriteLine($"{player01.GetName()} used a Simple Attack and did {damageDealt} damage. ");
            Console.Write("Press enter to continue. ");
            Console.ReadLine();
        }
        else if (action01 == "2")
        {
            int damageDealt = player01.UseSpecialAttack(player01, cpu);
                if (damageDealt == 0)
                {
                    Console.WriteLine("Attack Missed! Press enter to continue ");
                    Console.ReadLine();
                }
                else 
                {
                if (damageDealt > 0)
                {
                    cpu.SetHealth(cpu.GetHealth() - damageDealt);
                }
                else
                {
                    cpu.SetHealth(cpu.GetHealth() - 1);
                    damageDealt = 1;
                }
                    Console.WriteLine($"{player01.GetName()} used a Simple Attack and did {damageDealt} damage. ");
                    Console.Write("Press enter to continue. ");
                    Console.ReadLine();
                }
        }
        else if (action01 == "3")
        {
            item.UseItem(player01);
        }
        else if (action01 == "4" && player01.GetType() == typeof(Swordsman))
        {
            player01.Defend(player01);
            Console.WriteLine($"{player01.GetName()}'s defense increased by 3. ");
            Console.Write("Press enter to continue. ");
            Console.ReadLine();
        }
        else if (action01 == "4" && player01.GetType() == typeof(Archer))
        {
            player01.Charge(player01);
            Console.WriteLine($"{player01.GetName()}'s attack increased by 4. ");
            Console.Write("Press enter to continue. ");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Invalid action. Your attack missed. Press enter to continue. ");
            Console.ReadLine();
        }
        // cpu's turn
        if (cpu.GetAlive() == true)
        {
            Console.Clear();
            Console.WriteLine($"{player01.GetName()}(Level {player01.GetLevel()}) - {player01.GetHealth()}/{player01.GetTotalHealth()} HP");
            Console.WriteLine($"{cpu.GetName()}(Level {cpu.GetLevel()}) - {cpu.GetHealth()}/{cpu.GetTotalHealth()} HP");
            Console.WriteLine();
            Console.WriteLine($"It is {cpu.GetName()}'s turn: ");
            Console.WriteLine();
            cpu.SelectAction(cpu, player01);
            Console.WriteLine("Press enter to continue. ");
            Console.ReadLine();
        }
        else
        {
            Console.Clear();
            Console.WriteLine($"{player01.GetName()}(Level {player01.GetLevel()}) - {player01.GetHealth()}/{player01.GetTotalHealth()} HP");
            Console.WriteLine($"{cpu.GetName()}(Level {cpu.GetLevel()}) - {cpu.GetHealth()}/{cpu.GetTotalHealth()} HP");
            Console.WriteLine();
            Console.WriteLine($"{cpu.GetName()} has fainted");
            Console.WriteLine();
        }
    }
    public void RewardExp(Classtype winner, Classtype loser)
    {
        if (loser.GetType() == typeof(Swordsman) || loser.GetType() == typeof(Wizard) || loser.GetType() == typeof(Archer))
        {
            int totalExp = loser.GetLevel() * 25 / winner.GetLevel();
            winner.SetExp(winner, totalExp + winner.GetExp());
        }
        else if (loser.GetType() == typeof(CPU))
        {
            int totalExp = loser.GetExp() / winner.GetLevel();
            winner.SetExp(winner, totalExp + winner.GetExp());
        }
    }
    public void OverwriteSave(Classtype character)
    {
        List<string> lines = new List<string>(File.ReadAllLines(filename));

        for (int i = 0; i < lines.Count; i++)
        {
            string[] parts = lines[i].Split(",");
            if (parts[1] == character.GetName())
            {
                if (character.GetType() == typeof(Swordsman))
                {
                    lines[i] = $"Swordsman,{character.GetName()},{character.GetTotalHealth()},{character.GetTotalHealth()},{character.GetAttack()},{character.GetDefense()},true,{character.GetLevel()},{character.GetExp()}";
                }
                else if (character.GetType() == typeof(Wizard))
                {
                    lines[i] = $"Wizard,{character.GetName()},{character.GetTotalHealth()},{character.GetTotalHealth()},{character.GetAttack()},{character.GetDefense()},true,{character.GetLevel()},{character.GetExp()},{character.GetLives()}";
                }
                else if (character.GetType() == typeof(Archer))
                {
                    lines[i] = $"Archer,{character.GetName()},{character.GetTotalHealth()},{character.GetTotalHealth()},{character.GetAttack()},{character.GetDefense()},true,{character.GetLevel()},{character.GetExp()}";
                }
                break;
            }
        }
        File.WriteAllLines(filename, lines);
    }
}