using Estates.Interfaces;

namespace Estates.Estates
{
    public abstract class BuildingEstate : Estate, IBuildingEstate
    {
        protected BuildingEstate(EstateType type) : base(type)
        {
        }

        protected BuildingEstate(string name, EstateType type, double area, string location, bool isFurnished, int rooms, bool hasElevator) : base(name, type, area, location, isFurnished)
        {
            this.Rooms = rooms;
            this.HasElevator = hasElevator;
        }        
        
        public int Rooms { get; set; }
        public bool HasElevator { get; set; }

        public override string ToString()
        {
            return base.ToString() + string.Format(", Rooms: {0}, Elevator: {1}", this.Rooms, this.HasElevator ? "Yes" : "No");
        }
    }
}