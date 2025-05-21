using UtilsBot.Models;

namespace UtilsBot.Services;

public interface IStorage
{
    Session GetSession(long chatId);
}