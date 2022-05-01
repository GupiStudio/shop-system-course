using UnityEngine;

public interface IActor
{
    bool Movable { get; }
    bool HaveInput { get; }
    Vector2 Position { get; set; }
    Vector2 InputAxis { get; }
}
