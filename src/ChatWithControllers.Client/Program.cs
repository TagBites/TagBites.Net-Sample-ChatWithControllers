using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatWithControllers.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new TagBites.Net.Client("127.0.0.1", 82);
            client.ControllerResolve += (s, e) =>
            {
                if (e.ControllerType == typeof(IChatClient))
                    e.Controller = new ChatClient();
            };
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
