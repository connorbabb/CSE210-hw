using System;

public class Item
{
    public Item() {}
    public void UseItem(Classtype player)
    {
        int healthRecovered = player.GetHealth() + (player.GetTotalHealth() / 5);
        int actualHealthRecovered = healthRecovered - player.GetHealth();
        player.SetHealth(healthRecovered);
        Console.Write($"{player.GetName()} gained {actualHealthRecovered} HP. Press enter to continue. ");
        Console.ReadLine();
    }
}