using RestaurantManager.Interfaces;

namespace RestaurantManager.Models
{
    public class Salad : Meal, ISalad
    {
        public Salad(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare,
            bool containsPasta) : base(name, price, calories, quantityPerServing, timeToPrepare)
        {
            this.IsVegan = true;
            this.ContainsPasta = containsPasta;
            
        }

        public bool ContainsPasta { get; private set; }
    }
}