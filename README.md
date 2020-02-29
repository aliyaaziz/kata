# checkout-kata
In a normal supermarket, things are identified using Stock Keeping Units, or SKUs. In our shop, we’ll use individual letters of the alphabet (A, B, C, and so on). Our goods are priced individually. In addition, some items are multipriced: buy n of them, and they’ll cost you y pounds. For example, item ‘A’ might cost 50 pounds individually, but this week we have a special offer: buy three ‘A’s and they’ll cost you 130. The current pricing and offers are as follows:

| SKU  | Unit Price | Special Price |
| ---- | ---------- | ------------- |
| A    | 50         | 3 for 130     |
| B    | 30         | 2 for 45      |
| C    | 20         |               |
| D    | 15         |               |

Our checkout accepts items in any order, so that if we scan a B, an A, and another B, we’ll recognize the two B’s and price them at 45 (for a total price so far of 95). Because the pricing changes frequently, we need to be able to pass in a set of pricing rules each time we start handling a checkout transaction.

Here's a suggested interface for the checkout...
```cs
interface ICheckout
{
    void Scan(string item);
    int GetTotalPrice();
}
```

# Instructions
Implement a class library that satisfies the problem described above. The solution should be test driven.

We're as interested in the process that you go through to develop the code as the end result, so commit early and often so we can see the steps that you go through to arrive at your solution. We want to see a git repository containing your solution, ideally uploaded to your own github account.

If you've not done a kata before, there are some great reources on the web describing the process.

# Acknowledgements
Adapted from http://codekata.com/kata/kata09-back-to-the-checkout/
