using UnityEngine;

[System.Serializable]
public struct ActorData
{
    public Sprite Image;
    
    public string Name;
    
    [Range(1, 100)] 
    public int Speed;

    [Range(1, 100)]
    public int Power;

    public int Price;

    public bool IsPurchased;
}
