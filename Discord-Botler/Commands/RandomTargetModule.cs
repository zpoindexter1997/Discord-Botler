using Discord.Commands;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Threading.Tasks;

namespace WarzoneDiscordBot.Modules
{
    public class RandomTargetModule : BaseCommandModule
    {
        [Command("target")]
        [Aliases("t", "tp")]
        [Description("Targets a random user in the party.")]
        public async Task RandomTargetParty(CommandContext context)
        {
            var users = context.Channel.Users;
            var amount = context.Channel.Users.Count;
            var random = new Random();
            var userList = new string[amount];
            var i = 0;
            foreach (var user in users)
            {
                userList[i] = user.ToString();
                i++;
            }
            var randomUser = userList[random.Next(0, amount)];
            await context.Channel.SendMessageAsync($"{randomUser}");
        }

    }
}
