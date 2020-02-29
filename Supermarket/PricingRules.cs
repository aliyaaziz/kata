using System;
using System.Collections.Generic;
using Supermarket.Interfaces;

namespace Supermarket
{
    public class PricingRules : IPricingRules
    {
        Dictionary<string, SortedDictionary<int, int>> _rules;
        public PricingRules()
        {
            _rules = new Dictionary<string, SortedDictionary<int, int>>();
        }
        public void Add(string item, int count, int price)
        {
            if(_rules.ContainsKey(item))
            {
                var itemRules = _rules[item];
                itemRules.Add(count, price);
            }
            else{
                _rules.Add(item, new SortedDictionary<int, int>(){{count, price}});
            }
        }

        public int GetPrice(string item, int scanned)
        {
            //TODO implement
            return 0;
        }
    }
}