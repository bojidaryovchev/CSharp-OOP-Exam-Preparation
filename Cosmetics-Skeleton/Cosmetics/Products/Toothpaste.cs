using System.Collections.Generic;
using System.Text;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public class Toothpaste : Product, IToothpaste
    {
        public Toothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients) : base(name, brand, price, gender)
        {
            ValidateIngredients(ingredients);
            this.Ingredients = string.Join(", ", ingredients);
        }

        public string Ingredients { get; private set; }

        public override string Print()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("  * Ingredients: {0}", this.Ingredients).AppendLine();
            return base.Print() + "  " + sb.ToString().Trim();
        }

        private static void ValidateIngredients(IList<string> ingredients)
        {
            foreach (var ingredient in ingredients)
            {
                Validator.CheckIfStringLengthIsValid(ingredient, 12, 4);
            }
        }
    }
}