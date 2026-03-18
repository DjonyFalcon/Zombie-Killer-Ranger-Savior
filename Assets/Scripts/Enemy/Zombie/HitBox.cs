using UnityEngine;

public class HitBox : MonoBehaviour, IDamageable
{
    [SerializeField] private Health _health;
    [SerializeField] private float _damageFactor;

    private bool _isAvailibleToDamage = true;
    public bool IsAvailibleToDamage => _isAvailibleToDamage;

    private void OnEnable()
    {
        _health.Died += MakeInaccessibleToDamage;
        _health.OnRised += MakeAvalibleToDamage;
    }

    private void OnDisable()
    {
        _health.Died -= MakeInaccessibleToDamage;
        _health.OnRised -= MakeAvalibleToDamage;
    }

    public void TakeDamage(float damage)
    {
        _health.TakeDamage(damage * _damageFactor);
    }

    public void MakeAvalibleToDamage() 
    {
        _isAvailibleToDamage = true;
    }

    public void MakeInaccessibleToDamage() 
    {
        _isAvailibleToDamage = false;
    }
}
