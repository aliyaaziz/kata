using System;
using Xunit;

namespace Supermarket.Tests
{
    public class PricingRulesTests
    {
        int UnitCostOfItemA = 50;
        int MultibuyCostOfItem3A = 130;
        int UnitCostOfItemB = 30;
        int MultibuyCostOfItem2B = 45;
        int UnitCostOfItemC = 20;
        int UnitCostOfItemD = 15;

        [Fact]
        public void TestPricingRulesReturnsCorrectCost()
        {
            var pricingRules = new PricingRules();
            pricingRules.Add("A", 1, 50);
            pricingRules.Add("A", 3, 130);
            pricingRules.Add("B", 1, 30);
            pricingRules.Add("B", 2, 45);
            pricingRules.Add("C", 1, 20);
            pricingRules.Add("D", 1, 15);

            // single item
            Assert.Equal(UnitCostOfItemA, pricingRules.GetPrice("A", 1));
            Assert.Equal(UnitCostOfItemB, pricingRules.GetPrice("B", 1));
            Assert.Equal(UnitCostOfItemC, pricingRules.GetPrice("C", 1));
            Assert.Equal(UnitCostOfItemD, pricingRules.GetPrice("D", 1));

            //multibuy
            Assert.Equal(MultibuyCostOfItem3A, pricingRules.GetPrice("A", 3));
            Assert.Equal(MultibuyCostOfItem2B, pricingRules.GetPrice("B", 2));
        }

        [Fact]
        public void TestPricingRulesApplysSpecialPriceCorrectly()
        {
            var pricingRules = new PricingRules();
            pricingRules.Add("A", 1, 50);
            pricingRules.Add("A", 3, 130);
            pricingRules.Add("B", 1, 30);
            pricingRules.Add("B", 2, 45);
            pricingRules.Add("C", 1, 20);
            pricingRules.Add("D", 1, 15);

            // 10 item A's, 9 will have offer applied
            var expectedPrice = MultibuyCostOfItem3A * 3 + UnitCostOfItemA;
            Assert.Equal(expectedPrice, pricingRules.GetPrice("A", 10));

            // 5 item B's, 4 will have offer applied
            var expectedPrice2 = MultibuyCostOfItem2B * 2 + UnitCostOfItemB;
            Assert.Equal(expectedPrice2, pricingRules.GetPrice("B", 5));
        }
    }
}
