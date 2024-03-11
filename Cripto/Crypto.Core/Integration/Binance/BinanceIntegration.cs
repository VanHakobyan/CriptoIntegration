using Binance.Net.Clients;
using Binance.Net.Interfaces;
using CryptoExchange.Net.Objects.Sockets;

namespace Crypto.Core.Integration.Binance;

public class BinanceIntegration: IBinanceIntegration
{

    public void Subscribe()
    {
        var socketClient = new BinanceSocketClient();
        var tickerSubscriptionResult = socketClient.SpotApi.ExchangeData.SubscribeToTickerUpdatesAsync("ETHUSDT", OnMessage).Result;
    }

    private void OnMessage(DataEvent<IBinanceTick> update)
    {
        var lastPrice = update.Data.LastPrice;
        
    }
}