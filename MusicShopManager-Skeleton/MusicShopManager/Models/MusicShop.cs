using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MusicShopManager.Interfaces;

namespace MusicShop.Models
{
    public class MusicShop : IMusicShop
    {
        private string name;

        public MusicShop(string name)
        {
            this.Name = name;
            this.Articles = new List<IArticle>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }

                this.name = value;
            }
        }

        public IList<IArticle> Articles { get; private set; }

        public void AddArticle(IArticle article)
        {
            this.Articles.Add(article);
        }

        public void RemoveArticle(IArticle article)
        {
            if (!this.Articles.Contains(article))
            {
                throw new InvalidOperationException("No such article.");
            }

            this.Articles.Remove(article);
        }

        public string ListArticles()
        { 
            var sb = new StringBuilder();
            sb.AppendFormat("===== {0} =====", this.Name).AppendLine();

            if (!this.Articles.Any())
            {
                sb.AppendLine("The shop is empty. Come back soon.");
                return sb.ToString();
            }

            if (this.Articles.Any(e => e is Microphone))
            {
                sb.AppendLine("----- Microphones -----");
                var microphones = this.Articles.Where(e => e is Microphone).Cast<Microphone>().OrderBy(m => m.Make).ThenBy(m => m.Model);

                foreach (var microphone in microphones)
                {
                    sb.AppendFormat("= {0} {1} =", microphone.Make, microphone.Model).AppendLine()
                        .AppendFormat("Price: ${0:F2}", microphone.Price).AppendLine()
                        .AppendFormat("Cable: {0}", microphone.HasCable ? "yes" : "no").AppendLine();
                }
            }
            if (this.Articles.Any(e => e is Drums))
            {
                sb.AppendLine("----- Drums -----");
                var drums = this.Articles.Where(e => e is Drums).Cast<Drums>().OrderBy(d => d.Make).ThenBy(d => d.Model);

                foreach (var drum in drums)
                {
                    sb.AppendFormat("= {0} {1} =", drum.Make, drum.Model).AppendLine()
                        .AppendFormat("Price: ${0:F2}", drum.Price).AppendLine()
                        .AppendFormat("Color: {0}", drum.Color).AppendLine()
                        .AppendFormat("Electronic: {0}", drum.IsElectronic ? "yes" : "no").AppendLine()
                        .AppendFormat("Size: {0}cm x {1}cm", drum.Width, drum.Height).AppendLine();
                }
            }
            if (this.Articles.Any(e => e is ElectricGuitar))
            {
                sb.AppendLine("----- Electric guitars -----");
                var electricGuitars = this.Articles.Where(e => e is ElectricGuitar)
                    .Cast<ElectricGuitar>()
                    .OrderBy(g => g.Make).ThenBy(g => g.Model);

                foreach (var electricGuitar in electricGuitars)
                {
                    sb.AppendFormat("= {0} {1} =", electricGuitar.Make, electricGuitar.Model).AppendLine()
                        .AppendFormat("Price: ${0:F2}", electricGuitar.Price).AppendLine()
                        .AppendFormat("Color: {0}", electricGuitar.Color).AppendLine()
                        .AppendFormat("Electronic: {0}", electricGuitar.IsElectronic ? "yes" : "no").AppendLine()
                        .AppendFormat("Strings: {0}", electricGuitar.NumberOfStrings).AppendLine()
                        .AppendFormat("Body wood: {0}", electricGuitar.BodyWood).AppendLine()
                        .AppendFormat("Fingerboard wood: {0}", electricGuitar.FingerboardWood).AppendLine()
                        .AppendFormat("Adapters: {0}", electricGuitar.NumberOfAdapters).AppendLine()
                        .AppendFormat("Frets: {0}", electricGuitar.NumberOfFrets).AppendLine();
                }
            }
            if (this.Articles.Any(e => e is AcousticGuitar))
            {
                sb.AppendLine("----- Acoustic guitars -----");
                var acousticGuitars = this.Articles.Where(e => e is AcousticGuitar)
                    .Cast<AcousticGuitar>()
                    .OrderBy(g => g.Make).ThenBy(g => g.Model);

                foreach (var acousticGuitar in acousticGuitars)
                {
                    sb.AppendFormat("= {0} {1} =", acousticGuitar.Make, acousticGuitar.Model).AppendLine()
                        .AppendFormat("Price: ${0:F2}", acousticGuitar.Price).AppendLine()
                        .AppendFormat("Color: {0}", acousticGuitar.Color).AppendLine()
                        .AppendFormat("Electronic: {0}", acousticGuitar.IsElectronic ? "yes" : "no").AppendLine()
                        .AppendFormat("Strings: {0}", acousticGuitar.NumberOfStrings).AppendLine()
                        .AppendFormat("Body wood: {0}", acousticGuitar.BodyWood).AppendLine()
                        .AppendFormat("Fingerboard wood: {0}", acousticGuitar.FingerboardWood).AppendLine()
                        .AppendFormat("Case included: {0}", acousticGuitar.CaseIncluded ? "yes" : "no").AppendLine()
                        .AppendFormat("String material: {0}", acousticGuitar.StringMaterial).AppendLine();
                }
            }
            if (this.Articles.Any(e => e is BassGuitar))
            {
                sb.AppendLine("----- Bass guitars -----");
                var bassGuitars = this.Articles.Where(e => e is BassGuitar)
                    .Cast<BassGuitar>()
                    .OrderBy(g => g.Make).ThenBy(g => g.Model);

                foreach (var bassGuitar in bassGuitars)
                {
                    sb.AppendFormat("= {0} {1} =", bassGuitar.Make, bassGuitar.Model).AppendLine()
                        .AppendFormat("Price: ${0:F2}", bassGuitar.Price).AppendLine()
                        .AppendFormat("Color: {0}", bassGuitar.Color).AppendLine()
                        .AppendFormat("Electronic: {0}", bassGuitar.IsElectronic ? "yes" : "no").AppendLine()
                        .AppendFormat("Strings: {0}", bassGuitar.NumberOfStrings).AppendLine()
                        .AppendFormat("Body wood: {0}", bassGuitar.BodyWood).AppendLine()
                        .AppendFormat("Fingerboard wood: {0}", bassGuitar.FingerboardWood).AppendLine();
                }
            }

            return sb.ToString().Trim();
        }
    }
}