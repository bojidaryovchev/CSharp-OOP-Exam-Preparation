using System;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public abstract class Furniture : IFurniture
    {
        private string model;
        private decimal price;
        private decimal height;

        protected Furniture(string model, string material, decimal price, decimal height)
        {
            this.Model = model;
            this.Material = material;
            this.Price = price;
            this.Height = height;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new ArgumentException();
                }
                this.model = value;
            }
        }

        public string Material { get; private set; }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                ValidateValue(value);
                this.price = value;
            }
        }

        public decimal Height
        {
            get
            {
                return this.height;
            }
            protected set
            {
                ValidateValue(value);
                this.height = value;
            }
        }

        private static void ValidateValue(decimal value)
        {
            if (value <= 0)
            {
                throw new ArgumentException();
            }
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}", this.GetType().Name,
                this.Model, this.Material, this.Price, this.Height);
        }
    }
}