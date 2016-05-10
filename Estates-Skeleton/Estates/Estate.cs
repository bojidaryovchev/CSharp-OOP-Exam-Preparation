using Estates.Interfaces;

namespace Estates.Estates
{
    public abstract class Estate : IEstate
    {
        public string Name { get; set; }
        public EstateType Type { get; set; }
        public double Area { get; set; }
        public string Location { get; set; }
        public bool IsFurnished { get; set; }

        protected Estate(EstateType type) : this(null, type, 0, null)
        {
        }

        protected Estate(string name, EstateType type, double area, string location, bool isFurnished = false)
        {
            this.Name = name;
            this.Type = type;
            this.Area = area;
            this.Location = location;
            this.IsFurnished = isFurnished;
        }

        public override string ToString()
        {
            return string.Format("{0}: Name = {1}, Area = {2}, Location = {3}, Furnitured = {4}", this.GetType().Name, this.Name, this.Area, this.Location, (this.IsFurnished ? "Yes" : "No"));
        }
    }
}