using System.Text;

using Newtonsoft.Json;

using RabbitMQ.Client;

namespace Wonga.ServiceA
{
    internal class MessageSender 
    {
        #region Constants
        private const string USER_NAME = "guest";
        private const string PASSWORD = "guest";
        private const string HOSTNAME = "localhost";
        private const int PORT = 5672;
        private const string VIRTUAL_HOST = "/";
        #endregion

        private readonly string queueName;
        private readonly ConnectionFactory factory = new ()
        {
            UserName = USER_NAME,
            Password = PASSWORD,
            HostName = HOSTNAME,
            Port = PORT
        };


        public MessageSender(string queue)
        {
            this.queueName = queue;
        }

        public bool SendMessageAsync(string message)
        {
            try
            {
                using var conn = factory.CreateConnection();
                using var chan = conn.CreateModel();

                chan.QueueDeclare(
                    queueName,
                    durable: true,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var payload = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                chan.BasicPublish("", queueName, null, payload);

                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

    }
}
