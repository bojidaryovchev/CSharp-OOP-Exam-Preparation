using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public class Category : ICategory
    {
        private string name;
        private readonly IList<IProduct> cosmeticProducts;

        public Category(string name)
        {
            this.Name = name;
            this.cosmeticProducts = new List<IProduct>();
        }

        public string Name
        {
            get
            {
                return this.name; 
            }
            private set
            {
                if (!(value.Length >= 2 && value.Length <= 15))
                {
                    throw new ArgumentException("Category name must be between 2 and 15 symbols long!");
                }

                this.name = value;
            }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            this.cosmeticProducts.Add(cosmetics);
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            if (!this.cosmeticProducts.Contains(cosmetics))
            {
                throw new InvalidOperationException(string.Format("Product {0} does not exist in category {1}!", cosmetics.Name, this.Name));
            }
            
            this.cosmeticProducts.Remove(cosmetics);
        }

        public string Print()
        {
            var sb = new StringBuilder();

            sb.AppendFormat("{0} category - {1} {2} in total", this.Name, this.cosmeticProducts.Count,
                this.cosmeticProducts.Count == 1 ? "product" : "products").AppendLine();

            var sorted = this.cosmeticProducts.OrderBy(p => p.Brand).ThenByDescending(p => p.Price);

            foreach (var product in sorted)
            {
                sb.AppendLine(product.Print());
            }

            return sb.ToString().Trim();
        }
    }
}