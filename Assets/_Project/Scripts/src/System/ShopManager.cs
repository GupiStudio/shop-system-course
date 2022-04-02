using System;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
	[SerializeField] private GameObject _shopDatabaseGameObjects;
	
	private IShopDatabase _shopDatabase;

	private void Awake()
	{
		Construct();
	}

	private void Construct()
	{
		_shopDatabase ??= _shopDatabaseGameObjects.GetComponent<IShopDatabase>();
	}

	private void Initialize()
	{
		//
	}

	public bool PurchaseActor(int actorIndex)
	{
		var databaseLength = _shopDatabase.ActorsList.Count;

		if (actorIndex > databaseLength || actorIndex < 0)
			return false;

		var actor = _shopDatabase.ActorsList[actorIndex];
		actor.IsPurchased = true;
		_shopDatabase.ActorsList[actorIndex] = actor;

		return true;
	}

	public List<ActorData> GetActorsList()
	{
		return _shopDatabase.ActorsList;
	}
}
