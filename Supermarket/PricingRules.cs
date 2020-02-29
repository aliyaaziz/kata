using System;
using Supermarket.Interfaces;

namespace Supermarket
{
    public class PricingRules : IPricingRules
    {
        public void Add(string item, int count, int price)
        {
            throw new System.NotImplementedException();
        }

        public int GetPrice(string item, int scanned)
        {
            throw new System.NotImplementedException();
        }
    }
}