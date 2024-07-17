using System;

public class Wizard : Classtype
{
    private int _lives;
    public Wizard(string name, int health, int totalHealth, int attack, int defense, bool alive, int level, int exp, int lives) : base(name, health, totalHealth, attack, defense, alive, level, exp)
    {
        _lives = lives;
    }
    public override int GetLives()
    {
        return _lives;
    }
    public override void SetLives(int lives)
    {
        _lives = lives;
        if (lives == 0)
        {
            this.SetAlive(false);
        }
    }
}