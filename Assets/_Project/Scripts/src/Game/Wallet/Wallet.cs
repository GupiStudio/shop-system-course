using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
	public event Action OnDataChanged;

	private WalletData _walletData;

	public WalletData Data
	{
		get => _walletData;
		set
		{
			_walletData = value;
			OnDataChanged?.Invoke();
		}
	}
}
