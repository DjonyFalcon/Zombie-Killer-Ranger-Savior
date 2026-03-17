using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class Zombie : MonoBehaviour
{
    private const float DeathTime = 3f;

    [SerializeField] private DistanceMeter _distanceMeter;
    [SerializeField] private Survior _survior;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Health _health;
    [SerializeField] private ZombieWeapon _zombieHand;
    [SerializeField] private ZombieAnimatorHandler _animatorHandler;
    [SerializeField] private NavMeshAgent _navMeshAgent;

    private Transform _tramsform;

    private bool _isALive;

    public event Action<Zombie> Died;

    private void OnEnable()
    {
        _health.Died += Die;
        _distanceMeter.IsGotClose += Attack;
    }

    private void OnDisable()
    {
        _health.Died -= Die;
        _distanceMeter.IsGotClose -= Attack;
    }

    private void Awake()
    {
        _tramsform = transform;
        _isALive = true;
    }

    private void FixedUpdate()
    {
        if (_isALive)
        {
            _distanceMeter.Measure();
            _navMeshAgent.SetDestination(_survior.transform.position);
        }
    }

    public void Init(Vector3 position, Survior survior) 
    {
        _tramsform.position = position;
        _survior = survior;
        _distanceMeter.SetTarget(_survior.transform);
        _isALive = true;
    }

    private void Attack() 
    {
        _zombieHand.Attack(_survior);
        _animatorHandler.PlayAttackAnimation();
    }

    private void Die()
    {
        _isALive = false;
        _navMeshAgent.Stop();
        _rigidbody.velocity = Vector3.zero;
        _animatorHandler.PlayDeathAnimation();
        StartCoroutine(DelayDeath());
    }

    private IEnumerator DelayDeath() 
    {
        yield return new WaitForSeconds(DeathTime);

        Died?.Invoke(this);
    }
}
