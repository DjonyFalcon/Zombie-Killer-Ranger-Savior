using UnityEngine;

public class HitBox : MonoBehaviour, IDamageable
{
    [SerializeField] private Health _health;
    [SerializeField] private float _damageFactor;

    public void TakeDamage(float damage)
    {
        _health.TakeDamage(damage * _damageFactor);
    }
}
