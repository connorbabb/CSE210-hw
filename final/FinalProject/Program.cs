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

        while (user != "4")
        {
            Console.Clear();
            Console.WriteLine("Menu Options: ");
            Console.WriteLine("  1. Start Battle");
            Console.WriteLine("  2. Display Characters");
            Console.WriteLine("  3. Create Character");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");
            user = Console.ReadLine();
            Console.WriteLine();

            if (user == "1")
            {
                ui.BattleSetUp();
                Console.Write("Would you like to battle again?(yes/no) ");
                string playAgain = Console.ReadLine();
                while (playAgain == "yes")
                {
                    ui.BattleSetUp();
                    Console.Write("Would you like to battle again?(yes/no) ");
                    playAgain = Console.ReadLine();
                }
                user = "4";
            }
            else if (user == "2")
            {
                ui.DisplayCharacters();
            }
            else if (user == "3")
            {
                ui.CreateCharacter();
            }
            if (user == "4")
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