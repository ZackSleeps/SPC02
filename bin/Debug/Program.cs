using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using SPC02;

namespace SPC02.Core
{
    class Program
    {
        DiscordSocketClient _client;
        CommandHandler _handler;

        static void Main(string[] args)
            => new Program().StartAsync().GetAwaiter().GetResult();
        public async Task StartAsync()

        {
            //string name = "User";
            // string botmsg = "SPC02";
            // string template = Utilities.GetFormattedAlert("NAME_&BOTMSG", name,botmsg);
            //string message = String.Format(template, name);
            //Console.WriteLine();
            //return;
            if (Config.bot.token == " " || Config.bot.token == null) return;
            _client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Verbose
            });
            _client.Log += log;
            _client.Ready += Loop.StartLoop;
            _client.Ready += Loop.StartLoopII;
            _client.ReactionAdded += ToReact;
            await _client.LoginAsync(TokenType.Bot, Config.bot.token);
            await _client.StartAsync();
            Global.Client = _client;
            _handler = new CommandHandler();
            await _handler.InitializeAsync(_client);
            await Task.Delay(-1);
        }

        private async Task ToReact(Cacheable<IUserMessage, ulong> cache, ISocketMessageChannel channel, SocketReaction reaction)
        {
            if (reaction.MessageId == Global.SewerI)
            {
                //if (reaction.Message.Value.Channel.Name =="1")
                // {
                //await channel.SendMessageAsync(reaction.User.Value.Username +" you picked this");
                //}
            }

        }

        private async Task log(LogMessage msg)
        {
            Console.WriteLine(msg.Message);

        }
    }
}
