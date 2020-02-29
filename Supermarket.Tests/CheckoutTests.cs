using System;
using Xunit;

namespace Supermarket.Tests
{
    public class CheckoutTests
    {
        PricingRules _pricingRules;
        public CheckoutTests()
        {
            var pricingRules = new PricingRules();
            pricingRules.Add("A", 1, 50);
            pricingRules.Add("A", 3, 130);
            pricingRules.Add("B", 1, 30);
            pricingRules.Add("B", 2, 45);
            pricingRules.Add("C", 1, 20);
            pricingRules.Add("D", 1, 15);
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
    }
}
