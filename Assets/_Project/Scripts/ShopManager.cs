using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance;

    [SerializeField]
    private ActorsDatabase _database;

    private ShopData _shopData;

    [HideInInspector]
    public ActorsDatabase Database { get => _database; }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        _shopData = UserShopDataManager.Load();
    }

    public bool Purchase(int actorIndex)
    {
        if (_shopData.PurchasedActorsIndexes.Contains(actorIndex))
        {
            return false;
        }

        var actor = Database.GetActor(actorIndex);

        if (!ActorManager.Instance.CanSpendCoin((uint)actor.Price))
        {
            return false;
        }

        _shopData.PurchasedActorsIndexes.Add(actorIndex);

        _database.ClaimActor(actorIndex);

        UserShopDataManager.Save(_shopData);

        return true;
    }

    public int GetPurchasedActorsCount()
    {
        return _shopData.PurchasedActorsIndexes.Count;
    }

    public void FetchSavedShopDataToDatabase()
	{
		int count = GetPurchasedActorsCount();

		for (int i = 0; i < count; i++)
		{
			int index = _shopData.PurchasedActorsIndexes[i];
			_database.ClaimActor(index);
		}
	}
}