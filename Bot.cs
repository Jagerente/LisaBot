using DSharpPlus;
using DSharpPlus.EventArgs;
using DSharpPlus.CommandsNext;
using LisaBot.Commands;
using System;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;

namespace LisaBot
{
    class Bot
    {
        public const string BotName = "LisaBot";
        public DiscordClient Client { get; private set; }
        public InteractivityExtension Interactivity { get; private set; }
        public CommandsNextExtension Commands { get; private set; }

        public  async Task RunAsync()
        {
            var json = string.Empty;

            if (!File.Exists("config.json"))
            {
                var jsobj = new JsonStorage();
                var obj = new ConfigJson();
                Console.WriteLine("Set token:");
                obj.Token = Console.ReadLine();
                Console.WriteLine("Set prefix:");
                obj.Prefix = Console.ReadLine();
                jsobj.StoreObject(obj, $@"{Directory.GetCurrentDirectory()}\config.json");
            }

            using (var fs = File.OpenRead("config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = await sr.ReadToEndAsync().ConfigureAwait(false);

            var configJson = JsonConvert.DeserializeObject<ConfigJson>(json);

            var config = new DiscordConfiguration
            {
                Token = configJson.Token,
                TokenType = TokenType.Bot,
                AutoReconnect  = true,
                MinimumLogLevel = Microsoft.Extensions.Logging.LogLevel.Debug
            };

            Client = new DiscordClient(config);

            Client.Ready += OnClientReady;

            Client.MessageCreated += OnMessageCreated;

            Client.GuildAvailable += OnGuildAvailable;

            Client.UseInteractivity(new InteractivityConfiguration());

            var commandsConfig = new CommandsNextConfiguration
            {
                StringPrefixes = new string[] { configJson.Prefix },
                EnableMentionPrefix = true,
                EnableDms = true,
                CaseSensitive = false
            };

            Commands = Client.UseCommandsNext(commandsConfig);

            Commands.RegisterCommands<OtherCommands>();

            //Commands.RegisterCommands<GuideCommands>();

            Commands.CommandExecuted += OnCommandExecuted;

            await Client.ConnectAsync();

            await Task.Delay(-1);
        }

        private async Task OnGuildAvailable(DiscordClient sender, GuildCreateEventArgs e)
        {
            Console.WriteLine($"Guild available: {e.Guild.Name}");
            await Task.CompletedTask;
        }

        private async Task OnMessageCreated(DiscordClient sender, MessageCreateEventArgs e)
        {
            Console.WriteLine($"{e.Guild.Name}/#{e.Channel.Name.TrimStart("Channel".ToCharArray())}/{e.Author.Username}: {e.Message.Content}");
            await Task.CompletedTask;
        }

        private async Task OnCommandExecuted(CommandsNextExtension sender, CommandExecutionEventArgs e)
        {
            Console.WriteLine($"{e.Context.Guild.Name}/#{e.Context.Channel.Name.TrimStart("Channel".ToCharArray())}/{e.Context.User.Username} successfully executed '{e.Command.QualifiedName}'");
            await Task.CompletedTask;
        }

        private async Task OnClientReady(DiscordClient sender, ReadyEventArgs e)
        {
            Console.WriteLine($"{BotName} is ready");
            await Task.CompletedTask;
        }
    }
}
