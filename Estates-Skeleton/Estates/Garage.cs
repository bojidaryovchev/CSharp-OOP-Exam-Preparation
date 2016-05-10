using System;
using Estates.Interfaces;

namespace Estates.Estates
{
    public class Garage : Estate, IGarage
    {
        public Garage(EstateType type) : base(type)
        {
        }

        public Garage(string name, EstateType type, double area, string location, bool isFurnished, int width, int height) : base(name, type, area, location, isFurnished)
        {            
            this.Width = width;
            this.Height = height;
        }        
        
        public int Width { get; set; }
        public int Height { get; set; }

        public override string ToString()
        {
            return base.ToString() + String.Format(", Width: {0}, Height: {1}", this.Width, this.Height);
        }
    }
}