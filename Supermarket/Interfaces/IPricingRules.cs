namespace Supermarket.Interfaces
{
    public interface IPricingRules
    {
        void Add(string item, int count, int price);
        int GetPrice(string item, int scanned);
    }
}