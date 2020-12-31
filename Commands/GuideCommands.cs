using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using HSNXT.DSharpPlus.ModernEmbedBuilder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using LisaBot.Extensions;
using VkNet;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;

using Microsoft.EntityFrameworkCore;

using LisaBot.Models.Guides;
using LisaBot.Database;

namespace LisaBot.Commands
{
    [ModuleLifespan(ModuleLifespan.Transient)]
    public class GuideCommands : BaseCommandModule
    {
        //Sets by DependencyInjection
        public LisaBotContext dbContext { private get; set; }

        [Command("guides")]
        public async Task Embed(CommandContext ctx)
        {
            IList<Guide> allGuides = await dbContext.Guides
                .Include(g => g.Category)
                .ToListAsync();

            foreach (Guide guide in allGuides)
            {
                var embed = GuildExtensions.CreateGenshinAcademyEmbedBuilder();
                embed.Author = new DiscordEmbedBuilder.EmbedAuthor
                {
                    Name = guide.Category.Title,
                    IconUrl = ctx.User.AvatarUrl,
                    Url = "https://vk.com/page-200500476_56853211"
                };
                embed.Thumbnail = new DiscordEmbedBuilder.EmbedThumbnail
                {
                    Url = "https://sun9-22.userapi.com/impg/dEbY3uoAMVf_VHk-6AIFt5miCKL_PVqYXxkEMg/66TGyOGkN0c.jpg?size=520x520&quality=96&proxy=1&sign=6390eee094afef6d9682db5ad1c48cca&type=album"
                };
                embed.Title = guide.Title;
                embed.Description = guide.Information.Description;
                embed.Url = guide.Information.Link;
                embed.Color = DiscordColor.Cyan;
                embed.Build();

                await ctx.Channel.SendMessageAsync(embed: embed).ConfigureAwait(false);
            }
        }

        [Command("test")]
        public async Task Test(CommandContext ctx)
        {
            IList<Category> cats = await dbContext.Categories
                .Include(c => c.Guides)
                .ToListAsync();

            foreach (Category cat in cats)
            {
                var builder = new DiscordEmbedBuilder
                {
                    Author = new DiscordEmbedBuilder.EmbedAuthor
                    {
                        Name = "Гайды",
                        IconUrl = "https://emoji.gg/assets/emoji/9893_Books1.png",
                        Url = "https://vk.com/page-200500476_56853211"
                    },
                    Thumbnail = new DiscordEmbedBuilder.EmbedThumbnail
                    {
                        Url = "https://sun9-22.userapi.com/impg/dEbY3uoAMVf_VHk-6AIFt5miCKL_PVqYXxkEMg/66TGyOGkN0c.jpg?size=520x520&quality=96&proxy=1&sign=6390eee094afef6d9682db5ad1c48cca&type=album"
                    },
                };
                var str = string.Empty;
                try
                {
                    foreach (Guide guide in cat.Guides)
                    {
                        str += guide.Information.IsPremium ? await ctx.Guild.GetByName("donut") : string.Empty;
                        str += $"[{guide.Title}]({guide.Information.Link})\n";
                    }
                }
                catch
                {
                    Console.WriteLine("here");
                }
                builder.AddField($"{cat.Title}", str, true);
                await ctx.Channel.SendMessageAsync(embed: builder.Build()).ConfigureAwait(false);
            }
        }

        [Command("paimon")]
        public async Task Paimon(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("https://tenor.com/view/genshin-impact-paimon-gif-18658050");
        }

        long oID = -200500476;
        long aID = 277817193;

        [Command("build")]
        public async Task Build(CommandContext ctx, string character = "")
        {
            var photos = await Bot.Vk.Photo.GetAsync(new PhotoGetParams 
            { 
                OwnerId = oID, 
                AlbumId = VkNet.Enums.SafetyEnums.PhotoAlbumType.Id(aID),
                PhotoSizes = true
            });

            var builds = new Dictionary<string, string>();
            foreach (var photo in photos)
            {
                foreach (var tag in photo.Text.Split("/"))
                {
                    builds.Add(tag.ToLower(), photo.Sizes[photo.Sizes.Count - 1].Url.ToString());
                }
            }

            try
            {
                var embed = GuildExtensions.CreateGenshinAcademyEmbedBuilder();
                embed.Author = new DiscordEmbedBuilder.EmbedAuthor
                {
                    Name = "Библиотека билдов",
                    IconUrl = "https://emoji.gg/assets/emoji/9893_Books1.png",
                    Url = "https://vk.com/album-200500476_277817193"
                };
                embed.ImageUrl = builds[character];
                embed.Build();

                await ctx.Channel.SendMessageAsync(embed: embed).ConfigureAwait(false);
            }
            catch
            {
                await ctx.Channel.SendMessageAsync("Доступные билды:");
                foreach (var build in builds)
                {
                    await ctx.Channel.SendMessageAsync(build.Key);
                }
            }

        }
    }
}