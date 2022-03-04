using UnityEngine;

[System.Serializable]
public struct Character
{
    public Sprite sprite;
    
    public string name;
    
    [Range(1, 100)] 
    public int speed;

    [Range(1, 100)]
    public int power;

    public int price;

    public bool isPurchased;
}
