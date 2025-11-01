using System;
using System.Collections.Generic;

namespace ProxyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Cheque cheque = new();
            cheque.Request();
            Console.ReadKey();
        }
    }

    public abstract class Account //Subject
    {
        public abstract void Request();
    }

    public class BankAccount : Account //RealSubject
    {
        public override void Request()
        {
            Console.WriteLine("Called Real Subject Request()");
        }
    }

    public class Cheque : Account //Proxy
    {
        private BankAccount bankAccount;

        public override void Request()
        {
            Console.WriteLine("Called Proxy Request()");
            if (bankAccount == null)
            {
                bankAccount = new BankAccount();
            }
            bankAccount.Request();
        }
    }
}
