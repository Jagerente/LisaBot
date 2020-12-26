using DSharpPlus;
using DSharpPlus.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LisaBot.Extensions
{
    public static class GuildExtensions
    {
        public static async Task<DiscordEmoji> GetByName(this DiscordGuild guild, string name)
        {
            return (await guild.GetEmojisAsync()).Where(x => x.Name == name).FirstOrDefault();
        }

        public static DiscordEmbedBuilder GABuilder()
        {
            var embed = new DiscordEmbedBuilder();

            embed.Footer = new DiscordEmbedBuilder.EmbedFooter
            {
                Text = "vk.com/genshinacademy",
                IconUrl = "https://sun6-22.userapi.com/impg/dEbY3uoAMVf_VHk-6AIFt5miCKL_PVqYXxkEMg/66TGyOGkN0c.jpg?size=50x0&quality=96&crop=0,0,520,520&sign=e6595e7f7112169f1ade7fe017f2bc67&ava=1"
            };

            return embed;
        }
    }
}