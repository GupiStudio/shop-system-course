using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorManager : MonoBehaviour
{
    public static ActorManager Instance;

    private UserData _userData;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        _userData = UserGameplayDataManager.Load();
    }

    public int GetCurrentCoin()
    {
        return _userData.CoinCount;
    }

    public void CollectCoin(uint amount)
    {
        _userData.CoinCount += (int)amount;

        UserGameplayDataManager.Save(_userData);
    }

    public bool CanSpendCoin(uint amount)
    {
        return _userData.CoinCount >= amount;
    }

    public ActorData GetSelectedActor()
    {
        var database = ShopManager.Instance.Database;

        var actor = database.GetActor(_userData.SelectedActorIndex);
        
        return actor;
    }

    public void SetSelectedActor(int actorIndex)
    {
        _userData.SelectedActorIndex = actorIndex;
        
        UserGameplayDataManager.Save(_userData);
    }
}
