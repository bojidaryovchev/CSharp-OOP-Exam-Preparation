using Estates.Interfaces;

namespace Estates.Estates
{
    public abstract class Offer : IOffer
    {
        protected Offer(OfferType type) : this(type, null)
        {
            
        }

        protected Offer(OfferType type, IEstate estate)
        {
            this.Type = type;
            this.Estate = estate;
        }

        public OfferType Type { get; set; }
        public IEstate Estate { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: Estate = {1}, Location = {2}", this.Type, this.Estate.Name, this.Estate.Location);
        }
    }
}