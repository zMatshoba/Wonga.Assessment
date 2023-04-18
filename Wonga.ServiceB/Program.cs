using System;
using System.Text;
using System.Text.RegularExpressions;

using Newtonsoft.Json;

using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Wonga.ServiceB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Constants
            const string USER_NAME = "guest";
            const string PASSWORD = "guest";
            const string HOSTNAME = "localhost";
            const int PORT = 5672;
            const string QUEUE_NAME = "wonga-queue";
            #endregion

            ConnectionFactory factory = new()
            {
                UserName = USER_NAME,
                Password = PASSWORD,
                HostName = HOSTNAME,
                Port = PORT
            };

            using var conn = factory.CreateConnection();
            using var channel = conn.CreateModel();
            string result = "";
            channel.QueueDeclare(
                QUEUE_NAME,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                var message = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(body));
                if (ValidateMessage.Validate(message.ToString()))
                    result = $"Hello {ValidateMessage.MessageSplit(message.ToString())}, I am your father!";
                else
                    result = "Error, Couldn't Read The Message...";
                Console.WriteLine(result);
            };

            channel.BasicConsume(QUEUE_NAME, autoAck: true, consumer);


            Console.ReadLine();
        }


    }
}