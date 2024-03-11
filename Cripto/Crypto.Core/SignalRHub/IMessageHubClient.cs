namespace Crypto.Core.SignalRHub;

public interface IMessageHubClient
{
    Task SendOffersToUser(List<string> message);
}
