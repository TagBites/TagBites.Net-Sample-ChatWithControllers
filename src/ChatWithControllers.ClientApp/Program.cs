using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TagBites.Net;

namespace ChatWithControllers.ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new Client("127.0.0.1", 82);
            client.Use<IChatClient, ChatClient>();
            client.ConnectAsync().Wait();

            while (true)
            {
                var message = Console.ReadLine();
                client.GetController<IChatServer>().Send(message);
            }
        }
    }

    public class ChatClient : IChatClient
    {
        public void MessageReceive(string userName, string message)
        {
            Console.WriteLine($"{userName ?? "Server"}: {message}");
        }
    }
}
