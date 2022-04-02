using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopDatabase : MonoBehaviour, IShopDatabase
{
    [SerializeField] private ActorsDatabase _actorsDatabase;

    private List<ActorData> _actorsInSale;
    
    public List<ActorData> ActorsInSale
    {
        get
        {
            if (_actorsInSale != null) return _actorsInSale;
            
            var databaseLength = _actorsDatabase.ActorDatas.Length;
                
            _actorsInSale = new List<ActorData>(databaseLength);

            for (var i = 0; i < databaseLength; i++)
            {
                _actorsInSale.Add(_actorsDatabase.ActorDatas[i]);
            }

            return _actorsInSale;
        }
    }
}
