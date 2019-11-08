using System;

namespace csharp_patterns
{
    class Program
    {
        //Product
        public abstract class ISavingAccount
        {
            public decimal Balance { get; set; }
        }

        //Concrete Product
        public class CitiSavingsAccount : ISavingAccount
        {
            public CitiSavingsAccount()
            {
                Balance = 5000;
            }
        }

        //Concrete Product
        public class NationalSavingsAccount : ISavingAccount
        {
            public NationalSavingsAccount()
            {
                Balance = 2000;
            }
        }

        //Creator
        interface ICreditUnionFactory
        {
            ISavingAccount GetSavingAccount(string acctNo);
        }

        //Concrete Creator

        public class SavingsAccountFactory : ICreditUnionFactory
        {
            public ISavingAccount GetSavingAccount(string acctNo)
            {
                if (acctNo.Contains("CITI")) { return new CitiSavingsAccount(); }
                else
                if (acctNo.Contains("NATIONAL")) { return new NationalSavingsAccount(); }
                else
                    throw new ArgumentException("Invalid Account Number");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var factory  = new SavingsAccountFactory() as ICreditUnionFactory;
            var citiAcct = factory.GetSavingAccount("CITI-321");
            var nationalAcct = factory.GetSavingAccount("NATIONAL-987");

            Console.WriteLine($"My citi balance is ${citiAcct.Balance}" +  
            $" and national balance is ${nationalAcct.Balance}");
        }
    }
}

