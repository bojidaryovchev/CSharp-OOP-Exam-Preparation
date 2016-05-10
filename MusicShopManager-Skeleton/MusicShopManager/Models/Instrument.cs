using System;
using MusicShopManager.Interfaces;

namespace MusicShop.Models
{
    public abstract class Instrument : Article, IInstrument
    {
        private string color;

        protected Instrument(string make, string model, decimal price, string color, bool isElectronic) : base(make, model, price)
        {
            this.Color = color;
            this.IsElectronic = isElectronic;
        }

        public string Color
        {
            get
            {
                return this.color;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }

                this.color = value;
            }
        }

        public bool IsElectronic { get; private set; }
    }
}