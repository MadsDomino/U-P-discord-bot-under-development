using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Discord.Commands;

namespace MyBot
{
    public class Program
    {
        public static void Main(string[] args) => 
            new Program().Start().GetAwaiter().GetResult();


        private DiscordSocketClient client;
        private CommandHandler handler;

        public async Task Start()
        {
            //Define the DiscordSocketClient
            client = new DiscordSocketClient();

            var token = "Token";

            //Login and connect to discord
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();

            var map = new DependencyMap();
            map.Add(client);

            handler = new CommandHandler();
            await handler.Install(map);
            //Console Log!
            Console.WriteLine($"{DateTime.UtcNow}: YourBot initiated...");

            //Block this program untill it is closed
            await Task.Delay(-1);
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

    }
}