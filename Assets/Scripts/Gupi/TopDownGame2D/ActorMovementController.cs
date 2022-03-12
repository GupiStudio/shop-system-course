using UnityEngine;

namespace Gupi.TopDownGame2D
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class ActorMovementController : MonoBehaviour
	{
		[SerializeField]
		private float _speed;

		private Rigidbody2D _rigidbody;

		private Vector2 _movement;

		public bool Moving => _movement.x != 0 || _movement.y != 0;

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody2D>();
		}

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
			_rigidbody.position += direction * _speed * Time.fixedDeltaTime;
		}
	}
}
