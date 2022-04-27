using UnityEngine;

namespace Froggi.Game
{
    [System.Serializable]
    public struct ActorData
    {
        public int Id;

        public string Name;

        [Range(1, 100)] public int Speed;

        [Range(1, 100)] public int Power;

        public int Price;

        public bool IsPurchased;
    }
}
