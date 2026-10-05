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

    }

}
