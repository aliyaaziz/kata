using System;
using Xunit;

namespace Supermarket.Tests
{
    public class CheckoutTests
    {
        [Fact]
        public void TestCheckoutCostCorrectWithoutMultibuy()
        {
            var checkout = new Checkout();           
            checkout.Scan("A"); 
            checkout.Scan("B"); 
            checkout.Scan("C"); 
            checkout.Scan("D"); 
            Assert.Equal(115, checkout.GetTotalPrice());
        }

        [Fact]
        public void TestMultbuyPriceCorrectWhenScannedInMixedOrder()
        {
            var checkout = new Checkout();
            checkout.Scan("A"); 
            checkout.Scan("B"); 
            checkout.Scan("A"); 
            checkout.Scan("A"); 
            checkout.Scan("B"); 
            Assert.Equal(175, checkout.GetTotalPrice());
        }
    }
}
