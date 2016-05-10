using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantManager.Interfaces;

namespace RestaurantManager.Models
{
    public class Restaurant : IRestaurant
    {
        private string name;
        private string location;

        public Restaurant(string name, string location)
        {
            this.Name = name;
            this.Location = location;
            this.Recipes = new List<IRecipe>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The name is required.");
                }

                this.name = value;
            }
        }

        public string Location
        {
            get
            {
                return this.location;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The location is required.");
                }

                this.location = value;
            }
        }

        public IList<IRecipe> Recipes { get; private set; }

        public void AddRecipe(IRecipe recipe)
        {
            this.Recipes.Add(recipe);
        }

        public void RemoveRecipe(IRecipe recipe)
        {
            if (!this.Recipes.Contains(recipe))
            {
                throw new InvalidOperationException();
            }

            this.Recipes.Remove(recipe);
        }

        public string PrintMenu()
        {
            var menuBuilder = new StringBuilder();
            menuBuilder.AppendFormat("***** {0} - {1} *****", this.Name, this.Location).AppendLine();
            if (this.Recipes.Any())
            {
                if (this.Recipes.Any(r => r is Drink))
                {
                    menuBuilder.AppendLine("~~~~~ DRINKS ~~~~~");
                    var drinkRecipes = this.Recipes.Where(r => r is Drink).Cast<Drink>().OrderBy(r => r.GetType());
                    foreach (var drink in drinkRecipes)
                    {
                        menuBuilder.AppendFormat("==  {0} == ${1:F2}", drink.Name, drink.Price).AppendLine()
                            .AppendFormat("Per serving: {0} ml, {1} kcal", drink.QuantityPerServing,
                                drink.Calories).AppendLine()
                            .AppendFormat("Ready in {0} minutes", drink.TimeToPrepare).AppendLine()
                            .AppendFormat("Carbonated: {0}", drink.IsCarbonated ? "yes" : "no").AppendLine();
                    }
                }
                if (this.Recipes.Any(r => r is Salad))
                {
                    menuBuilder.AppendLine("~~~~~ SALADS ~~~~~");
                    var saladRecipes = this.Recipes.Where(r => r is Salad).Cast<Salad>().OrderBy(r => r.GetType());
                    foreach (var salad in saladRecipes)
                    {
                        menuBuilder.AppendFormat("[VEGAN] ==  {0} == ${1:F2}", salad.Name, salad.Price).AppendLine()
                            .AppendFormat("Per serving: {0} g, {1} kcal", salad.QuantityPerServing, salad.Calories)
                            .AppendLine()
                            .AppendFormat("Ready in {0} minutes", salad.TimeToPrepare).AppendLine()
                            .AppendFormat("Contains pasta: {0}", salad.ContainsPasta ? "yes" : "no").AppendLine();
                    }
                }
                if (this.Recipes.Any(r => r is MainCourse))
                {
                    menuBuilder.AppendLine("~~~~~ MAIN COURSES ~~~~~");
                    var mainCourseRecipes =
                        this.Recipes.Where(r => r is MainCourse).Cast<MainCourse>().OrderBy(r => r.GetType());
                    foreach (var mainCourse in mainCourseRecipes)
                    {
                        menuBuilder.AppendFormat("{0}==  {1} == ${2:F2}", mainCourse.IsVegan ? "[VEGAN] " : "",mainCourse.Name, mainCourse.Price)
                            .AppendLine()
                            .AppendFormat("Per serving: {0} g, {1} kcal", mainCourse.QuantityPerServing,
                                mainCourse.Calories).AppendLine()
                            .AppendFormat("Ready in {0} minutes", mainCourse.TimeToPrepare).AppendLine()
                            .AppendFormat("Type: {0}", mainCourse.Type).AppendLine();
                    }
                }
                if (this.Recipes.Any(r => r is Dessert))
                {
                    menuBuilder.AppendLine("~~~~~ DESSERTS ~~~~~");
                    var dessertRecipes = this.Recipes.Where(r => r is Dessert).Cast<Dessert>().OrderBy(r => r.GetType());
                    foreach (var dessert in dessertRecipes)
                    {
                        menuBuilder.AppendFormat("{0}{1}==  {2} == ${3:F2}", !dessert.WithSugar ? "[NO SUGAR] " : "",
                            dessert.IsVegan ? "[VEGAN] " : "", dessert.Name, dessert.Price).AppendLine()
                            .AppendFormat("Per serving: {0} g, {1} kcal", dessert.QuantityPerServing, dessert.Calories)
                            .AppendLine()
                            .AppendFormat("Ready in {0} minutes", dessert.TimeToPrepare).AppendLine();
                    }
                }
            }
            else
            {
                menuBuilder.AppendLine("No recipes... yet");
            }
            
            return menuBuilder.ToString().Trim();
        }
    }
}