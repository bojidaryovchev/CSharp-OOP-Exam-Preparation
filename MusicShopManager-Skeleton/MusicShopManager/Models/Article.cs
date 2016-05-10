using System;
using MusicShopManager.Interfaces;

namespace MusicShop.Models
{
    public abstract class Article : IArticle
    {
        private string make;
        private string model;

        protected Article(string make, string model, decimal price)
        {
            this.Make = make;
            this.Model = model;
            this.Price = price;
        }

        public string Make
        {
            get
            {
                return this.make;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }

                this.make = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }

                this.model = value;
            }
        }
        public decimal Price { get; private set; }
    }
}