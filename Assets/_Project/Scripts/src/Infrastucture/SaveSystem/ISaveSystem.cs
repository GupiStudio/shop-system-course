using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveSystem
{
    void SaveShopData(ShopData shopData);
    void SaveWalletData(WalletData walletData);
    ShopData GetShopData();
    WalletData GetWalletData();
}
