using System;
using System.Collections.Generic;
using MusicShopManager.Interfaces;
using MusicShopManager.Models;

namespace MusicShop.Models
{
    public class AcousticGuitar : Guitar, IAcousticGuitar
    {
        private const bool DefaultAcousticGuitarIsElectronic = false;

        private StringMaterial material;

        private readonly IList<StringMaterial> AllowedMaterials = new List<StringMaterial>
        {
            StringMaterial.Brass,
            StringMaterial.Bronze,
            StringMaterial.Nylon,
            StringMaterial.Steel
        };

        public AcousticGuitar(string make, string model, decimal price, string color, string bodyWood,
            string fingerboardWood, bool caseIncluded, StringMaterial stringMaterial)
            : base(make, model, price, color, DefaultAcousticGuitarIsElectronic, bodyWood, fingerboardWood)
        {
            this.CaseIncluded = caseIncluded;
            this.StringMaterial = stringMaterial;
        }

        public bool CaseIncluded { get; private set; }

        public StringMaterial StringMaterial
        {
            get
            {
                return this.material;
            }
            private set
            {
                if (!this.AllowedMaterials.Contains(value))
                {
                    throw new ArgumentException("The string material is required.");
                }

                this.material = value;
            }
        }
    }
}