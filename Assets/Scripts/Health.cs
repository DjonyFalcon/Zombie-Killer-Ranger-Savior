using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxValue = 100;

    private float _currentValue;

    private bool _isAlive = true;

    public event Action OnRised;
    public event Action Died;
    public event Action<float> DamageTaked;

    public bool IsAlive => _isAlive;

    private void Start()
    {
        Rise();
    }

    public void Rise()
    {
        _isAlive = true;
        _currentValue = _maxValue;
        OnRised?.Invoke();
    }

    public void TakeDamage(float damage)
    {
        if (_currentValue > 0)
        {
            _currentValue -= damage;


            if (_currentValue < 0)
            {
                Die();
            }

            DamageTaked?.Invoke(damage);
        }
    }

    private void Die() 
    {
        _isAlive = false;
        Died?.Invoke();
        _currentValue = 0;
    }
}
