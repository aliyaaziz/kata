using System;
using System.Collections;
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
                var rulesComparer = new RulesComparer(); // we want to order the items by count descending, e.g. cost for 3 items will be before cost for 1 item.
                _rules.Add(item, new SortedDictionary<int, int>(rulesComparer){{count, price}});
            }
        }

        public int GetPrice(string item, int scanned)
        {
            int currentPrice = 0;
            int itemsLeftToPrice = scanned;

            if(_rules.ContainsKey(item))
            {
                foreach(var rule in _rules[item])
                {
                    var timesToApply = itemsLeftToPrice / rule.Key;
                    currentPrice += timesToApply * rule.Value;
                    itemsLeftToPrice -= timesToApply * rule.Key;
                }
            }
            return currentPrice;
        }

        private class RulesComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                if(x < y) return 1;
                else return -1;
            }
        }
    }
}