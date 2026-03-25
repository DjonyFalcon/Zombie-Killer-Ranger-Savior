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
    public event Action<float> ValueChanged;

    public bool IsAlive => _isAlive;
    public float MaxValue => _maxValue;
    public float CurrentValue => _currentValue;

    private void Awake()
    {
        Rise();
    }

    public void Rise()
    {
        _isAlive = true;
        _currentValue = _maxValue;
        ValueChanged?.Invoke(_currentValue);
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
            ValueChanged?.Invoke(_currentValue);
        }
    }

    private void Die() 
    {
        _isAlive = false;
        Died?.Invoke();
        ValueChanged?.Invoke(_currentValue);
        _currentValue = 0;
    }
}
