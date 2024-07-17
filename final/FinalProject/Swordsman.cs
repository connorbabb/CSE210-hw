using System;

public class Swordsman : Classtype
{
    public Swordsman(string name, int health, int totalHealth, int attack, int defense, bool alive, int level, int exp) : base(name, health, totalHealth, attack, defense, alive, level, exp) {}
    public override void Defend(Classtype player)
    {
        player.SetDefense(player.GetDefense() + 3);
    }
}