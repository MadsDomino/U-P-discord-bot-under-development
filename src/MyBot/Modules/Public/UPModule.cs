using System;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.Net;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Collections.Generic;
using MyBot.Assets;

namespace MyBot.Modules.Public
{

    public class UPModule : ModuleBase
    {
        [Command("Ping")]
        [Alias("ping", "pong")]
        [Summary("Returns a pong")]
        public async Task ping()
        {
            await ReplyAsync(Context.User.Mention + ", Pong!");
        }

        [Command("Ip")]
        [Alias("ip", "server", "serverip", "csgo")]
        [Summary("Returns the ip of Shievo and Erik's surf server")]
        public async Task ip()
        {
            await ReplyAsync("The ip to our cgso surf server is: '37.187.77.87:29102'\n" + "Console command: 'connect 37.187.77.87:29102'");
        }

        [Command("Help")]
        [Alias("help")]
        [Summary("Gives you a list of commands or displays information about a specific command, by typing help <command name>")]
        public async Task help(params string[] args)
        {
            ListOfCommandsInstaller CommandsInstaller = new ListOfCommandsInstaller();
            List<Command> ListOfCommands = new List<Command>();

            ListOfCommands = CommandsInstaller.ReturnsListOfCommands();

            if(args.Length < 1)
            {
                string finalReply = "";
                finalReply = "```\n";
                finalReply += "List of commands:\n";
                foreach (Command command in ListOfCommands)
                {
                    finalReply += command.name + "\n";
                }
                finalReply += "For information of a specific command type help <command name>\n";
                finalReply += "```";

                await ReplyAsync(finalReply);
            }
            else
            {
                bool replied = false;
                foreach (Command command in ListOfCommands)
                {
                    if(command.name == args[0] || command.alias.Contains(args[0]))
                    {
                        await ReplyAsync(command.description);
                        replied = true;
                        break;
                    }
                }
                if(!replied)
                {
                    await ReplyAsync("Could not find command");
                }
            }
        }

        [Command("ServerInfo")]
        [Alias("serverinfo", "Serverinfo", "serverInfo")]
        [Summary("Displays the current state of the csgo server")]
        public async Task ServerInfo()
        {
            Random rnd = new Random();

            Embed welcomeEmb = new EmbedBuilder()
            .WithColor(new Discord.Color(96, 27, 11))
            .WithDescription("Server status: ")
            .WithImageUrl("http://cache.gametracker.com/server_info/37.187.77.87:29102/b_350_20_692108_381007_FFFFFF_000000.png" + "?_=" + rnd.Next(1, 99999999));

            await ReplyAsync("", embed: welcomeEmb);
        }
    }
}