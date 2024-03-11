namespace Crypto.Core;

internal class NotificationService
{
    private readonly IHubContext<messageh, IInAppHub> _inAppContext;
    private readonly IDistributedCache _cacheProvider;
    public NotificationService(IHubContext<InAppHub, IInAppHub> hubContext, IDistributedCache cacheProvider)
    {
        _inAppContext = hubContext;
        _cacheProvider = cacheProvider;
    }

    public async Task<bool> NewMessageAppeared(int userId, CancellationToken cancellationToken = default)
    {
        var cachedConnection = await _cacheProvider.GetStringAsync(userId.ToString(), token: cancellationToken);
        if (cachedConnection is null)
        {
            return false;
        }
        await _inAppContext.Clients.Client(cachedConnection).NewMessage(cancellationToken);
        return true;
    }
}