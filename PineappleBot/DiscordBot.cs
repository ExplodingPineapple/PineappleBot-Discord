///Created By Deanosim1
using Discord;
using Discord.Commands;
using System;

namespace PineappleBot
{
    public class DiscordBot
    {
        DiscordClient client;
        CommandService commands; 

        public DiscordBot()
        {

            client = new DiscordClient(input =>
            {
                input.LogLevel = LogSeverity.Info;
                input.LogHandler = Log;
            });

            client.UsingCommands(input =>
            {
                input.PrefixChar = '!';
                input.AllowMentionPrefix = true;
            });

            commands = client.GetService<CommandService>();

            commands.CreateCommand("Ping").Do(async (e) =>
            {
                await e.Channel.SendMessage("Pong!");
            });

            client.ExecuteAndWait(async () =>
            {
                try
                {
                    await client.Connect("INSERT BOT TOKEN HERE", TokenType.Bot);
                }
                catch (Discord.Net.HttpException e)
                {
                    Console.WriteLine("An error occured while connecting to Discord's servers:\n{0}", e.Message);
                }
            });
        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
