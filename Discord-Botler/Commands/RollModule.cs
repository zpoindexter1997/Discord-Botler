using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace Discord_Botler.Commands
{
    public class RollModule : BaseCommandModule
    {
        // !roll 6 -> 5
        [Command("roll")]
        [Aliases("r")]
        [Description("Rolls some die.")]
        public async Task OneRollAsync(CommandContext context,
            [Description("Max number on the dice.")] int max)
        {
            var roll = new Dice();
            var result = roll.SmartRoll(max);
            await context.Channel.SendMessageAsync($"{result}");
        }

        // !roll 1 6 -> 5
        [Command("roll")]
        [Aliases("r")]
        [Description("Rolls some die.")]
        public async Task RollAsync(CommandContext context,
            [Description("Number of dice to roll.")] int die,
            [Description("Max number on the dice.")] int max)
        {
            var roll = new Dice();
            var results = new int[die];
            var total = 0;
            for (var i = 0; i < die; i++)
            {
                var result = roll.SmartRoll(max);
                results[i] = result;
                total += result;
            }

            await context.Channel.SendMessageAsync($"{string.Join(", ", results)} for a total of {total}");
        }

        // !checkroll 100 60 -> Imagine OhNoItsZ rolling 65 lmao, better luck next time ya bitch.
        [Command("checkroll")]
        [Aliases("cr")]
        [Description("Rolls some die and sees if you pass the check.")]
        public async Task OneCheckRollAsync(CommandContext context,
        [Description("Max number on the dice.")] int max,
        [Description("The number you must get lower than.")] int check)
        {
            var user = context.User.Username;
            var roll = new Dice();
            var result = roll.SmartRoll(max);

            if (result <= check)
            {
                if (result % 11 == 0)
                {
                    await context.Channel.SendMessageAsync($"HOLY SHIT {user}, YOU ROLLED {result}! THAT'S A CRITICAL BABYYYY!");
                }
                await context.Channel.SendMessageAsync($"{user} rolled {result}, good shit my guy!");
            }
            else await context.Channel.SendMessageAsync($"Imagine {user} rolling {result} lmao, better luck next time ya bitch.");
        }


        // !checkroll 2 20 10 -> 7 Lmao, imagine being a nerd
        [Command("checkroll")]
        [Aliases("cr")]
        [Description("Rolls some die and sees if you pass the check.")]
        public async Task CheckRollAsync(CommandContext context,
            [Description("Number of dice to roll.")] int die,
            [Description("Max number on the dice.")] int max,
            [Description("The number you must get lower than.")] int check)
        {
            var user = context.User.Username;
            var roll = new Dice();
            var results = new int[die];
            var total = 0;
            for (var i = 0; i < die; i++)
            {
                var result = roll.SmartRoll(max);
                results[i] = result;
                total += result;
            }

            if (total <= check)
            {
                if (total % 11 == 0)
                {
                    await context.Channel.SendMessageAsync($"HOLY SHIT {user}, YOU ROLLED {string.Join(", ", results)} for a total of {total}! THAT'S A CRITICAL BABYYYY!");
                }
                await context.Channel.SendMessageAsync($"{user} rolled {string.Join(", ", results)} for a total of {total}, good shit my guy!");
            }
            else await context.Channel.SendMessageAsync($"Imagine {user} rolling {string.Join(", ", results)} for a total of {total} lmao, better luck next time ya bitch.");
        }
    }

    public class Dice
    {
        Random random = new Random();

        public int SmartRoll(int die, int max)
        {
            return die * random.Next(1, max);
        }
        public int SmartRoll(int max)
        {
            return random.Next(1, max);
        }
    }
}
