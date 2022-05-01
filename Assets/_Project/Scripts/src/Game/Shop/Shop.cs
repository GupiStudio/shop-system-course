using System;
using System.Collections.Generic;

namespace Froggi.Game
{
    public class Shop
    {
        public event Action OnDataChanged;
        public event Action OnActorPurchase;
        public event Action OnActorSelect;

        private ShopData _shopData;

        public ShopData Data
        {
            get
            {
                _shopData ??= new ShopData();
                _shopData.PurchasedActorIndexes ??= new List<int>();
                return _shopData;
            }
            set
            {
                _shopData = value;
                OnDataChanged?.Invoke();
            }
        }

        public bool Purchase(ActorData actor)
        {
            var data = Data;

            if (data.PurchasedActorIndexes.Contains(actor.Id))
                return false;

            data.PurchasedActorIndexes.Add(actor.Id);
            Data = data;

            OnActorPurchase?.Invoke();
            return true;
        }

        public bool Select(ActorData actor)
        {
            var data = Data;

            if (data.PurchasedActorIndexes.Count == 0)
                return false;

            if (!data.PurchasedActorIndexes.Contains(actor.Id))
                return false;

            data.CurrentSelectedActorIndex = actor.Id;
            Data = data;

            OnActorSelect?.Invoke();
            return true;
        }
    }
}
