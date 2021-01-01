using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Threading.Tasks;

namespace LisaBot.Commands
{
    public class OtherCommands : BaseCommandModule
    {
        public Random rnd { private get; set; }

        [Command("roll")]
        [Description("Rolls a number.")]
        public async Task Roll(CommandContext ctx, [Description("Range min-max.")] string range = "0-100")
        {
            var min = Convert.ToInt32(range.Split('-')[0]);
            var max = Convert.ToInt32(range.Split('-')[1]);
            await ctx.Channel.SendMessageAsync(rnd.Next(min, max).ToString());
        }

        [Command("roll")]
        [Description("Rolls a number.")]
        public async Task Roll(CommandContext ctx, [Description("Maximum number.")]int max = 100)
        {
            await ctx.Channel.SendMessageAsync(rnd.Next(max).ToString());
        }


        [Command("clean"), Aliases("clear", "purge", "почисти", "очисти")]
        [Description("Cleans chat")]
        public async Task Clean(CommandContext ctx, 
            [Description("Messages count. Default is 100.")] int count = 100, 
            [Description("If not empty, cleans only <userId> messages.")] DSharpPlus.Entities.DiscordUser user = null)
        {
            var k = count;
            await ctx.Message.DeleteAsync();
            while (k != 0)
            { 
            var messages = ctx.Channel.GetMessagesAsync(k).Result;
                foreach (var message in messages)
                {
                    if (user != null && message.Author == user)
                    {
                        await ctx.Channel.DeleteMessageAsync(message);
                        k--;
                    }
                    else if (user == null)
                    {
                        await ctx.Channel.DeleteMessageAsync(message);
                        k--;
                    }
                }
            }
        }
    }
}
