using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody))]
public class Survior : MonoBehaviour, IDamageable
{
    [SerializeField] private Mover _mover;
    [SerializeField] private Transform _destinationPoint;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Health _health;
    [SerializeField] private SurviorAnimationHandler _surviorAnimationHandler;

    private Transform _transform;

    public bool IsAvailibleToDamage => _health.IsAlive;

    [Inject]
    private void Construct(Transform destinationPoint) 
    {
        _destinationPoint = destinationPoint;
    }

    private void OnEnable()
    {
        _health.Died += Die;
    }

    private void OnDisable()
    {
        _health.Died -= Die;
    }

    private void Awake()
    {
        _transform = transform;
    }

    private void FixedUpdate()
    {
        if (_health.IsAlive)
            _mover.MoveTo(_destinationPoint, _transform, _rigidbody);
    }

    public void TakeDamage(float damage)
    {
        _health.TakeDamage(damage);
    }

    public void Rise() 
    {
        _surviorAnimationHandler.PlayMoveAnimation();
        _rigidbody.isKinematic = false;
    }

    public void Die()
    {
        _mover.StopMoving(_rigidbody);
        _surviorAnimationHandler.PlayeDeathAnimation();
        _rigidbody.isKinematic = true;
    }
}
