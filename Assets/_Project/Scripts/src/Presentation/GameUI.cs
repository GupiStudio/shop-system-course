using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private WalletUI _wallet;

    public void UpdateWallet(int amount)
    {
        _wallet.Amount = amount;
    }
}