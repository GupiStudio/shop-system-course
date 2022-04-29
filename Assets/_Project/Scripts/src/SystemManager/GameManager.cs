using Froggi.Game;
using UnityEngine;
using Froggi.Infrastructure;
using Froggi.Presentation;

namespace Froggi.SystemManager
{
	public class GameManager : MonoBehaviour
	{
		[Header("Game")]
		[SerializeField] private Actor _actor;

		[Header("Infrastructure")]
		[SerializeField] private Database _database;

		[Header("Presentation")]
		[SerializeField] private ShopUI _shopUI;
		[SerializeField] private ActorUI[] _actorsUI;
		[SerializeField] private WalletUI[] _walletsUI;
		[SerializeField] private ActorCostume _actorCostume;

		private Wallet _wallet;
		private Shop _shop;

		private IDatabase _db;
		private ISaveSystem _saveSystem;

		private void Awake()
		{
			Construct();
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
			_actor.Data = _db.GetActorsData()[_shop.Data.CurrentSelectedActorIndex];
		}

		private void Construct()
		{
			_wallet = new Wallet();
			_shop = new Shop();
			_db = _database;
			_saveSystem = new SaveSystem();
		}

		private void SubscribeEvents()
		{
			if (_actor)
			{
				_actor.OnCollisionEnter += _actor_OnCollisionEnter;
				_actor.OnDataChanged += _actor_OnDataChanged;
			}

			if (_wallet != null)
				_wallet.OnDataChanged += _wallet_OnDataChanged;

			if (_shop != null)
				_shop.OnDataChanged += _shop_OnDataChanged;
		}

		private void UnsubscribeEvents()
		{
			if (_actor)
			{
				_actor.OnCollisionEnter -= _actor_OnCollisionEnter;
				_actor.OnDataChanged -= _actor_OnDataChanged;
			}

			if (_wallet != null)
				_wallet.OnDataChanged -= _wallet_OnDataChanged;

			if (_shop != null)
				_shop.OnDataChanged -= _shop_OnDataChanged;
		}

		private void LoadGame()
		{
			_wallet.Data = _saveSystem.GetWalletData();
			_shop.Data = _saveSystem.GetShopData();
			_actor.Data = GetCurrentSelectedActor();
		}

		private ActorData GetCurrentSelectedActor()
		{
			return _db.GetActorsData()[_shop.Data.CurrentSelectedActorIndex];
		}

		private Sprite GetCurrentSelectedActorSprite()
		{
			return _db.GetIcons()[_shop.Data.CurrentSelectedActorIndex];
		}

		private void CollectCoin()
		{
			var data = _wallet.Data;
			data.Amount += _db.GetCoinWorth();

			_wallet.Data = data;

			_saveSystem.SaveWalletData(_wallet.Data);
		}

		private void InitializeShopPresentation()
		{
			var currentActorIndex = _shop.Data.CurrentSelectedActorIndex;
			var sprites = _db.GetIcons();
			var actorsData = _db.GetActorsData();
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

			_shopUI.Construct(_shop, _wallet);
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
			var sprite = GetCurrentSelectedActorSprite();
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
