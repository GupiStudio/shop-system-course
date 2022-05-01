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

		public bool CanDraw(int amount)
		{
			if (amount < 0)
				return false;

			return Data.Amount >= amount;
		}

		public bool Add(int amount)
		{
			if (amount < 0)
				return false;

			var data = Data;
			data.Amount += amount;
			Data = data;

			return true;
		}

		public bool Draw(int amount)
		{
			if (amount < 0)
				return false;

			var data = Data;
			data.Amount -= amount;
			Data = data;

			return true;
		}
	}
}
