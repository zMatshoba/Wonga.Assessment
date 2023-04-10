using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RabbitMQ.Client;

namespace Wonga.ServiceA
{
    internal class MessageSender : IDisposable
    {
        #region Constants
        private const string USER_NAME = "guest";
        private const string PASSWORD = "guest";
        private const string HOSTNAME = "localhost";
        private const int PORT = 5672;
        private const string VIRTUAL_HOST = "/";
        private const string QUEUE_NAME = "queue-name";
        #endregion

        private IConnection? con;
        private IModel? channel;
        private ConnectionFactory factory = new ConnectionFactory()
        {
            UserName = USER_NAME,
            Password = PASSWORD,
            HostName = HOSTNAME,
            Port = PORT,
            VirtualHost = VIRTUAL_HOST
        };


        public bool CreateChannel() 
        {
            con = factory.CreateConnection();

            if (con.IsOpen)
            {
                channel = con.CreateModel();
                return true;
            }
            else
                return false;
        }



        public void Dispose()
        {
            if (channel != null)
                channel.Close();
            else if (con != null)
                con.Close();
        }
    }
}
