using RestaurantManager.Interfaces;

namespace RestaurantManager.Models
{
    public class Meal : Recipe, IMeal
    {
        protected Meal(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare) : base(name, price, calories, quantityPerServing, MetricUnit.Grams, timeToPrepare)
        {
        }

        public bool IsVegan { get; set; }

        public void ToggleVegan()
        {
            this.IsVegan = !this.IsVegan;
        }
    }
}