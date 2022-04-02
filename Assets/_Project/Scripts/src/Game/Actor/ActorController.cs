using Gupi2D.TopDownGame;
using UnityEngine;

public class ActorController : MonoBehaviour
{
	[SerializeField] private ActorMovementController _movementController;

	public void SetSpeed(int value)
	{
		_movementController.Speed = value;
	}
}
