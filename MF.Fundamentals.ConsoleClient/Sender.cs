using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MF.Fundamentals.ConsoleClient
{
    public class Sender
    {

        // Metoda synchroniczna
        public void Send(string message)
        {
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Sending... {message}");

            Thread.Sleep(5000);

            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Sent.");
        }

        // Metoda asynchroniczna bez wyniku (void)
        public Task SendAsync(string message)
        {
            return Task.Run(() => Send(message));
        }


        // Metoda synchroniczna
        public decimal Calculate(string message)
        {
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Calculating... {message}");

            Thread.Sleep(7000);

            decimal cost = message.Length * 0.99m;

            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} {cost} Calculated.");

            return cost;
        }

        // Metoda asynchroniczna z wynikiem (typu T)
        public Task<decimal> CalculateAsync(string message)
        {
            return Task.Run(() => Calculate(message));
        }
    }
}
