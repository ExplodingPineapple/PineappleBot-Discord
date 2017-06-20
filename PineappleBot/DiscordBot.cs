///Test
///Test
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

            commands.CreateCommand("Hello").Do(async (e) =>
            {
                await e.Channel.SendMessage("World!");
            });

            client.ExecuteAndWait(async () =>
            {
                await client.Connect("INSERT BOT TOKEN HERE", TokenType.Bot);
            });
        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
