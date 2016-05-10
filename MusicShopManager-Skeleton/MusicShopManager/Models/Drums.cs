using System;
using MusicShopManager.Interfaces;

namespace MusicShop.Models
{
    public class Drums : Instrument, IDrums
    {
        private const bool DefaultDrumsAreElectronic = false;

        private int width;
        private int height;

        public Drums(string make, string model, decimal price, string color, int width, int height) : base(make, model, price, color, DefaultDrumsAreElectronic)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                ValidateSize(value);
                this.width = value;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                ValidateSize(value);
                this.height = value;
            }
        }

        private static void ValidateSize(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("The value must be positive.");
            }
        }
    }
}