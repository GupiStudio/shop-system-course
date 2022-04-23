using System.Collections.Generic;

[System.Serializable]
public class ShopData
{
    public int CurrentSelectedActorIndex { get; set; }
    public List<int> PurchasedActorIndexes { get; set; }
}