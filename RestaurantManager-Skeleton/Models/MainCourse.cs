using RestaurantManager.Interfaces;

namespace RestaurantManager.Models
{
    public class MainCourse : Meal, IMainCourse
    {
        public MainCourse(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan, MainCourseType type) : base(name, price, calories, quantityPerServing, timeToPrepare)
        {
            this.IsVegan = isVegan;
            this.Type = type;
        }

        public MainCourseType Type { get; private set; }
    }
}