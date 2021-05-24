using Shared;
using System;

namespace App.Broadcaster
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var hostName = "localhost";
            var rabbitMQManager = new RabbitMQManager(hostName);

            while (true)
            {
                Console.WriteLine(">>> Enter first name to send or type 'q' to exit the app. <<<");
                var firstName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(firstName))
                {
                    Console.WriteLine("Enter first name: ");
                    continue;
                }

                if (firstName == "q")
                    return;

                var lastName = GetLastNameInput();

                var userMessage = $"Full name: {firstName} {lastName}";

                Console.WriteLine("[Start]");
                try
                {
                    rabbitMQManager.SendMessage(QueueNames.HELLO_WORLD, userMessage);
                    Console.WriteLine("[Done]");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Something went wrong: {ex.Message}]");
                    Console.ReadKey();
                    return;
                }
            }
        }

        private static string GetLastNameInput()
        {
            while (true)
            {
                Console.WriteLine(">>> Enter last name to send <<<");
                var lastName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(lastName))
                {
                    Console.WriteLine("Enter last name: ");
                    continue;
                }

                return lastName;
            }
        }
    }
}