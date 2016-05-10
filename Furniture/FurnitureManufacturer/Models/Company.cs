using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    class Company : ICompany
    {
        private string name;
        private string registrationNumber;

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            this.Furnitures = new List<IFurniture>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException();
                }

                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }
            private set
            {
                int temporary;
                if (!(value.Length == 10 && value.All(c => int.TryParse(c.ToString(), out temporary))))
                {
                    throw new ArgumentException();
                }

                this.registrationNumber = value;
            }
        }

        public ICollection<IFurniture> Furnitures { get; private set; }

        public void Add(IFurniture furniture)
        {
            this.Furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            this.Furnitures.Remove(furniture);
        }

        public IFurniture Find(string model)
        {
            return this.Furnitures.FirstOrDefault(e => string.Equals(e.Model, model, StringComparison.CurrentCultureIgnoreCase));
        }

        public string Catalog()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("{0} - {1} - {2} {3}", this.Name, this.RegistrationNumber,
                this.Furnitures.Count > 0 ? this.Furnitures.Count.ToString() : "no",
                this.Furnitures.Count == 1 ? "furniture" : "furnitures").AppendLine();

            if (this.Furnitures.Any())
            {
                var sortedFurnitures = this.Furnitures.OrderBy(f => f.Price).ThenBy(f => f.Model);
                foreach (var furniture in sortedFurnitures)
                {
                    if (furniture is Table)
                    {
                        var table = furniture as Table;
                        sb.AppendLine(table.ToString());
                    }
                    else if (furniture is Chair)
                    {
                        if (furniture is ConvertibleChair)
                        {
                            var convertibleChair = furniture as ConvertibleChair;
                            sb.AppendLine(convertibleChair.ToString());
                            continue;
                        }
                        var chair = furniture as Chair;
                        sb.AppendLine(chair.ToString());
                    }
                }
            }
            return sb.ToString().Trim();
        }
    }
}