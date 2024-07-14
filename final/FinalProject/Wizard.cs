using System;

public class Wizard : Classtype
{
    private int _lives;
    public Wizard(string name, int health, int attack, int defense, bool alive, int level, int exp, int lives) : base(name, health, attack, defense, alive, level, exp)
    {
        _lives = lives;
    }
    public void UseSpell()
    {

    }
    public override int GetLives()
    {
        return _lives;
    }
    public void SetLives(int lives)
    {
        _lives--;
    }
}