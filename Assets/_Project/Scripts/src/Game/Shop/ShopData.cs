using System.Collections.Generic;

namespace Froggi.Game
{
    [System.Serializable]
    public class ShopData
    {
        public int CurrentSelectedActorIndex { get; set; }
        public List<int> PurchasedActorIndexes { get; set; }
    }
}
