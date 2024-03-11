using Binance.Net.Clients;
using Binance.Net.Interfaces;
using Crypto.API.SignalRHub;
using CryptoExchange.Net.Objects.Sockets;
using Microsoft.AspNetCore.SignalR;

namespace Crypto.API.Integration.Binance;

public class BinanceIntegration : IBinanceIntegration
{
    private readonly IHubContext<MessageHub, IMessageHubClient> _hub;

    public BinanceIntegration(IHubContext<MessageHub, IMessageHubClient> hub)
    {
        _hub = hub;
    }

    public void Subscribe()
    {
        var socketClient = new BinanceSocketClient();
        var tickerSubscriptionResult = socketClient.SpotApi.ExchangeData.SubscribeToTickerUpdatesAsync("ETHUSDT", OnMessage).Result;
    }

    private void OnMessage(DataEvent<IBinanceTick> update)
    {
        var lastPrice = update.Data.LastPrice;
        _hub.Clients.All.NewMessage();
    }
}