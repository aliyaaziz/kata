using System;
using Xunit;

namespace Supermarket.Tests
{
    public class CheckoutTests
    {
        PricingRules _pricingRules;
        public CheckoutTests()
        {
            _pricingRules = new PricingRules();
            _pricingRules.Add("A", 1, 50);
            _pricingRules.Add("A", 3, 130);
            _pricingRules.Add("B", 1, 30);
            _pricingRules.Add("B", 2, 45);
            _pricingRules.Add("C", 1, 20);
            _pricingRules.Add("D", 1, 15);
        }

        [Fact]
        public void TestCheckoutCostCorrectWithoutMultibuy()
        {
            var checkout = new Checkout(_pricingRules);           
            checkout.Scan("A"); 
            checkout.Scan("B"); 
            checkout.Scan("C"); 
            checkout.Scan("D"); 
            Assert.Equal(115, checkout.GetTotalPrice());
        }

        [Fact]
        public void TestMultbuyPriceCorrectWhenScannedInMixedOrder()
        {
            var checkout = new Checkout(_pricingRules);
            checkout.Scan("A"); 
            checkout.Scan("B"); 
            checkout.Scan("A"); 
            checkout.Scan("A"); 
            checkout.Scan("B"); 
            Assert.Equal(175, checkout.GetTotalPrice());
        }

        [Fact]
        public void TestMultpleSpecialBuysReturnCorrectPrice()
        {
            var checkout = new Checkout(GetTestPricingRulesWithMultipleSpecialBuys());
            checkout.Scan("A"); checkout.Scan("A"); 
            checkout.Scan("A"); checkout.Scan("A"); 
            checkout.Scan("A"); checkout.Scan("A"); 
            checkout.Scan("A"); checkout.Scan("A"); 
            checkout.Scan("A"); checkout.Scan("A"); 
            checkout.Scan("A"); checkout.Scan("A");
            checkout.Scan("A"); checkout.Scan("A");
            checkout.Scan("A");  //15
            Assert.Equal(530, checkout.GetTotalPrice());
        }

        private PricingRules GetTestPricingRulesWithMultipleSpecialBuys()
        {
            var _pricingRulesComplex  = new PricingRules();
            _pricingRulesComplex.Add("A", 1, 50);
            _pricingRulesComplex.Add("A", 3, 130);
            _pricingRulesComplex.Add("A", 10, 300);
            return _pricingRulesComplex;
        }
    }
}
