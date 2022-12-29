using System;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using DCBot;

namespace DCBot
{
    public class Bot
    {
        private DiscordSocketClient _client;
        private CommandService _commands;
        
        public async Task MainAsync()
        {
            var config = new DiscordSocketConfig
            {
                GatewayIntents = GatewayIntents.AllUnprivileged | GatewayIntents.MessageContent
            };

            _client = new DiscordSocketClient(config);
            _commands = new CommandService();

            _client.MessageReceived += MessageReceived;
            _client.Log += Log;
        
            //註冊Bot Cmd指令
            await _commands.AddModulesAsync(typeof(BotCommands).Assembly, null);
            await _client.LoginAsync(TokenType.Bot, BaseValues.DC_Token); //YOUR_BOT_TOKEN
            await _client.StartAsync();
            await Task.Delay(-1);
        }
    

        private async Task MessageReceived(SocketMessage messageParam)
        {
            // Check if the message is a command
            var message = messageParam as SocketUserMessage;
            if (message == null) return;

            // Create a number to track where the prefix ends and the command begins
            int argPos = 0;

            // Determine if the message is a command based on the prefix and make sure no bots trigger command
            if (!message.HasCharPrefix('!', ref argPos) || message.Author.IsBot) return;

            #region Log紀錄
            Console.Write(System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") +" UserName=>" + message.Author.Username);
            Console.WriteLine(" ; Message=>" + message.Content);
            #endregion

            // Create a WebSocket-based command context based on the message
            var context = new SocketCommandContext(_client, message);

            // Execute the command with the command context we just
            // created, along with the service provider for precondition checks.
            await _commands.ExecuteAsync(
                context: context,
                argPos: argPos,
                services: null);
        }

        private async Task Log(LogMessage msg) 
        {
            Console.WriteLine(msg.ToString());
        }
    }
}
