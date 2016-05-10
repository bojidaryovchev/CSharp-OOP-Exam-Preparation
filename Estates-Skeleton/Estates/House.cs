using Estates.Interfaces;

namespace Estates.Estates
{
    public class House : Estate, IHouse
    {
        public House(EstateType type) : base(type)
        {
        }

        public House(string name, EstateType type, double area, string location, bool isFurnished, int floors) : base(name, type, area, location, isFurnished)
        {
            this.Floors = floors;
        }
        
        public int Floors { get; set; }

        public override string ToString()
        {
            return base.ToString() + ", Floors: " + this.Floors;
        }
    }
}