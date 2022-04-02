using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserManager : MonoBehaviour
{
    private IUserSavedData _savedData;

    private List<int> _purchasedActorIndexes;

    public int GetCurrentCoin()
    {
        return _savedData.UserData.Coins;
    }

    public void AddCoin(uint amount)
    {
        var userData = _savedData.UserData;
        var coins = userData.Coins;
        coins += (int) amount;
        userData.Coins = coins;
        
        _savedData.UserData = userData;
    }

    public void SubtractCoin(uint amount)
    {
        var userData = _savedData.UserData;
        var coins = userData.Coins;
        coins -= (int)amount;
        userData.Coins = coins;

        _savedData.UserData = userData;
    }

    public List<int> GetPurchasedActorIndexes()
    {
        _purchasedActorIndexes ??= new List<int>();
        
        if (_purchasedActorIndexes.Count > 0)
            _purchasedActorIndexes.Clear();

        foreach (var index in _savedData.UserData.PurchasedActorIndexes)
        {
            _purchasedActorIndexes.Add(index);
        }
        
        return _purchasedActorIndexes;
    }

    public int GetCurrentActorIndex()
    {
        return _savedData.UserData.CurrentActorIndex;
    }
    
    public void AddActor(int actorIndex)
    {
        _savedData.UserData.PurchasedActorIndexes.Add(actorIndex);
    }
}
