using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace Discord_Botler.Commands
{
    // This class inherits from BaseCommandModule to create command modules for the bot
    // Ensure you register your command in Program.cs (line 39)
    public class ExampleCommands : BaseCommandModule
    {
        // This attribute defines the name of the command, which users can trigger by typing "prefix+command", e.g., !example
        [Command("example")]
        // This attribute allows you to define alternative names (aliases) for the command, e.g., !ex
        [Aliases("ex")]
        // The CommandContext parameter provides access to various bot capabilities, including the user and the channel
        public async Task ExampleCommand(CommandContext context)
        {
            // The bot's response when the command is executed
            var user = context.User.Username;

            await context.Channel.SendMessageAsync($"Oooh, {user} is looking at the bot's example command - I wonder if they'll write one?");
        }
    }
}
