using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    [SerializeField] private WalletUI _wallet;
    [SerializeField] private ActorUI _actor;

    public void UpdateWallet(int amount)
    {
        _wallet.Amount = amount;
    }

    public void UpdateAvatar(Sprite sprite, string name)
	{
        _actor.Graphic = sprite;
        _actor.name = name;
	}
}