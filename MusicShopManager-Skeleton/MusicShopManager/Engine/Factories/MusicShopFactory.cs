
namespace MusicShopManager.Engine.Factories
{
    using Interfaces;
    using Interfaces.Engine;

    public class MusicShopFactory : IMusicShopFactory
    {
        public IMusicShop CreateMusicShop(string name)
        {
            return new global::MusicShop.Models.MusicShop(name);
        }
    }
}