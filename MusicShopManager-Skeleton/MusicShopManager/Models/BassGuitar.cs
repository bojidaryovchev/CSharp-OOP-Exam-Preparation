using MusicShopManager.Interfaces;

namespace MusicShop.Models
{
    public class BassGuitar : Guitar, IBassGuitar
    {
        private const int DefaultBassGuitarNumberOfStrings = 4;
        private const bool DefaultBassGuitarIsElectronic = true;

        public BassGuitar(string make, string model, decimal price, string color, string bodyWood,
            string fingerboardWood)
            : base(
                make, model, price, color, DefaultBassGuitarIsElectronic, bodyWood, fingerboardWood,
                DefaultBassGuitarNumberOfStrings)
        {
        }
    }
}