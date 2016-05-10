using System.Collections.Generic;
using System.Linq;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly IList<IProduct> basket;

        public ShoppingCart()
        {
            this.basket = new List<IProduct>();
        }

        public void AddProduct(IProduct product)
        {
            this.basket.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            this.basket.Remove(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            return this.basket.Contains(product);
        }

        public decimal TotalPrice()
        {
            return this.basket.Sum(p => p.Price);
        }
    }
}