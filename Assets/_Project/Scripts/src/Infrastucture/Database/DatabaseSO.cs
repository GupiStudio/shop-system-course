using Froggi.Game;
using UnityEngine;

namespace Froggi.Infrastructure
{
    [CreateAssetMenu(fileName = "NewDatabase", menuName = "Database")]
    public class DatabaseSO : ScriptableObject
    {
        public IconPackSO IconPack;
        public ActorData[] ActorsData;
        public IntValueSO CoinWorth;
    }
}
