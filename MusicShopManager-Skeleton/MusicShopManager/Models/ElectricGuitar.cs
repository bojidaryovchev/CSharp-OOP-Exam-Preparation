using System;
using MusicShopManager.Interfaces;

namespace MusicShop.Models
{
    public class ElectricGuitar : Guitar, IElectricGuitar
    {
        private const bool DefaultElectricGuitarIsElectronic = true;

        private int numberOfAdapters;
        private int numberOfFrets;

        public ElectricGuitar(string make, string model, decimal price, string color, string bodyWood,
            string fingerboardWood, int numberOfAdapters, int numberOfFrets)
            : base(make, model, price, color, DefaultElectricGuitarIsElectronic, bodyWood, fingerboardWood)
        {
            this.NumberOfAdapters = numberOfAdapters;
            this.NumberOfFrets = numberOfFrets;
        }

        public int NumberOfAdapters
        {
            get
            {
                return this.numberOfAdapters;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The number of adapters is required.");
                }

                this.numberOfAdapters = value;
            }
        }

        public int NumberOfFrets
        {
            get
            {
                return this.numberOfFrets;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The number of frets is required.");
                }

                this.numberOfFrets = value;
            }
        }
    }
}