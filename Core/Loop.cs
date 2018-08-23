using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SPC02.Core
{
    internal static class Loop
    {
        private static Timer Looptimerll;
        private static Timer LoopTimer;
        private static SocketTextChannel channel;
        internal static Task StartLoop()
        {
            //channel = Global.Client.GetGuild(427659065741672448).GetTextChannel(428190611560988672);

            LoopTimer = new Timer()
            {
                Interval = 86400000,
                AutoReset = true,
                Enabled = true

            };
            LoopTimer.Elapsed += OnTimer;
            return Task.CompletedTask;
        }
        internal static Task StartLoopII() {
            //channel = Global.Client.GetGuild(427659065741672448).GetTextChannel(427683668765442068);

            Looptimerll = new Timer()
            {
                Interval = 86400000,
                AutoReset = true,
                Enabled =  true
            };
            Looptimerll.Elapsed += Ontimerll;
            return Task.CompletedTask; 
            
        }

        private static async void Ontimerll(object sender, ElapsedEventArgs e)
        {
            Random rand;
            rand = new Random();
            string[] ling;
            ling = new string[]{
                "I am the Winner I am the Chosen one you can't lie that will be your down fall.",
                "I will Break I will Ach, I will Never ever stop this World of Elsword~",
                "Long ago There was a little Me who knew you that I will tell that I and Me that you exist in their world :smile:"

            };
            int ranling = rand.Next(ling.Length);
            string RanIGM = ling[ranling];

            await channel.SendMessageAsync(RanIGM);
        }

        private static async void OnTimer(object sender, ElapsedEventArgs e) {

            Random rand;
            rand = new Random();
            string[] ling;
            ling = new string[]
            {
                ":handshake: Suggestion:Make a New Random Friend",
                ":evergreen_tree: Suggestion: Play at least 1 Event Games",
                ":man_dancing: Suggestion: Join in a Random Sparring Room"

            };
            int ranling = rand.Next(ling.Length);
            string Toling = ling[ranling];
            
                await channel.SendMessageAsync(Toling);
            



        }
    }
}
