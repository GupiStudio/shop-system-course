using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static UserData _userData;
    private static ShopData shopData = new ShopData();

    private static Character selectedCharacter;

    const string playerDataFileName = "player-data.txt";
    const string ShopDataFileName = "shop-data.txt";

    static DataManager()
    {
        LoadPlayerData();
        LoadShopData();
    }

    public static Character GetSelectedCharacter()
    {
        return selectedCharacter;
    }

    public static void SetSelectedCharacter(Character character, int index)
    {
        selectedCharacter = character;
        _userData.SelectedCharacterIndex = index;
        SavePlayerData();
    }

    public static int GetSelectedCharacterIndex()
    {
        return _userData.SelectedCharacterIndex;
    }

    public static int GetCoins()
    {
        return _userData.CoinCount;
    }

    public static void AddCoins(int amount)
    {
        _userData.CoinCount += amount;
        SavePlayerData();
    }

    public static bool CanSpendCoins(int amount)
    {
        return _userData.CoinCount >= amount;
    }

    public static void SpendCoins(int amount)
    {
        if (CanSpendCoins(amount))
        {
            _userData.CoinCount -= amount;
            
            SavePlayerData();
        }
    }

    public static void LoadPlayerData()
    {
        _userData = BinarySerializer.Load<UserData>(playerDataFileName);
    }

    public static void SavePlayerData()
    {
        BinarySerializer.Save<UserData>(_userData, playerDataFileName);
    }

    public static void AddPurchasedCharacterIndex(int index)
    {
        if (!shopData.PurchasedCharactersIndexes.Contains(index))
        {
            shopData.PurchasedCharactersIndexes.Add(index);
            SaveShopData();
        }
    }

    public static List<int> GetPurchasedCharacterIndexes()
    {
        return shopData.PurchasedCharactersIndexes;
    }

    public static int GetPurchasedCharacter(int index)
    {
        return shopData.PurchasedCharactersIndexes[index];
    }

    public static void LoadShopData()
    {
        shopData = BinarySerializer.Load<ShopData>(ShopDataFileName);
    }

    public static void SaveShopData()
    {
        BinarySerializer.Save<ShopData>(shopData, ShopDataFileName);
    }
}
