namespace Crypto.API.SignalRHub;

public interface IMessageHubClient
{
    Task NewMessage(CancellationToken cancellationToken = default);
}
