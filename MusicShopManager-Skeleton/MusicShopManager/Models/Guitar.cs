using System;
using MusicShopManager.Interfaces;

namespace MusicShop.Models
{
    public abstract class Guitar : Instrument, IGuitar
    {
        private const int DefaultNumberOfStrings = 6;

        private string bodyWood;
        private string fingerboardWood;

        protected Guitar(string make, string model, decimal price, string color, bool isElectronic, string bodyWood, string fingerboardWood, int numberOfStrings = DefaultNumberOfStrings) : base(make, model, price, color, isElectronic)
        {
            this.BodyWood = bodyWood;
            this.FingerboardWood = fingerboardWood;
            this.NumberOfStrings = numberOfStrings;
        }

        public string BodyWood
        {
            get
            {
                return this.bodyWood;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }

                this.bodyWood = value;
            }
        }

        public string FingerboardWood
        {
            get
            {
                return this.fingerboardWood;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }

                this.fingerboardWood = value;
            }
        }

        public int NumberOfStrings { get; private set; }
    }
}