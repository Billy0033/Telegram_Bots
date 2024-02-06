using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

class Program
{
    private static TelegramBotClient botClient;
    private static long targetChatId = -1; // Идентификатор целевого чата

    static async Task Main()
    {
        // Установите токен вашего бота
        botClient = new TelegramBotClient("YOUR_BOT_TOKEN");

        // Укажите идентификатор целевого чата
        targetChatId = -1; // Идентификатор целевого чата

        //botClient.OnMessage += BotOnMessageReceived;
        botClient.OnMessageEdited += BotOnMessageReceived;
        //botClient.StartReceiving();

        Console.WriteLine("Бот запущен. Нажмите Enter для выхода.");
        Console.ReadLine();

        //botClient.StopReceiving();
    }

    private static async void BotOnMessageReceived(object sender, MessageEventArgs e)
    {
        // Пересылайте все сообщения в целевой чат
        await botClient.SendTextMessageAsync(targetChatId, e.Message.Text);
    }
}
