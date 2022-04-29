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
            get => _shopData;
            set
            {
                _shopData = value;
                OnDataChanged?.Invoke();
            }
        }

        public void Purchase(int id)
        {
            var data = Data;
            data.PurchasedActorIndexes ??= new List<int>();
            data.PurchasedActorIndexes.Add(id);
            Data = data;

            OnActorPurchase?.Invoke();
        }

        public void Select(int id)
        {
            var data = Data;
            data.CurrentSelectedActorIndex = id;
            Data = data;

            OnActorSelect?.Invoke();
        }
    }
}
