using RestaurantManager.Interfaces;

namespace RestaurantManager.Models
{
    public class Drink : Recipe, IDrink
    {
        public Drink(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isCarbonated) : base(name, price, calories, quantityPerServing, MetricUnit.Milliliters, timeToPrepare)
        {
            this.IsCarbonated = isCarbonated;
        }

        public bool IsCarbonated { get; private set; }
    }
}