using UnityEngine;

namespace Gupi2D.TopDownGame
{
	public class ActorMovementController : MonoBehaviour
	{
		public float Speed = 1f;

		[SerializeField] private Rigidbody2D _rigidbody;

		private Vector2 _movement;

		public bool Moving => _movement.x != 0 || _movement.y != 0;

		private void Update()
		{
			UpdateMovementDirection();
		}

		private void FixedUpdate()
		{
			if (!Moving)
			{
				return;
			}

			Move(_movement);
		}

		private void UpdateMovementDirection()
		{
			_movement.x = Input.GetAxis("Horizontal");
			_movement.y = Input.GetAxis("Vertical");
		}

		private void Move(Vector2 direction)
		{
			_rigidbody.position += direction * Speed * Time.fixedDeltaTime;
		}
	}
}
