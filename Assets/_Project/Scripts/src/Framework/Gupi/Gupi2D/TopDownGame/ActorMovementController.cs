using UnityEngine;

namespace Gupi2D.TopDownGame
{
	public class ActorMovementController
	{
		public float Speed = 1f;

		private IActor _actor;

		public ActorMovementController(IActor actor)
		{
			_actor = actor;
		}

		public void Move(Vector2 direction)
		{
			if (_actor.Movable)
				_actor.Position += direction * Speed * Time.fixedDeltaTime;
		}
	}
}
