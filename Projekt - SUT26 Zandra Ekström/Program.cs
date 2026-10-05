using System.Net.NetworkInformation;

namespace Projekt___SUT26_Zandra_Ekström
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hej och välkommen till din bank!");

            string[] names = { "Zandra", "Charlie", "Kalle", "Allie", "Jinian" };
            int[] numbers = { 1837, 6774, 6538, 4328, 9274 };

                        
            string[,] accountNames =
            {

            {"Privatkonto", "Räkningskonto" , "" },
            {"Privatkonto", "Sparkonto", "Fond" },
            {"Kattmat", "", "" },
            {"Privatkonto", "Fotografering", "" },
            {"Privatkonto", "Resor", "" }, 

            };

            decimal[,] balances =
            {

            { 459.50m, 8910m, 0m },
            { 5.42m, 5933m, 45934m },
            { 583.25m, 0m, 0m },
            { 927.11m, 9183.98m, 0m },
            { 8272.29m, 19203m, 0m }

            };

            int userIndex = Login(names, numbers);

            Console.ReadKey();
        }

        static int Login(string[] users, int[] pins)
        {
            int attempts = 0;

            while (attempts < 3)
            {
                // Frågar efter användarnamn
                Console.Write("Ange användarnamn: ");
                string username = Console.ReadLine();

                // Kontrollerar att användarnamnet inte innehåller siffror
                bool usernameIsValid = true;

                foreach (char character in username)
                {
                    if (char.IsDigit(character))
                    {
                        usernameIsValid = false;
                    }
                }

                // Om användarnamnet innehåller siffror visas felmeddelande
                if (usernameIsValid == false)
                {
                    Console.WriteLine("Användarnamnet får inte innehålla siffror.");
                    continue;
                }


                // Frågar efter PIN-kod
                Console.Write("Ange PIN-kod: ");
                string pinInput = Console.ReadLine();

                // Kontrollerar att PIN-koden är ett heltal
                if (!int.TryParse(pinInput, out int pin))
                {
                    Console.WriteLine("PIN-koden måste innehålla siffror.");
                    continue;
                }


                // Går igenom användarna
                for (int i = 0; i < users.Length; i++)
                {
                    // Kontrollerar om både användarnamn och PIN stämmer
                    if (username == users[i] && pin == pins[i])
                    {
                        Console.WriteLine("Inloggningen lyckades!");
                        return i;
                    }
                }


                // Om användarnamn eller PIN inte stämmer
                attempts++;
                Console.WriteLine("Fel användarnamn eller PIN-kod.");
                Console.WriteLine($"Du har {3 - attempts} försök kvar.");
            }


            // Körs om användaren har misslyckats tre gånger
            Console.WriteLine("Du har angett fel uppgifter tre gånger.");
            return -1;
        }


        static void MainMenu(int userIndex)
        {
            static void MainMenu(int userIndex)
            {
                while (true)
                {
                    Console.WriteLine("\n--- HUVUDMENY ---");
                    Console.WriteLine("1. Visa konton och saldo");
                    Console.WriteLine("2. Överför pengar");
                    Console.WriteLine("3. Ta ut pengar");
                    Console.WriteLine("4. Logga ut");

                    Console.Write("Välj ett alternativ: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            // Visa konton
                            break;

                        case "2":
                            // Överför pengar
                            break;

                        case "3":
                            // Ta ut pengar
                            break;

                        case "4":
                            Console.WriteLine("Du loggas ut...");
                            return;
                            // Använder return istället för break för att avsluta metoden och gå tillbaka till inloggningsmenyn
                        
                       
                        default:
                            Console.WriteLine("Ogiltigt val, försök igen.");
                            break;
                            //Använder default för att hantera ogiltiga val och ge användaren möjlighet att försöka igen
                            
                    }
                }
            }
        }


    }

}
