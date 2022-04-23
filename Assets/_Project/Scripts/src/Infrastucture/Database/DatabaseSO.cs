using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDatabase", menuName = "Database")]
public class DatabaseSO : ScriptableObject
{
    public IconPackSO IconPack;
    public ActorData[] ActorsData;
    public IntValueSO CoinWorth;
}
