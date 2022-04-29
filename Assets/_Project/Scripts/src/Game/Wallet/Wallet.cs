using System;

namespace Froggi.Game
{
	public class Wallet
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
}
