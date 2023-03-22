namespace P06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] bankAccountsInfo = Console.ReadLine().Split(',');

            Dictionary<string, decimal> bankAccounts = new Dictionary<string, decimal>();

            foreach (var bankAccount in bankAccountsInfo)
            {
                string[] accountInfo = bankAccount.Split('-');
                string accountNumber = accountInfo[0];
                decimal balance = decimal.Parse(accountInfo[1]);

                bankAccounts.Add(accountNumber, balance);
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split();

                string cmdType = cmdArgs[0];
                string accountNumber = cmdArgs[1];
                decimal sum = decimal.Parse(cmdArgs[2]);

                try
                {
                    if (!bankAccounts.ContainsKey(accountNumber))
                    {
                        throw new InvalidAccountException(ExceptionMessages.InvalidAccountException);
                    }
                    switch (cmdType)
                    {
                        case "Deposit":
                            bankAccounts[accountNumber] += sum;
                            break;
                        case "Withdraw":
                            if (bankAccounts[accountNumber] < sum)
                            {
                                throw new InsufficientBalanceException(ExceptionMessages.InsufficientBalanceException);
                            }
                            bankAccounts[accountNumber] -= sum;
                            break;
                        default:
                            throw new InvalidCommandException(ExceptionMessages.InvalidCommandException);
                    }

                    Console.WriteLine($"Account {accountNumber} has new balance: {bankAccounts[accountNumber]:F2}");
                }
                catch (InvalidCommandException ice)
                {
                    Console.WriteLine(ice.Message);
                }
                catch (InvalidAccountException iae)
                {
                    Console.WriteLine(iae.Message);
                }
                catch (InsufficientBalanceException ibe)
                {
                    Console.WriteLine(ibe.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }

            }
        }
    }

    static class ExceptionMessages
    {
        public const string InvalidCommandException = "Invalid command!";
        public const string InvalidAccountException = "Invalid account!";
        public const string InsufficientBalanceException = "Insufficient balance!";
    }

    class InvalidCommandException : Exception
    {
        public InvalidCommandException(string message) : base(message)
        {

        }
    }

    class InvalidAccountException : Exception
    {
        public InvalidAccountException(string message) : base(message)
        {
        }
    }

    class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message)
        {
        }
    }
}