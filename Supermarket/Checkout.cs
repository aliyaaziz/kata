using System;
using System.Collections.Generic;
using Supermarket.Interfaces;

namespace Supermarket
{
    public class Checkout : ICheckout
    {
        PricingRules _rules;
        List<string> _scannedItems;

        public Checkout(PricingRules pricingRules)
        {
            _rules = pricingRules;
            _scannedItems = new List<string>();
        }
        public int GetTotalPrice()
        {
            var itemCounts = new Dictionary<string, int>();

            // create dictionary of each item type and total scanned
            foreach(var item in _scannedItems)
            {
                if(itemCounts.ContainsKey(item))
                {
                    var currentCountForItem = itemCounts[item];
                    itemCounts[item] = currentCountForItem+1;
                }
                else{
                    itemCounts.Add(item, 1);
                }
            }

            var totalPrice = 0;
            // go through item counts and fetch the cost from pricing rules
            foreach(var itemCount in itemCounts)
            {
                var priceToAdd = _rules.GetPrice(itemCount.Key, itemCount.Value);
                totalPrice += priceToAdd;
            }
            return totalPrice;
        }

        public void Scan(string item)
        {
            _scannedItems.Add(item);
        }
    }
}
