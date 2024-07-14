using System;
using System.Security.Cryptography.X509Certificates;

public class Program
{
    public static string filename = "characters.txt";
    static void Main(string[] args)
    {
        Console.Clear();
        string user = "";
        UI ui = new UI();

        while (user != "5")
        {
            Console.Clear();
            Console.WriteLine("Menu Options: ");
            Console.WriteLine("  1. Start Battle");
            Console.WriteLine("  2. Display Loaded Characters");
            Console.WriteLine("  3. Load Character");
            Console.WriteLine("  4. Create Character");
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");
            user = Console.ReadLine();
            Console.WriteLine();

            if (user == "1")
            {
                ui.BattleSetUp();
                Console.Write("Would you like to battle again?(yes/no) ");
                string playAgain = Console.ReadLine();
                if (playAgain == "yes")
                {
                    ui.BattleSetUp();
                }
                else
                {
                    break;
                    // ui.OverwriteSave();
                }
            }
            else if (user == "2")
            {
                ui.DisplayCharacters();
            }
            else if (user == "3")
            {
                ui.LoadCharacter();
            }
            else if (user == "4")
            {
                ui.CreateCharacter();
            }
            else if (user == "5")
            {
                Console.WriteLine("Exiting program.");
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        }
    }
}