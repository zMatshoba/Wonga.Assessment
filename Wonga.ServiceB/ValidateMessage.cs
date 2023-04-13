using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Wonga.ServiceB
{
    public static class ValidateMessage
    {
        public static string MessageSplit(string message)
        {
            try
            {
                return message.Split(',')[1].Trim();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
        public static bool Validate(string message) => Regex.IsMatch(message, @"Hello my name is,\s[a-zA-Z]*$");
    }
}
