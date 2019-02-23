using System.Collections.Generic;
using System.Linq;

namespace SampleProject.Model
{
    public class Info
    {
        public IEnumerable<PriceInfo> Bids { get; set; }
        public IEnumerable<PriceInfo> Asks { get; set; }

        public Info()
        {
        }

        public Info(IEnumerable<(decimal, decimal)> bids, IEnumerable<(decimal, decimal)> asks)
        {
            Bids = bids.Select(bid => new PriceInfo { Price = bid.Item1, Volume = bid.Item2 }).ToArray();
            Asks = asks.Select(ask => new PriceInfo { Price = ask.Item1, Volume = ask.Item2 }).ToArray();
        }
    }

    public class PriceInfo
    {
        public decimal Price { get; set; }
        public decimal Volume { get; set; }
        public decimal Total => Price * Volume;
    }
}

