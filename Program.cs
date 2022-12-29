using System;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using DCBot;

namespace DCBot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //getEnv();
            getRenderValues();
            new Bot().MainAsync().GetAwaiter().GetResult();
        }

        public static void getRenderValues()
        {
            BaseValues.DC_Token = System.Environment.GetEnvironmentVariable("DISCORD_TOKEN");
            BaseValues.GPT3_Token =  System.Environment.GetEnvironmentVariable("GPT3_Token");
        }

        public static void getEnv()
        {
            string[] lines = System.IO.File.ReadAllLines(".env");
            foreach (string line in lines)
            {
                if (line.StartsWith("DISCORD_TOKEN="))
                {
                    BaseValues.DC_Token = line.Substring("DISCORD_TOKEN=".Length);
                }
                else if (line.StartsWith("GPT3_TOKEN="))
                {
                    BaseValues.GPT3_Token = line.Substring("GPT3_TOKEN=".Length);
                }
            }

        }
    }
}
