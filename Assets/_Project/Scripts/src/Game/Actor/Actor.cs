using System;
using Gupi2D.TopDownGame;
using UnityEngine;

namespace Froggi.Game
{
    public class Actor : MonoBehaviour
    {
        public event Action OnDataChanged;

        public event Action OnCollisionEnter;

        public event Action OnCollisionExit;

        [Header("Mechanic")] [SerializeField] private ActorMovementController _movementController;

        [Header("Logic")] [SerializeField] private string[] _tagsToCheckWith;
        [Space(20f)] [SerializeField] private bool _autoDestroyThis = false;
        [SerializeField] private bool _autoDestroyCollided = false;

        private int _tagsCount;
        private ActorData _actorData;

        #region Unity

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

        public void Construct(ActorData actorData)
        {
            Data = actorData;

            _tagsCount = _tagsToCheckWith.Length;
        }

        public ActorData Data
        {
            get => _actorData;
            set
            {
                _actorData = value;
                SetSpeed(value.Speed);
                OnDataChanged?.Invoke();
            }
        }

        private bool IsTagRegistered(string objectTag)
        {
            if (string.IsNullOrEmpty(objectTag)) return false;

            for (var i = 0; i < _tagsCount; i++)
            {
                if (_tagsToCheckWith[i] == objectTag) return true;
            }

            return false;
        }

        private void SetSpeed(int value)
        {
            if (_movementController) _movementController.Speed = value;
        }
    }
}
