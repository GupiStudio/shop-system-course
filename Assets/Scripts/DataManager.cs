using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static PlayerData playerData = new PlayerData();
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
        playerData.SelectedCharacterIndex = index;
        SavePlayerData();
    }

    public static int GetSelectedCharacterIndex()
    {
        return playerData.SelectedCharacterIndex;
    }

    public static int GetCoins()
    {
        return playerData.coins;
    }

    public static void AddCoins(int amount)
    {
        playerData.coins += amount;
        SavePlayerData();
    }

    public static bool CanSpendCoins(int amount)
    {
        return playerData.coins >= amount;
    }

    public static void SpendCoins(int amount)
    {
        if (CanSpendCoins(amount))
        {
            playerData.coins -= amount;
            
            SavePlayerData();
        }
    }

    public static void LoadPlayerData()
    {
        playerData = BinarySerializer.Load<PlayerData>(playerDataFileName);
    }

    public static void SavePlayerData()
    {
        BinarySerializer.Save<PlayerData>(playerData, playerDataFileName);
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
