using System;

namespace Wonga.ServiceA // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            const string QUEUE_NAME = "wonga-queue";
            MessageSender send = new(QUEUE_NAME);

            Console.WriteLine("Hello what is your name?");

            var message = MessageConsolidation(Console.ReadLine());

            if (!String.IsNullOrEmpty(message))
            {
                var result = await Task.Run(()=>send.SendMessageAsync(message)) ? "Message Sent" : "Failed to send";
                Console.WriteLine(result);
            }
            else
                Console.WriteLine("Error, No Name Was Entered...");

            Console.ReadLine();
        }

        private static string MessageConsolidation(string? name)
        {

            if (!String.IsNullOrEmpty(name))
                return "Hello my name is, " + name;
            else
                return string.Empty;
        }
    }
}


