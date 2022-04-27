using System.Collections.Generic;
using Froggi.Game;
using UnityEngine;

namespace Froggi.Infrastructure
{
	public interface IDatabase
    {
        List<Sprite> GetIcons();
        List<ActorData> GetActorsData();
        int GetCoinWorth();
    }
}
