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
        public static void Main(string[] args) => new Bot().MainAsync().GetAwaiter().GetResult();
    }
}
