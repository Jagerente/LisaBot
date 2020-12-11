using DSharpPlus;
using DSharpPlus.EventArgs;
using DSharpPlus.CommandsNext;
using System;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace LisaBot
{
    class Bot
    {
        public DiscordClient Client { get; private set; }
        public CommandsNextModule Commands { get; private set; }

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
                LogLevel = LogLevel.Debug,
                UseInternalLogHandler = true
            };

            Client = new DiscordClient(config);

            Client.Ready += OnClientReady;

            var commandsConfig = new CommandsNextConfiguration
            {
                StringPrefix = configJson.Prefix,
                EnableMentionPrefix = true,
                EnableDms = true,
                IgnoreExtraArguments = true
            };

            Commands = Client.UseCommandsNext(commandsConfig);

            await Client.ConnectAsync();

            await Task.Delay(-1);
        }

        private Task OnClientReady(ReadyEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}
