using System;
using System.ComponentModel;

public abstract class Classtype
{
    private string _name;
    private int _health;
    private int _attack;
    private int _defense;
    private bool _alive;
    private int _level;
    private int _exp;
    public Classtype(string name, int health, int attack, int defense, bool alive, int level, int exp)
    {
        _name = name;
        _health = health;
        _attack = attack;
        _defense = defense;
        _alive = alive;
        _level = level;
        _exp = exp;
    }
    public void UseAttack()
    {

    }
    public void UseSpecialAttack()
    {

    }
    public void IsAwake()
    {

    }
    public string GetName()
    {
        return _name;
    }
    public int GetHealth()
    {
        return _health;
    }
    public void SetHealth(int health)
    {
        _health = health;
        if (_health <= 0)
        {
            this.SetAlive(false);
            _health = 0;
        }
    }
    public int GetAttack()
    {
        return _attack;
    }
    public void SetAttack(int attack)
    {
        _attack = attack;
    }
    public int GetDefense()
    {
        return _defense;
    }
    public void SetDefense(int defense)
    {
        _defense = defense;
    }
    public bool GetAlive()
    {
        return _alive;
    }
    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
    public int GetLevel()
    {
        return _level;
    }
    public void SetLevel()
    {
        _level++;
        int leftoverExp = GetExp() - 100;
        SetExp(leftoverExp);
        // overwrite attributes at level up
    }
    public int GetExp()
    {
        return _exp;
    }
    public void SetExp(int exp)
    {
        _exp = exp;
        if (_exp > 99)
        {
            SetLevel();
        }
    }
    public virtual int GetLives()
    {
        return 0;
    }
    public virtual int GetDodge()
    {
        return 0;
    }
}