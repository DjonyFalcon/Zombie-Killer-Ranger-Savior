using UnityEngine;

namespace Player
{
    public class Aimer : MonoBehaviour
    {
        [SerializeField] private Transform _cameraTransform;
        [SerializeField] private float _sensetivity = 0.5f;
        [SerializeField] private float _maxRotationX = 45;
        [SerializeField] private float _minRotationX = -45;
        [SerializeField] private float _maxRotationY = 45;
        [SerializeField] private float _minRotationY = -45;

        private float _rotationX;
        private float _rotationY;

        private void Start()
        {
            _rotationX = _cameraTransform.rotation.eulerAngles.x;
            _rotationY = _cameraTransform.rotation.eulerAngles.y;
        }

        public void Aim(Vector2 deltaRotation)
        {
            _rotationX += deltaRotation.x * _sensetivity;
            _rotationY -= deltaRotation.y * _sensetivity;
            _rotationX = Mathf.Clamp(_rotationX, _minRotationX, _maxRotationX);
            _rotationY = Mathf.Clamp(_rotationY, _minRotationY, _maxRotationY);
            _cameraTransform.localRotation = Quaternion.Euler(new Vector3(_rotationY, _rotationX, 0));
        }
    }
}