using Estates.Interfaces;

namespace Estates.Estates
{
    public class RentOffer : Offer, IRentOffer
    {
        public RentOffer(OfferType type) : base(type)
        {
        }

        public RentOffer(OfferType type, IEstate estate, decimal pricePerMonth) : base(type, estate)
        {
            this.PricePerMonth = pricePerMonth;
        }
        
        public decimal PricePerMonth { get; set; }

        public override string ToString()
        {
            return base.ToString() + ", Price = " + this.PricePerMonth;
        }
    }
}