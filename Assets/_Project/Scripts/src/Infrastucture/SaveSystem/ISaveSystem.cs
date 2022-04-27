using Froggi.Game;

namespace Froggi.Infrastructure
{
    public interface ISaveSystem
    {
        void SaveShopData(ShopData shopData);
        void SaveWalletData(WalletData walletData);
        ShopData GetShopData();
        WalletData GetWalletData();
    }
}
