using UnityEngine;
using UnityEngine.Events;

namespace Gupi2D
{
	[RequireComponent(typeof(Collider2D))]
	public class CollisionHandler : MonoBehaviour
	{
		[SerializeField]
		private string[] _checkCollisionWithTags;

		[Space(20f)]

		[SerializeField]
		private bool _autoDestroyThis = false;

		[SerializeField]
		private bool _autoDestroyCollided = false;
		
		[Space(20f)]

		[SerializeField]
		private UnityEvent _onCollision;

		private GameObject _collidedGameObject;

		private int _tagsCount;

		private void Awake()
		{
			_tagsCount = _checkCollisionWithTags.Length;
		}

		private void OnCollisionEnter2D(Collision2D collision)
		{
			if (!TagRegistered(collision.gameObject.tag)) return;

			_collidedGameObject = collision.gameObject;

			_onCollision.Invoke();

			if (_autoDestroyCollided)
			{
				Destroy(collision.gameObject);
			}

			if (_autoDestroyThis)
			{
				Destroy(gameObject);
			}
		}

		private bool TagRegistered(string tag)
		{
			if (string.IsNullOrEmpty(tag)) return false;

			for (int i = 0; i < _tagsCount; i++)
			{
				if (_checkCollisionWithTags[i] == tag) return true;
			}

			return false;
		}
	}
}
