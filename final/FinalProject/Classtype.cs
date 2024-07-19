using System;
using System.ComponentModel;
using System.Reflection.PortableExecutable;

public abstract class Classtype
{
    private string _name;
    private int _health;
    private int _totalHealth;
    private int _attack;
    private int _defense;
    private bool _alive;
    private int _level;
    private int _exp;
    private List<Item> items = new List<Item>();
    public Classtype(string name, int health, int totalHealth, int attack, int defense, bool alive, int level, int exp)
    {
        _name = name;
        _health = health;
        _totalHealth = totalHealth;
        _attack = attack;
        _defense = defense;
        _alive = alive;
        _level = level;
        _exp = exp;
        // items = new List<Item>();
        // Item item = new Item();
    }
    public int UseAttack(Classtype attacker, Classtype defender)
    {
        int damageDealt = attacker.GetAttack() - defender.GetDefense();
        return damageDealt;
    }
    public int UseSpecialAttack(Classtype attacker, Classtype defender)
    {
        Random random = new Random();
        int chance = random.Next(3);
        if (chance == 0 || chance == 1)
        {
            int damageDealt = attacker.GetAttack() * 2 - (defender.GetDefense() * 2 + defender.GetDefense()/5);
            return damageDealt;
        }
        else
        {
            int damageDealt = 0;
            return damageDealt;
        }
    }
    public void IsAwake()
    {

    }
    public string GetName() {return _name;}
    public int GetHealth() {return _health;}
    public int GetTotalHealth() {return _totalHealth;}
    public void SetHealth(int health)
    {
        _health = health;
        if (_health <= 0)
        {
            if (this.GetType() == typeof(Wizard) && this.GetLives() == 2)
            {
                this.SetLives(1);
                _health = 1;
                Console.WriteLine($"{this.GetName()} has fainted. ");
                Console.Write($"However, {this.GetName()} has been revived with magic! ");
                Console.WriteLine();
            }
            else
            {
                this.SetAlive(false);
                _health = 0;
            }
        }
    }
    public int GetAttack() {return _attack;}
    public void SetAttack(int attack) {_attack = attack;}
    public int GetDefense() {return _defense;}
    public void SetDefense(int defense) {_defense = defense;}
    public bool GetAlive() {return _alive;}
    public void SetAlive(bool alive) 
    {
        _alive = alive;
        if (this.GetType() == typeof(Wizard))
        {
            this.SetLives(2);
        }
    }
    public virtual void SetLives(int lives) {}
    public int GetLevel() {return _level;}
    public void SetTotalHealth(int health) {_totalHealth = health;}
    public void SetLevel(Classtype player)
    {
        _level++;
        int leftoverExp = GetExp() - 100;
        SetExp(player, leftoverExp);

        Random random = new Random();
        int newTotalHealth = player.GetTotalHealth() + random.Next(4, 6);
        player.SetTotalHealth(newTotalHealth);
        player.SetHealth(newTotalHealth);
        player.SetAttack(player.GetAttack() + random.Next(3, 5));
        player.SetDefense(player.GetDefense() + random.Next(2, 4));
    }

    public int GetExp() {return _exp;}
    public void SetExp(Classtype player, int exp)
    {
        _exp = exp;
        if (_exp > 99)
        {
            SetLevel(player);
        }
    }
    public virtual int GetLives() {return 0;}
    public virtual int GetDodge() {return 0;}
    public virtual void SelectAction(Classtype cpu, Classtype defender) {}
    public virtual void Defend(Classtype player) {}
    public virtual void ResetDefense(Classtype player, int initialDefense) {}
    public virtual void Charge(Classtype player) {}
    public void ResetStats(Classtype player, int initialAttack, int initialDefense)
    {
        player.SetAttack(initialAttack);
        player.SetDefense(initialDefense);
        if (player.GetType() == typeof(Wizard))
        {
            player.SetLives(2);
        }
    }
}