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

		private bool _moving;

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody2D>();
			_movement = new Vector2();
		}

		private void Update()
		{
			_movement.x = Input.GetAxis("Horizontal");
			_movement.y = Input.GetAxis("Vertical");

			_moving = _movement.x != 0 || _movement.y != 0;
		}

		private void FixedUpdate()
		{
			if (!_moving)
			{
				return;
			}

			_rigidbody.position += _movement * _speed * Time.fixedDeltaTime;
		}
	}
}
