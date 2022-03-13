using UnityEngine;

public class UserShopDataManager : MonoBehaviour
{
    private const string ShopDataFileName = "shop-data.txt";

    public static ShopData Load()
    {
        return BinarySerializer.Load<ShopData>(ShopDataFileName);
    }

    public static void Save(ShopData shopData)
    {
        BinarySerializer.Save<ShopData>(shopData, ShopDataFileName);
    }
}
