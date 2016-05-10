using System;
using System.Text;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public abstract class Product : IProduct
    {
        private string name;
        private string brand;

        protected Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name; 
            }
            private set
            {
                //Validator.CheckIfNull(value);
                //Validator.CheckIfStringIsNullOrEmpty(value);

                if (!(value.Length >= 3 && value.Length <= 10))
                {
                    throw new ArgumentException("Product name must be between 3 and 10 symbols long!");
                }

                this.name = value;
            }
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }
            private set
            {
                //Validator.CheckIfNull(value);
                //Validator.CheckIfStringIsNullOrEmpty(value);

                if (!(value.Length >= 2 && value.Length <= 10))
                {
                    throw new ArgumentException("Product brand must be between 2 and 10 symbols long!");
                }

                this.brand = value;
            }
        }
        public decimal Price { get; protected set; }
        public GenderType Gender { get; private set; }

        public virtual string Print()
        {
            var sb = new StringBuilder();

            sb.AppendFormat("- {0} - {1}:", this.Brand, this.Name).AppendLine()
                .AppendFormat("  * Price: ${0}", this.Price).AppendLine()
                .AppendFormat("  * For gender: {0}", this.Gender).AppendLine();

            return sb.ToString();
        }
    }
}