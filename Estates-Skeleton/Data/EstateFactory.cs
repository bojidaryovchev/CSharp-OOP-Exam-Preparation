using Estates.Interfaces;
using System;
using Estates.Estates;

namespace Estates.Data
{
    public class EstateFactory
    {
        public static IEstateEngine CreateEstateEngine()
        {
            return new FixedEstateEngine();
        }

        public static IEstate CreateEstate(EstateType type)
        {
            switch (type)
            {
                case EstateType.Apartment:
                    return new Apartment(type);
                case EstateType.Garage:
                    return new Garage(type);
                case EstateType.House:
                    return new House(type);
                case EstateType.Office:
                    return new Office(type);
                default: throw new InvalidOperationException("No such estate type");
            }
        }

        public static IOffer CreateOffer(OfferType type)
        {
            switch (type)
            {
                case OfferType.Rent:
                    return new RentOffer(type);
                case OfferType.Sale:
                    return new SaleOffer(type);
                default:
                    throw new InvalidOperationException("No such offer type");
            }
        }
    }
}