namespace Projekt___SUT26_Zandra_Ekström
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hej och välkommen till din bank!");

            string[] names = { "Zandra", "Charlie", "Kalle", "Allie", "Jinian" };
            int[] numbers = { 1837, 6774, 6538, 4328, 9274 };


            //Two dimensional arrays to store account names and balances for each user.
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

            while (true)
            {
                int userIndex = Login(names, numbers);

                if (userIndex == -1)
                {
                    break;
                }

                MainMenu(userIndex, accountNames, balances, numbers);
            }

            Console.ReadKey();
        }

        static int Login(string[] users, int[] pins)
        {
            int attempts = 0;

            while (attempts < 3)
            {
                // ask for username.
                Console.Write("Ange användarnamn: ");
                string username = Console.ReadLine();

                // checks if the username contains any digits
                bool usernameIsValid = true;

                foreach (char character in username)
                {
                    if (char.IsDigit(character))
                    {
                        usernameIsValid = false;
                    }
                }

                // If username contains digits, print an error message and continue to the next iteration of the loop.
                if (usernameIsValid == false)
                {
                    Console.WriteLine("Användarnamnet får inte innehålla siffror.");
                    continue;
                }


                
                Console.Write("Ange PIN-kod: ");
                string pinInput = Console.ReadLine();

                // Makes sure that the PIN code is a number and not a string.
                // If it is a string, it will print an error message and continue to the next iteration of the loop.
                if (!int.TryParse(pinInput, out int pin))
                {
                    Console.WriteLine("PIN-koden måste innehålla siffror.");
                    continue;
                }


                // Checks if the username and PIN code match any of the users in the arrays.
                for (int i = 0; i < users.Length; i++)
                {
                    // both username and PIN code must match for the login to be successful.
                    if (username == users[i] && pin == pins[i])
                    {
                        Console.WriteLine("Inloggningen lyckades!");
                        return i;
                    }
                }


                // If the username and PIN code do not match any of the users in the arrays,
                // it will print an error message and increment the attempts counter.
                attempts++;
                Console.WriteLine("Fel användarnamn eller PIN-kod.");
                Console.WriteLine($"Du har {3 - attempts} försök kvar.");
            }


                Console.WriteLine("Du har angett fel uppgifter tre gånger.");
            return -1;
        }


        static void MainMenu(int userIndex, string[,] accountNames, decimal[,] balances, int[] pins)
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

                //Switch statement to handle the user's choice in the main menu.

                switch (choice)
                {
                    case "1":
                        ShowAccounts(userIndex, accountNames, balances);
                        break;

                    case "2":
                        Transfer(userIndex, accountNames, balances);
                        break;

                    case "3":
                        Withdraw(userIndex, accountNames, balances, pins);
                        break;



                    // If the user chooses to log out, the program will print a message and return to the login screen.
                    case "4":
                        Console.WriteLine("Du loggas ut...");
                        return;

                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }

            }
        }

        static void ShowAccounts(int userIndex, string[,] accountNames, decimal[,] balances)
        {
            Console.WriteLine("\n--- DINA KONTON ---");

            // Loop through the account names and balances for the logged-in user and display them.
            for (int i = 0; i < accountNames.GetLength(1); i++)
            {
                if (!string.IsNullOrEmpty(accountNames[userIndex, i]))
                // Only display accounts that have a name. 
                {
                    Console.WriteLine($"{i + 1}. {accountNames[userIndex, i]}: {balances[userIndex, i]} kr");
                }
            }

            Console.WriteLine("\nTryck på Enter för att gå tillbaka till huvudmenyn.");
            Console.ReadLine();
        }

            static void Transfer(int userIndex, string[,] accountNames, decimal[,] balances)

        
        {
            Console.WriteLine("\n--- ÖVERFÖR PENGAR ---");

            // Loop through the account names and balances for the logged-in user and display them.        
            for (int i = 0; i < accountNames.GetLength(1); i++)
                    {
                        if (!string.IsNullOrEmpty(accountNames[userIndex, i]))
                        {
                            Console.WriteLine($"{i + 1}. {accountNames[userIndex, i]}: {balances[userIndex, i]} kr");
                        }
                    }

                    Console.Write("Vilket konto vill du föra över pengar från? ");
                    string fromInput = Console.ReadLine();

             // Check if the input is a valid integer and if it corresponds to an existing account.
            if (!int.TryParse(fromInput, out int fromAccount))
                    {
                        Console.WriteLine("Du måste ange ett kontonummer med siffror.");
                        Console.ReadLine();
                        return;
                    }

                    fromAccount--;

            // Check if the account number is valid and if the account exists for the user.       
            if (fromAccount < 0 || fromAccount >= accountNames.GetLength(1) ||
                        string.IsNullOrEmpty(accountNames[userIndex, fromAccount]))
                    {
                        Console.WriteLine("Kontot finns inte.");
                        Console.ReadLine();
                        return;
                    }

                    Console.Write("Vilket konto vill du föra över pengar till? ");
                    string toInput = Console.ReadLine();


            // Check if the input uses digits and if it corresponds to an existing account.
            if (!int.TryParse(toInput, out int toAccount))
                    {
                        Console.WriteLine("Du måste ange ett kontonummer med siffror.");
                        Console.ReadLine();
                        return;
                    }

                    toAccount--;


            // Check if the account number is valid and if the account exists for the user.
            if (toAccount < 0 || toAccount >= accountNames.GetLength(1) ||
                        string.IsNullOrEmpty(accountNames[userIndex, toAccount]))
                    {
                        Console.WriteLine("Kontot finns inte.");
                        Console.ReadLine();
                        return;
                    }

                    Console.Write("Hur mycket vill du föra över? ");
                    string amountInput = Console.ReadLine();

            
                    if (!decimal.TryParse(amountInput, out decimal amount))
                    {
                        Console.WriteLine("Du måste ange ett belopp med siffror.");
                        Console.ReadLine();
                        return;
                    }

                    if (amount <= 0)
                    {
                        Console.WriteLine("Beloppet måste vara större än 0.");
                    }
                    else if (amount > balances[userIndex, fromAccount])
                    {
                        Console.WriteLine("Det finns inte tillräckligt med pengar på kontot.");
                    }

            // If all checks pass, perform the transfer by deducting the amount
            // from the source account and adding it to the destination account.
            else
            {
                        balances[userIndex, fromAccount] -= amount;
                        balances[userIndex, toAccount] += amount;

                        Console.WriteLine("Överföringen lyckades!");
                        Console.WriteLine($"{accountNames[userIndex, fromAccount]}: {balances[userIndex, fromAccount]} kr");
                        Console.WriteLine($"{accountNames[userIndex, toAccount]}: {balances[userIndex, toAccount]} kr");
                    }

                    Console.WriteLine("\nTryck på Enter för att gå tillbaka till huvudmenyn.");
                    Console.ReadLine();
                }

        // Method to handle withdrawing money from an account. 
        static void Withdraw(int userIndex, string[,] accountNames, decimal[,] balances, int[] pins)
        {
            Console.WriteLine("\n--- TA UT PENGAR ---");

            // Loop through the account names and balances for the logged-in user and display them.
            for (int i = 0; i < accountNames.GetLength(1); i++)
            {
                if (!string.IsNullOrEmpty(accountNames[userIndex, i]))
                {
                    Console.WriteLine($"{i + 1}. {accountNames[userIndex, i]}: {balances[userIndex, i]} kr");
                }
            }

            Console.Write("Vilket konto vill du ta ut pengar från? ");
            string accountInput = Console.ReadLine();

            // Check if the input is a valid integer and if it corresponds to an existing account.
            if (!int.TryParse(accountInput, out int account))
            {
                Console.WriteLine("Du måste ange ett kontonummer med siffror.");
                Console.ReadLine();
                return;
            }

            account--;

            // Check if the account number is valid and if the account exists for the user.
            if (account < 0 || account >= accountNames.GetLength(1) ||
                string.IsNullOrEmpty(accountNames[userIndex, account]))
            {
                Console.WriteLine("Kontot finns inte.");
                Console.ReadLine();
                return;
            }

            Console.Write("Hur mycket vill du ta ut? ");
            string amountInput = Console.ReadLine();

            if (!decimal.TryParse(amountInput, out decimal amount))
            {
                Console.WriteLine("Du måste ange ett belopp med siffror.");
                Console.ReadLine();
                return;
            }

            if (amount <= 0)
            {
                Console.WriteLine("Beloppet måste vara större än 0.");
                Console.ReadLine();
                return;
            }

            if (amount > balances[userIndex, account])
            {
                Console.WriteLine("Det finns inte tillräckligt med pengar på kontot.");
                Console.ReadLine();
                return;
            }

            Console.Write("Ange din PIN-kod för att bekräfta uttaget: ");
            string pinInput = Console.ReadLine();

            if (!int.TryParse(pinInput, out int pin))
            {
                Console.WriteLine("PIN-koden måste innehålla siffror.");
                Console.ReadLine();
                return;
            }

            if (pin != pins[userIndex])
            {
                Console.WriteLine("Fel PIN-kod. Uttaget avbröts.");
                Console.ReadLine();
                return;
            }

            // If all checks pass, perform the withdrawal by deducting the amount from the selected account.
            balances[userIndex, account] -= amount;

            Console.WriteLine("Uttaget lyckades!");
            Console.WriteLine($"Nytt saldo på {accountNames[userIndex, account]}: {balances[userIndex, account]} kr");

            Console.WriteLine("\nTryck på Enter för att gå tillbaka till huvudmenyn.");
            Console.ReadLine();
        }


    }
        }
        



              
        
