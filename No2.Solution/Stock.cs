using System;

namespace No2.Solution
{
    public class Stock : IObservable
    {
        private StockInfo stocksInfo;

        private event Action<object> MarketUpdatedEvent;

        public Stock()
        {
            stocksInfo = new StockInfo();
        }

        public void Register(IObserver observer) => MarketUpdatedEvent += observer.Update;

        public void Unregister(IObserver observer) => MarketUpdatedEvent -= observer.Update;

        public void Notify()
        {
            MarketUpdatedEvent(stocksInfo);
        }

        public void Market()
        {
            Random rnd = new Random();
            stocksInfo.USD = rnd.Next(20, 40);
            stocksInfo.Euro = rnd.Next(30, 50);
            Notify();
        }
    }
}
