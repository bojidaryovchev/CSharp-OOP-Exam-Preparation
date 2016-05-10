using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public class ConvertibleChair : Chair, IConvertibleChair
    {
        private readonly decimal initialHeight;

        public ConvertibleChair(string model, string material, decimal price, decimal height, int numberOfLegs) : base(model, material, price, height, numberOfLegs)
        {
            this.initialHeight = height;
        }

        public bool IsConverted { get; private set; }

        public void Convert()
        {
            if (!IsConverted)
            {
                this.Height = 0.10m;
            }
            else if (IsConverted)
            {
                this.Height = this.initialHeight;
            }
            this.IsConverted = !this.IsConverted;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(", State: {0}", this.IsConverted ? "Converted" : "Normal");
        }
    }
}