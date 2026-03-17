using System.Collections;
using UnityEngine;

public class ZombieWeapon : MonoBehaviour
{
    [SerializeField] private float _damage = 35f;
    [SerializeField] private float _timeBetweenAttack = 2f;

    private WaitForSeconds _waitBetweenAttack;

    private bool _isAvailiable;

    private void Awake()
    {
        _isAvailiable = true;
        _waitBetweenAttack = new WaitForSeconds(_timeBetweenAttack);
    }

    public void Attack(IDamageable damageable)
    {
        if (_isAvailiable)
        {
            _isAvailiable = false;
            damageable.TakeDamage(_damage);
            StartCoroutine(DelayBetweenAttack());
        }
    }

    private IEnumerator DelayBetweenAttack() 
    {
        yield return _waitBetweenAttack;

        _isAvailiable = true;
    }
}
