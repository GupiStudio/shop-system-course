using UnityEngine;

public class DataManager : MonoBehaviour
{
    static PlayerData playerData = new PlayerData();

    const string playerDataFileName = "player-data.txt";

    static DataManager()
    {
        LoadPlayerData();
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
}
