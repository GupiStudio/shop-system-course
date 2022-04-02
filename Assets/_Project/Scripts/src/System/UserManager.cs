using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserManager : MonoBehaviour
{
    [SerializeField] private GameObject _userSavedDataGameObject;
    
    private IUserSavedData _userSavedData;

    private List<int> _purchasedActorIndexes;

    private void Awake()
    {
        Construct();
        Initialize();
    }

    private void Construct()
    {
        _userSavedData ??= _userSavedDataGameObject.GetComponent<IUserSavedData>();
    }

    private void Initialize()
    {
        //
    }

    public int GetCurrentCoin()
    {
        return _userSavedData.UserData.Coins;
    }

    public void AddCoin(uint amount)
    {
        var currentData = _userSavedData.UserData;
        currentData.Coins += (int)amount;

        var data = currentData;
        _userSavedData.UserData = data;
    }

    public void SubtractCoin(uint amount)
    {
        var currentData = _userSavedData.UserData;
        currentData.Coins -= (int)amount;

        var data = currentData;
        _userSavedData.UserData = data;
    }

    public List<int> GetPurchasedActorIndexes()
    {
        _purchasedActorIndexes ??= new List<int>();
        
        var list = _userSavedData.UserData.PurchasedActorIndexes;

        if (list == null)
        {
            _purchasedActorIndexes.Add(GetCurrentActorIndex());
            return _purchasedActorIndexes;
        }

        if (_purchasedActorIndexes.Count > 0)
            _purchasedActorIndexes.Clear();

        foreach (var index in list)
        {
            _purchasedActorIndexes.Add(index);
        }
        
        return _purchasedActorIndexes;
    }

    public int GetCurrentActorIndex()
    {
        return _userSavedData.UserData.CurrentActorIndex;
    }
    
    public void AddActor(int actorIndex)
    {
        _userSavedData.UserData.PurchasedActorIndexes.Add(actorIndex);
    }
}
