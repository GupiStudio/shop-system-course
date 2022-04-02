using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour // remove monobehaviour
{
	private IShopDatabase _database;
	
	public bool PurchaseActor(int actorId, ref UserData userData)
	{
		var databaseLength = _database.ActorsInSale.Count;

		for (var i = 0; i < databaseLength; i++)
		{
			if (_database.ActorsInSale[i].Id != actorId) continue;

			if (userData.Coins < _database.ActorsInSale[i].Price) return false;
			
			userData.PurchasedActorIndexes.Add(actorId);

			return true;
		}

		return false;
	}

	public List<ActorData> GetActorsInsSale()
	{
		return _database.ActorsInSale;
	}
}
