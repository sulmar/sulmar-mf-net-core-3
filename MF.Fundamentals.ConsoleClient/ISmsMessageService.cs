using System;
using System.Collections.Generic;
using System.Text;

namespace MF.Fundamentals.ConsoleClient
{
    // interface (kontrakt)
    // wszystkie metody są publiczne
    // nie zawierają implementacji, posiadają tylko same sygnatury
    public interface ISmsMessageService
    {
        void SendSms(string message);
        decimal GetCostSms(string message);
    }

    public interface IPremiumSmsMessageService
    {
        void SendPremiumSms(string message);
        decimal GetCostPremiumSms(string message);
    }

    // implementacja interfejsu - musi implementować wszystkie metody, bez wyjątku
    public class ASmsMessageService : ISmsMessageService, IPremiumSmsMessageService  // można implementować wiele interfejsów
    {
        private const decimal unitCost = 0.19m;

        public void SendSms(string message)
        {
            Console.WriteLine($"Send sms {message} via operator A");
        }

        public decimal GetCostSms(string message)
        {
            return message.Length * unitCost;
        }

        public void SendPremiumSms(string message)
        {
            Console.WriteLine($"Send premium sms {message} via operator A");
        }

        public decimal GetCostPremiumSms(string message)
        {
            return message.Length * unitCost + 10m;
        }
    }

    public class BSmsMessageService : ISmsMessageService
    {
        private const decimal unitCost = 0.29m;

        public decimal GetCostSms(string message)
        {
            return message.Length * unitCost;
        }

        public void SendSms(string message)
        {
            Console.WriteLine($"Send sms {message} via operator B");
        }
    }

    public class CSmsMessageService : IPremiumSmsMessageService
    {
        public decimal GetCostPremiumSms(string message)
        {
            return 20;
        }

        public void SendPremiumSms(string message)
        {
            Console.WriteLine($"Send sms {message} via operator C");
        }
    }

    public class SmsMessageFactory
    {
        public ISmsMessageService Create(string name)
        {
            switch(name)
            {
               case "A": return new ASmsMessageService(); 
               case "B": return new BSmsMessageService();

               default: throw new NotSupportedException(name);
            }
        }
    }
}
