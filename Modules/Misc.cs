using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using SPC02.Core;
using System.Net;
using Newtonsoft.Json;
using Discord.Rest;
using SPC02.Core.UAccounts;

namespace SPC02.Modules
{
    public class Misc : ModuleBase<SocketCommandContext>
    {
        //[Command("")]
       // public async Task any([Remainder]string arg = "")
       // {
            //await Context.Channel.SendMessageAsync("Type Message");
        //}

        [Command("spc")]
        public async Task score([Remainder]string arg ="")
        {

            await Context.Channel.SendMessageAsync("I am ▐▐▐▐▐, I'll be your partner at crime if needed :smile:");
        }

        [Command("say")]
        public async Task Echo([Remainder] string message)
        {
            var embed = new EmbedBuilder();
            //embed.WithTitle(Context.User.Username +" says");
            embed.WithDescription(message);
            embed.WithColor(new Color(0, 255, 0));

          await  Context.Channel.SendMessageAsync("",embed:embed);
            DataStorage.AddPairToStorage(Context.User + DateTime.Now.ToLongTimeString(), "");
        }
        [Command("fate")]
        public async Task pick([Remainder] string message)
        
        {
            string[] options = message.Split(new char[] { 'r'}, StringSplitOptions.RemoveEmptyEntries);

            Random o = new Random();

            string seletion = options[o.Next(0, options.Length)];


            var embed = new EmbedBuilder();
            embed.WithTitle("This would be better for"+ Context.User.Username);
            embed.WithDescription(seletion);
            embed.WithColor(new Color(213, 38, 247));
            //embed.WithThumbnailUrl("https://[Put Url].com");
            Context.User.GetAvatarUrl();

            await Context.Channel.SendMessageAsync("", false, embed);
            //DataStorage.AddPairToStorage(Context.User + DateTime.Now.ToLongTimeString(), "");
        }
        [Command("code "+"Ham")]
        //[RequireUserPermission(GuildPermission.Administrator)]
        public async Task getlin([Remainder]string arg = "")
        {
            if (!Selectedrole((SocketGuildUser)Context.User))
            {
                await Context.Channel.SendMessageAsync(":x: You don't have Permisson do to that" + Context.User.Username + "  >(O w O;)<");
                return;
            }
            var dmchannel = await Context.User.GetOrCreateDMChannelAsync();
            await dmchannel.SendMessageAsync(Utilities.Getsave ("MSGIN"));
            DataStorage.AddPairToStorage(Context.User + DateTime.Now.ToLongTimeString(),"");
        }
        private bool Selectedrole(SocketGuildUser user)
        {
            string targetRoleName = "Core";
            var result = from r in user.Guild.Roles
                         where r.Name == targetRoleName
                         select r.Id;
            ulong roleID = result.FirstOrDefault();
            if (roleID == 0) return false;
            var targetRole = user.Guild.GetRole(roleID);
            return user.Roles.Contains(targetRole);
        }
        [Command("config "+"data")]
        public async Task GetData()
        {
            await Context.Channel.SendMessageAsync(":gear: Data has " + DataStorage.GetPairCount() + " Saved");
            //DataStorage.AddPairToStorage("Name", "Shh it's here it is Hai~");
        }
              
            [Command("stat")]
        public async Task status([Remainder]string arg = "")
        {
            SocketUser target = null;
            var mentionUser = Context.Message.MentionedUsers.FirstOrDefault();
            target = mentionUser ?? Context.User;
            var account = UAccounts.GetAccount(target);
            var embed = new EmbedBuilder();
            embed.WithColor(new Color(51, 221, 255));
            embed.WithThumbnailUrl(Context.User.GetAvatarUrl());
            embed.AddInlineField("Name",Context.User.Username);
            embed.AddInlineField("Current Corelvl", account.lvlnumber);
            embed.AddInlineField("Current EXP", account.EXP);
            embed.AddInlineField("Stardust", account.points);
            //embed.WithTitle($":book:   {target.Username}'s  Current Status : \n {account.EXP} EXP \n {account.points} StarDust");



            await Context.Channel.SendMessageAsync("", false, embed);
            DataStorage.AddPairToStorage(Context.User + DateTime.Now.ToLongTimeString(), "");
        }
        [Command("date "+"guy")]
         public async Task guy()
         {
            string json = "Found no Match";
            using(WebClient cleint = new WebClient())
            {
                json = cleint.DownloadString("https://randomuser.me/api/?gender=male&nat=KR");
            }
            var dataO = JsonConvert.DeserializeObject<dynamic>(json);
            string Gender = dataO.results[0].gender.ToString();
            string Name = dataO.results[0].name.first.ToString();
            string LastName = dataO.results[0].name.last.ToString();
            string Country = dataO.results[0].nat.ToString();
            string CharURL = dataO.results[0].picture.large.ToString();

            var embed = new EmbedBuilder();
            embed.WithThumbnailUrl(CharURL);
            embed.WithTitle($"Here is a Lucky match for you {Context.User.Username}  :heart:(`> w O)");
            embed.AddInlineField("Gender", Gender);
            embed.AddInlineField("Country", Country);
            embed.AddInlineField("Name", Name);
            embed.AddInlineField("LastName", LastName);
            embed.WithColor(new Color(0, 51, 204));


            await Context.Channel.SendMessageAsync("", embed:embed);
        }
        [Command("date " + "girl")]
        public async Task girl()
        {
            string json = "Found no Match";
            using (WebClient cleint = new WebClient())
            {
                json = cleint.DownloadString("https://randomuser.me/api/?gender=female&nat=KR");
            }
            var dataO = JsonConvert.DeserializeObject<dynamic>(json);
            string Gender = dataO.results[0].gender.ToString();
            string Name = dataO.results[0].name.first.ToString();
            string LastName = dataO.results[0].name.last.ToString();
            string Country = dataO.results[0].nat.ToString();
            string CharURL = dataO.results[0].picture.large.ToString();

            var embed = new EmbedBuilder();
            embed.WithThumbnailUrl(CharURL);
            embed.WithTitle($"Here is a Lucky match for you {Context.User.Username}  :heart:(`> w O)");
            embed.AddInlineField("Gender", Gender);
            embed.AddInlineField("Country", Country);
            embed.AddInlineField("Name", Name);
            embed.AddInlineField("LastName", LastName);
            embed.WithColor(new Color(255, 51, 153));


            await Context.Channel.SendMessageAsync("", embed: embed);
        }
        [Command("etable")]
         public async Task lvl(uint EXP)
         {
            uint level = (uint)Math.Sqrt(EXP / 90);
            await Context.Channel.SendMessageAsync("Required " + level);
        }
        [Command("help")]
         public async Task any([Remainder]string arg = "")
         {
            var embed = new EmbedBuilder();
            embed.WithColor(new Color(51, 221, 255));
            embed.WithTitle("Help has been Requested by " + Context.User.Username);
            embed.WithDescription("Guide \n To view Status :stat \n To make a choice of a matter:fate Red r Blue \n To match making:date guy (if your looking for guys) \n or :date girl (if your looking for girls) \n ================= \n Core Games Coming soon  ");

            await Context.Channel.SendMessageAsync("", embed:embed);
        }

        //[Command("core "+ "Sewer")]
        // public async Task firstgame([Remainder]string arg = "")
        //{
        // RestUserMessage msg = await Context.Channel.SendMessageAsync(Context.User.Username + " Started the game. press-1 to continue");
        //Global.SewerI = msg.Id;
        //}
    }

}

