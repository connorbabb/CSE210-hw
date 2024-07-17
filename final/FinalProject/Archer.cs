using System;

public class Archer : Classtype
{
    public Archer(string name, int health, int totalHealth, int attack, int defense, bool alive, int level, int exp) : base(name, health, totalHealth, attack, defense, alive, level, exp) {}
    public override void Charge(Classtype player)
    {
        player.SetAttack(player.GetAttack() + 4);
    }
}