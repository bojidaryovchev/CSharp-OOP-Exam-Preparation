using Estates.Interfaces;

namespace Estates.Estates
{
    public class SaleOffer : Offer, ISaleOffer
    {
        public SaleOffer(OfferType type) : base(type)
        {
            
        }

        public SaleOffer(OfferType type, IEstate estate, decimal price) : base(type, estate)
        {
            this.Price = price;
        }

        public decimal Price { get; set; }

        public override string ToString()
        {
            return base.ToString() + ", Price = " + this.Price;
        }
    }
}