using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewActorsDatabase", menuName = "Actors Database")]
public class ActorsDatabase : ScriptableObject
{
    public ActorData[] ActorDatas;

    public int ActorsCount => ActorDatas.Length;

    public ActorData GetActor(int index)
    {
        return ActorDatas[index];
    }

    public bool ClaimActor(int index)
    {
        if (ActorDatas[index].IsPurchased)
        {
            return false;
        }

        ActorDatas[index].IsPurchased = true;

        return true;
    }
}
