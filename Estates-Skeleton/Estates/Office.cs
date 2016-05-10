using Estates.Interfaces;

namespace Estates.Estates
{
    public class Office : BuildingEstate, IOffice
    {
        public Office(EstateType type) : base(type)
        {
        }

        public Office(string name, EstateType type, double area, string location, bool isFurnished, int rooms, bool hasElevator) : base(name, type, area, location, isFurnished, rooms, hasElevator)
        {
        }
    }
}