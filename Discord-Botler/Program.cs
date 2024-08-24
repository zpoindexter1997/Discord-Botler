using Discord_Botler.Commands;
using DSharpPlus;
using DSharpPlus.CommandsNext;

namespace Discord_Botler
{
    internal class Program
    {
        private static DiscordClient? Client { get; set; }
        private static CommandsNextExtension? Commands {  get; set; }
        
        static async Task Main(string[] args)
        {
            var jsonReader = new JsonReader();
            await jsonReader.ReadJSON();

            var discordConfig = new DiscordConfiguration()
            {
                Intents = DiscordIntents.All,
                Token = jsonReader.token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
            };

            Client = new DiscordClient(discordConfig);

            Client.Ready += Client_Ready;

            var commandsConfig = new CommandsNextConfiguration()
            {
                StringPrefixes = new string[] { jsonReader.prefix },
                EnableMentionPrefix = true,
                EnableDms = true,
                EnableDefaultHelp = false,
            };

            Commands = Client.UseCommandsNext(commandsConfig);

            Commands.RegisterCommands<ExampleCommands>();
            Commands.RegisterCommands<RandomTargetCommand>();
            Commands.RegisterCommands<InsultCommand>();
            Commands.RegisterCommands<RollCommand>();
            Commands.RegisterCommands<ComplimentCommand>();

            await Client.ConnectAsync();
            await Task.Delay(-1);
        }

        private static Task Client_Ready(DiscordClient sender, DSharpPlus.EventArgs.ReadyEventArgs args)
        {

            Console.WriteLine("The Botler is at your service.");
            return Task.CompletedTask;
        }
    }
}