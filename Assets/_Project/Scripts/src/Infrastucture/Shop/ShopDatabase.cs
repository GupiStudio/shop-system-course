using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopDatabase : MonoBehaviour, IShopDatabase
{
    [SerializeField] private ActorsDatabase _actorsDatabase;

    private List<ActorData> _actorsList;

    private ActorData _actorInUse;
    
    public List<ActorData> ActorsList
    {
        get
        {
            if (_actorsList != null) return _actorsList;
            
            var databaseLength = _actorsDatabase.ActorDatas.Length;
                
            _actorsList = new List<ActorData>(databaseLength);

            for (var i = 0; i < databaseLength; i++)
            {
                _actorsList.Add(_actorsDatabase.ActorDatas[i]);
            }

            return _actorsList;
        }
    }
}
