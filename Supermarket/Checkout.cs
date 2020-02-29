using System;
using System.Collections.Generic;
using Supermarket.Interfaces;

namespace Supermarket
{
    public class Checkout : ICheckout
    {
        PricingRules _pricingRules;
        List<string> _scannedItems;

        public Checkout(PricingRules pricingRules)
        {
            _pricingRules = pricingRules;
            _scannedItems = new List<string>();
        }
        public int GetTotalPrice()
        {
            throw new NotImplementedException();
        }

        public void Scan(string item)
        {
            throw new NotImplementedException();
        }
    }
}
