using Discord.Commands;

namespace DCBot
{
    public class BotCommands : ModuleBase<SocketCommandContext>
    {
        [Command("hello")]
        public async Task HelloAsync()
        {
            await ReplyAsync("Hello World");
        }

        [Command("chat")]
        public async Task ChatAIAsync([Remainder] string message)
        {
            GPT3_Request api = new GPT3_Request();
            string result = api.Request(message);
            string returnMsg = $"<@{Context.User.Id}> {result}";
            await ReplyAsync(returnMsg);
        }
    }
}
