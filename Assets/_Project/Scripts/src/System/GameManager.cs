using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private IntValueSO _coinWorth;
    [SerializeField] private GameObject _userSavedDataGameObject;
    [SerializeField] private CoinUI _coinUI;

    private IUserSavedData _userSavedData;

    private void Awake()
    {
        Construct();
        Initialize();
    }

    public void CollectCoin()
    {
        var currentData = _userSavedData.UserData;
        currentData.Coins += _coinWorth.value;

        UserData data = currentData;
        _userSavedData.UserData = data;
        _coinUI.SetAmount(_userSavedData.UserData.Coins);
    }

    private void Construct()
    {
        _userSavedData ??= _userSavedDataGameObject.GetComponent<IUserSavedData>();
    }

    private void Initialize()
    {
        var coin = _userSavedData.UserData.Coins;
        #if UNITY_EDITOR
        Debug.Log("Coins: " + coin);
        #endif
        _coinUI.SetAmount(coin);
    }
}
