using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private IntValueSO _coinWorth;
    [SerializeField] private UserManager _userManager;
    [SerializeField] private CoinUI _coinUI;
    
    private void Awake()
    {
        Construct();
        Initialize();
    }

    public void CollectCoin()
    {
        _userManager.AddCoin((uint)_coinWorth.value);
        _coinUI.SetAmount(_userManager.GetCurrentCoin());
    }

    private void Construct()
    {
        //
    }

    private void Initialize()
    {
        var coin = _userManager.GetCurrentCoin();
        _coinUI.SetAmount(coin);
    }
}
