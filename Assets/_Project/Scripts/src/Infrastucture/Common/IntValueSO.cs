using UnityEngine;

namespace Froggi.Infrastructure
{
    [CreateAssetMenu(fileName = "NewIntegerValue", menuName = "Integer Value")]
    public class IntValueSO : ScriptableObject
    {
        public int Value = 0;
    }
}
