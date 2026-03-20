using UnityEngine;
using Zenject;

public class HelicopterPositioner : MonoBehaviour
{
    [Header("Base settings")]
    [SerializeField] private float _baseDistance = 15f;
    [SerializeField] private float _baseHeight = 5.3f;
    [SerializeField] private float _rotationDuration = 5f;
    [SerializeField] private float _maxSpeed = 8f;
    [SerializeField] private float _positionSmoothTime = 1f;

    [Header("Ranges")]
    [SerializeField] private float _horizontalRange = 3f;
    [SerializeField] private float _verticalRange = 7f;
    [SerializeField] private float _distanceRange = 2f;

    [Header("Speeds")]
    [SerializeField] private float _horizontalSpeed = 0.5f;
    [SerializeField] private float _verticalSpeed = 0.7f;
    [SerializeField] private float _distanceSpeed = 0.3f;


    private Transform _surviorTransform;
    private Vector3 _currentVelocity;
    private float _time;
  
    [Inject]
    private void Construct(Survior survior)
    {
        _surviorTransform = survior.transform;
    }

    public void Move(Transform _playerTransform) 
    {
        _time += Time.fixedDeltaTime;

        Vector3 targetPosition = CalculateTargetPosition();

        _playerTransform.position = Vector3.SmoothDamp(_playerTransform.position, targetPosition, ref _currentVelocity, _positionSmoothTime, _maxSpeed);

        Rotate(_playerTransform);
    }

    private Vector3 CalculateTargetPosition()
    {
        _time += Time.fixedDeltaTime;

        float horizontalOffset = Mathf.Sin(_time * _horizontalSpeed) * _horizontalRange;
        float verticalOffset = Mathf.Sin(_time * _verticalSpeed) * _verticalRange;
        float distanceOffset = Mathf.Sin(_time * _distanceSpeed) * _distanceRange;

        Vector3 survivorForward = _surviorTransform.forward;

        survivorForward.y = 0;
        survivorForward.Normalize();


        Vector3 survivorRight = Vector3.Cross(Vector3.up, survivorForward).normalized;
        Vector3 targetPosition = _surviorTransform.position + survivorForward * (_baseDistance + distanceOffset) + Vector3.up * (_baseHeight + verticalOffset) + survivorRight * horizontalOffset;

        return targetPosition;
    }

    private void Rotate(Transform _playerTransform)
    {
        Vector3 direction = _surviorTransform.position - transform.position;

        direction.y = 0;
        direction.Normalize();

        Quaternion targetRotation = Quaternion.LookRotation(Vector3.Cross(direction, Vector3.up), Vector3.up);

        _playerTransform.rotation = Quaternion.Slerp(_playerTransform.rotation, targetRotation, Time.fixedDeltaTime * _rotationDuration);
    }
}