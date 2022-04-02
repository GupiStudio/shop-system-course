using System.Collections.Generic;

[System.Serializable]
public struct UserData
{
    public int CurrentActorIndex;
    public int Coins;
    public List<int> PurchasedActorIndexes;
}
