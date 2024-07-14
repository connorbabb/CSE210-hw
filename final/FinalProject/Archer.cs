using System;

public class Archer : Classtype
{
    private int _dodge;
    public Archer(string name, int health, int attack, int defense, bool alive, int level, int exp, int dodge) : base(name, health, attack, defense, alive, level, exp)
    {
        _dodge = dodge;
    }
    public void ChargeBow()
    {

    }
    public override int GetDodge()
    {
        return _dodge;
    }
    public void SetDodge(int dodge)
    {
        _dodge = dodge;
    }
}