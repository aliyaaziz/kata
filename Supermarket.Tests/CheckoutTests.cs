using System;
using Xunit;

namespace Supermarket.Tests
{
    public class CheckoutTests
    {
        int UnitPriceOfA = 50;
        int UnitPriceOfB = 30;
        int UnitPriceOfC = 20;
        int UnitPriceOfD = 15;
        int MultiBuyPriceOf3A = 130;
        int MultiBuyPriceOf2B = 45;

        [Fact]
        public void TestSingleUnitPricesAreCorrect()
        {
            var checkout = new Checkout();
            var totalPrice = UnitPriceOfA;
            checkout.Scan("A"); 
            Assert.Equal(totalPrice, checkout.GetTotalPrice());
            totalPrice += UnitPriceOfB;
            checkout.Scan("B"); 
            Assert.Equal(totalPrice, checkout.GetTotalPrice());
            totalPrice += UnitPriceOfC;
            checkout.Scan("C"); 
            Assert.Equal(totalPrice, checkout.GetTotalPrice());
            totalPrice += UnitPriceOfD;
            checkout.Scan("D"); 
            Assert.Equal(totalPrice, checkout.GetTotalPrice());
        }
    }
}
