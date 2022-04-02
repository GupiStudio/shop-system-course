using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewActorsDatabase", menuName = "Actors Database")]
public class ActorsDatabase : ScriptableObject
{
    public ActorData[] ActorDatas;
}
