using System;
using System.Linq;
using Estates.Engine;
using Estates.Interfaces;

namespace Estates.Data
{
    public class FixedEstateEngine : EstateEngine
    {
        public override string ExecuteCommand(string cmdName, string[] cmdArgs)
        {
            switch (cmdName)
            {
                case "create":
                    return ExecuteCreateCommand(cmdArgs);
                case "status":
                    return ExecuteStatusCommand();
                case "find-sales-by-location":
                    return ExecuteFindSalesByLocationCommand(cmdArgs[0]);
                case "find-sales-by-price":
                    return ExecuteFindSalesByPriceCommand(decimal.Parse(cmdArgs[0]), decimal.Parse(cmdArgs[1]));
                case "find-rents-by-location":
                    return ExecuteFindRentsByLocationCommand(cmdArgs[0]);
                case "find-rents-by-price":
                    return ExecuteFindRentsByPriceCommand(decimal.Parse(cmdArgs[0]), decimal.Parse(cmdArgs[1]));
                default:
                    throw new NotImplementedException("Unknown command: " + cmdName);
            }
        }

        private string ExecuteFindSalesByLocationCommand(string location)
        {
            var offers = this.Offers
                .Where(o => o.Estate.Location == location && o.Type == OfferType.Sale)
                .OrderBy(o => o.Estate.Name);
            return FormatQueryResults(offers);
        }

        private string ExecuteFindSalesByPriceCommand(decimal minPrice, decimal maxPrice)
        {
            var offers = this.Offers
                .Where(o => o.Type == OfferType.Sale)
                .Cast<ISaleOffer>()
                .Where(o => o.Price >= minPrice && o.Price <= maxPrice && o.Type == OfferType.Sale)
                .OrderBy(o => o.Price)
                .ThenBy(o => o.Estate.Name);
            return FormatQueryResults(offers);
        }

        private string ExecuteFindRentsByLocationCommand(string location)
        {
            var offers = this.Offers
                .Where(o => o.Estate.Location == location && o.Type == OfferType.Rent)
                .OrderBy(o => o.Estate.Name);
            return FormatQueryResults(offers);
        }

        private string ExecuteFindRentsByPriceCommand(decimal minPrice, decimal maxPrice)
        {
            var offers = this.Offers
                .Where(o => o.Type == OfferType.Rent)
                .Cast<IRentOffer>()
                .Where(o => o.PricePerMonth >= minPrice && o.PricePerMonth <= maxPrice && o.Type == OfferType.Rent)
                .OrderBy(o => o.PricePerMonth)
                .ThenBy(o => o.Estate.Name);
            return FormatQueryResults(offers);
        }
    }
}