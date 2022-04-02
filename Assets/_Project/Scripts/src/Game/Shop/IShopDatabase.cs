using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShopDatabase
{
    List<ActorData> ActorsList { get; }
}
