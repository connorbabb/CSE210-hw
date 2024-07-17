using System;

public class CPU : Classtype
{
    public CPU(string name, int health, int totalHealth, int attack, int defense, bool alive, int level, int exp) : base(name, health, totalHealth, attack, defense, alive, level, exp) {}
    public override void SelectAction(Classtype cpu, Classtype defender)
    {
        Random random = new Random();
        int action = random.Next(4);
        if (action == 0 || action == 1)
        {
            defender.SetHealth(defender.GetHealth() - 20);
            Console.WriteLine($"{cpu.GetName()} used a Simple Attack and did 20 damage. ");
        }
        else if (action == 2)
        {
            defender.SetHealth(defender.GetHealth() - 30);
            Console.WriteLine($"{cpu.GetName()} used a Special Attack and did 30 damage. ");
        }
        else if (action == 3)
        {
            Console.WriteLine("CPU attack missed! ");
            Console.WriteLine();
        }
    }
}