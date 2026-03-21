using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody))]
public class Survior : MonoBehaviour, IDamageable
{
    [SerializeField] private Mover _mover;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Health _health;
    [SerializeField] private SurviorAnimationHandler _surviorAnimationHandler;
    [SerializeField] private IReadOnlyList<WayPoint> _wayPoints;
    [SerializeField] private DistanceMeter _distanceMeter;

    private Transform _transform;

    public bool IsAvailibleToDamage => _health.IsAlive;
   
    public void Init(IReadOnlyList<WayPoint> wayPoints) 
    {
        _wayPoints = wayPoints;
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
            _mover.MoveTo(_wayPoints[2].transform, _transform, _rigidbody);
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
