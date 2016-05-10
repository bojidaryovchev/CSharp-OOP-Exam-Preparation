using RestaurantManager.Interfaces;

namespace RestaurantManager.Models
{
    public class Dessert : Meal, IDessert
    {
        public Dessert(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan) : base(name, price, calories, quantityPerServing, timeToPrepare)
        {
            this.IsVegan = isVegan;
            this.WithSugar = true;
        }

        public bool WithSugar { get; private set; }

        public void ToggleSugar()
        {
            this.WithSugar = !this.WithSugar;
        }
    }
}