using System.Text;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public class Shampoo : Product, IShampoo
    {
        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage) : base(name, brand, price, gender)
        {
            this.Milliliters = milliliters;
            this.Price = price*this.Milliliters;
            this.Usage = usage;
        }

        public uint Milliliters { get; private set; }
        public UsageType Usage { get; private set; }

        public override string Print()
        {
            var sb = new StringBuilder();

            sb.AppendFormat("  * Quantity: {0} ml", this.Milliliters).AppendLine()
              .AppendFormat("  * Usage: {0}", this.Usage).AppendLine();

            return base.Print() + "  " + sb.ToString().Trim();
        }
    }
}