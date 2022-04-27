using UnityEngine;

namespace Froggi.Presentation
{
    public interface IActorUI
    {
        Sprite Graphic { get; set; }
        string Name { get; set; }
    }
}
