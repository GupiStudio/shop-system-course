using Froggi.Game;
using UnityEngine;
using Froggi.Infrastructure;
using Froggi.Presentation;

namespace Froggi.SystemManager
{
	public class GameManager : MonoBehaviour
	{
		[Header("Game")] [SerializeField] private Actor _actor;
		[SerializeField] private Wallet _wallet;
		[SerializeField] private Shop _shop;

		[Header("Infrastructure")] [SerializeReference]
		private GameObject _databaseObject;

		[SerializeReference] private GameObject _saveSystemObject;

		[Header("Presentation")] [SerializeField]
		private ShopUI _shopUI;

		[SerializeField] private ActorUI[] _actorsUI;
		[SerializeField] private WalletUI[] _walletsUI;
		[SerializeField] private ActorCostume _actorCostume;

		private IDatabase _database;
		private ISaveSystem _saveSystem;

		private void Awake()
		{
			_database = _databaseObject.GetComponent<IDatabase>();
			_saveSystem = _saveSystemObject.GetComponent<ISaveSystem>();

			SubscribeEvents();
			LoadGame();
		}

		private void Start()
		{
			if (_shopUI != null)
				InitializeShopPresentation();
		}

		private void OnDestroy()
		{
			UnsubscribeEvents();
		}

		private void _actor_OnCollisionEnter()
		{
			CollectCoin();
		}

		private void _actor_OnDataChanged()
		{
			UpdateActorPresentation();
		}

		private void _wallet_OnDataChanged()
		{
			UpdateWalletPresentation();
		}

		private void _shop_OnDataChanged()
		{
			_saveSystem.SaveShopData(_shop.Data);
			_actor.Data = _database.GetActorsData()[_shop.Data.CurrentSelectedActorIndex];
		}

		private void SubscribeEvents()
		{
			if (_actor)
			{
				_actor.OnCollisionEnter += _actor_OnCollisionEnter;
				_actor.OnDataChanged += _actor_OnDataChanged;
			}

			if (_wallet)
				_wallet.OnDataChanged += _wallet_OnDataChanged;

			if (_shop)
				_shop.OnDataChanged += _shop_OnDataChanged;
		}

		private void UnsubscribeEvents()
		{
			if (_actor)
			{
				_actor.OnCollisionEnter -= _actor_OnCollisionEnter;
				_actor.OnDataChanged -= _actor_OnDataChanged;
			}

			if (_wallet)
				_wallet.OnDataChanged -= _wallet_OnDataChanged;

			if (_shop)
				_shop.OnDataChanged -= _shop_OnDataChanged;
		}

		private void LoadGame()
		{
			_wallet.Data = _saveSystem.GetWalletData();
			_shop.Data = _saveSystem.GetShopData();
			_actor.Construct(_database.GetActorsData()[_shop.Data.CurrentSelectedActorIndex]);
		}

		private void CollectCoin()
		{
			var data = _wallet.Data;
			data.Amount += _database.GetCoinWorth();

			_wallet.Data = data;

			_saveSystem.SaveWalletData(_wallet.Data);
		}

		private void InitializeShopPresentation()
		{
			var currentActorIndex = _shop.Data.CurrentSelectedActorIndex;
			var sprites = _database.GetIcons();
			var actorsData = _database.GetActorsData();
			var purchasedActors = _saveSystem.GetShopData().PurchasedActorIndexes;
			if (purchasedActors != null)
			{
				var count = purchasedActors.Count;

				for (var i = 0; i < count; i++)
				{
					var index = purchasedActors[i];
					var data = actorsData[index];
					data.IsPurchased = true;
					actorsData[index] = data;
				}
			}

			_shopUI.Construct();
			_shopUI.InitializeShopItems(sprites, actorsData, currentActorIndex);
		}

		private void UpdateWalletPresentation()
		{
			var coin = _wallet.Data.Amount;

			var count = _walletsUI.Length;

			if (count < 1) return;

			for (var i = 0; i < count; i++)
			{
				_walletsUI[i].Amount = coin;
			}
		}

		private void UpdateActorPresentation()
		{
			var sprite = _database.GetIcons()[_shop.Data.CurrentSelectedActorIndex];
			var actorName = _actor.Data.Name;

			var count = _actorsUI.Length;

			if (count > 0)
			{
				for (var i = 0; i < count; i++)
				{
					_actorsUI[i].Graphic = sprite;
					_actorsUI[i].Name = actorName;
				}
			}

			if (_actorCostume == null) return;
			_actorCostume.Graphic = sprite;
			_actorCostume.Name = actorName;
		}
	}
}
