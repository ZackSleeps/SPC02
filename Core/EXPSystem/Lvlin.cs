using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SPC02.Core.EXPSystem
{
    internal static class Lvlin
    {
        internal static async void UserMessage(SocketGuildUser user, SocketTextChannel channel)
        {
           var Users = UAccounts.UAccounts.GetAccount(user);
            uint oldlevel = Users.lvlnumber;
            Users.EXP += 3;
            UAccounts.UAccounts.SaveAccounts();
            uint newLevel = Users.lvlnumber;

            if (oldlevel != newLevel)
            {
                //user lvl up
                var embed = new EmbedBuilder();
                embed.WithColor(128, 255, 255);
                embed.WithTitle("Core Grow :up:");
                embed.WithDescription(user.Username + " your Core gained new level Congratz");
                embed.AddInlineField("Core Lvl",newLevel);
                embed.AddInlineField("EXP", Users.EXP);
                embed.WithThumbnailUrl(user.GetAvatarUrl());
                // Add 30 Stardust when lvling up

                await channel.SendMessageAsync("", embed: embed);

            }

        }

    }
}
