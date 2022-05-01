using System;
using Gupi2D.TopDownGame;
using UnityEngine;

namespace Froggi.Game
{
    public class Actor : MonoBehaviour, IActor
    {
        public event Action OnDataChanged;

        public event Action OnCollisionEnter;

        public event Action OnCollisionExit;

        [Header("Logic - On Collision")]
        [SerializeField] private string[] _tagsToCheckWith;

        [Space(20f)]

        [SerializeField] private bool _autoDestroyThis = false;
        [SerializeField] private bool _autoDestroyCollided = false;

        // Mechanism
        private Rigidbody2D _rigidbody;
        private ActorMovementController _movementController;

        private Vector2 _inputAxis;

        private int _tagsCount;
        private ActorData _actorData;

        #region Unity

        private void FixedUpdate()
        {
            if (!Movable)
                return;

            if (!HaveInput)
                return;

            _movementController.Move(_inputAxis);
        }

        private void Update()
        {
            UpdateMovementDirection();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!IsTagRegistered(other.gameObject.tag)) return;

            OnCollisionEnter?.Invoke();

            if (_autoDestroyCollided)
            {
                Destroy(other.gameObject);
            }

            if (_autoDestroyThis)
            {
                Destroy(gameObject);
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (!IsTagRegistered(other.gameObject.tag)) return;

            OnCollisionExit?.Invoke();
        }

        #endregion

        public ActorData Data
        {
            get => _actorData;
            set
            {
                _actorData = value;
                if (_movementController != null)
                    _movementController.Speed = value.Speed;
                OnDataChanged?.Invoke();
            }
        }

        public bool Movable => _rigidbody != null;

        public bool HaveInput =>
            Mathf.Abs(_inputAxis.x) > Mathf.Epsilon ||
            Mathf.Abs(_inputAxis.y) > Mathf.Epsilon;

        public Vector2 Position
        {
            get => _rigidbody.position;
            set => _rigidbody.position = value;
        }

        public Vector2 InputAxis => _inputAxis;

        public void Construct()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _movementController = new ActorMovementController(this);
        }

        private void UpdateMovementDirection()
        {
            if (!Movable)
                return;

            _inputAxis.x = Input.GetAxis("Horizontal");
            _inputAxis.y = Input.GetAxis("Vertical");
        }

        private bool IsTagRegistered(string objectTag)
        {
            if (string.IsNullOrEmpty(objectTag)) return false;

            _tagsCount = _tagsCount < 1 ? _tagsToCheckWith.Length : _tagsCount;

            for (var i = 0; i < _tagsCount; i++)
            {
                if (_tagsToCheckWith[i] == objectTag) return true;
            }

            return false;
        }
    }
}
