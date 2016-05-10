using RestaurantManager.Models;

namespace RestaurantManager.Engine.Factories
{
    using Interfaces.Engine;

    public class RestaurantFactory : IRestaurantFactory
    {
        public Interfaces.IRestaurant CreateRestaurant(string name, string location)
        {
            return new Restaurant(name, location);
        }
    }
}