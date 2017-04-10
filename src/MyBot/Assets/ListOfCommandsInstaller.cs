using System;
using System.Collections.Generic;
using System.Text;

namespace MyBot.Assets
{
    class ListOfCommandsInstaller
    {
        List<Command> commandsList;

        public ListOfCommandsInstaller()
        {
            commandsList = new List<Command>();
            Install();
        }

        public List<Command> ReturnsListOfCommands()
        {
            return commandsList;
        }

        private void Install()
        {
            commandsList.Add(Ping());
            commandsList.Add(Ip());
            commandsList.Add(Help());
        }

        private Command Ping()
        {
            List<string> tempaliaslist = new List<string>();
            Command Ping = new Command();

            Ping.name = "Ping";
            tempaliaslist.Add("ping");
            tempaliaslist.Add("pong");

            Ping.alias = tempaliaslist;

            Ping.description = "Returns a pong";
            return Ping;
        }

        private Command Ip()
        {
            List<string> tempaliaslist = new List<string>();
            Command Ip = new Command();

            Ip.name = "Ip";
            tempaliaslist.Add("ip");
            tempaliaslist.Add("server");
            tempaliaslist.Add("serverip");
            tempaliaslist.Add("csgo");

            Ip.alias = tempaliaslist;

            Ip.description = "Returns the ip of Shievo and Erik's surf server";
            return Ip;
        }

        private Command Help()
        {
            List<string> tempaliaslist = new List<string>();
            Command Help = new Command();

            Help.name = "Help";
            tempaliaslist.Add("help");

            Help.alias = tempaliaslist;

            Help.description = "Gives you a list of commands or displays information about a specific command, by typing help <command name>";
            return Help;
        }
    }
}
