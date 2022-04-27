using UnityEngine;

namespace Froggi.Infrastructure
{
    [CreateAssetMenu(fileName = "New Icon Pack", menuName = "Icon Pack")]
    public class IconPackSO : ScriptableObject
    {
        public Sprite[] Icons;
    }
}
