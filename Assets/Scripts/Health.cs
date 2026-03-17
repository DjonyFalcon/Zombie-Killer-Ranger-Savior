using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxValue = 100;

    private float _currentValue;
    private bool _isInvulnerable;

    public event Action Died;
    public event Action<float> DamageTaked;

    private void Awake()
    {
        _currentValue = _maxValue;
        DisableInvulnerability();
    }

    public void EnableInvulnerability() 
    {
        _isInvulnerable = true;
    }

    public void DisableInvulnerability()
    {
        _isInvulnerable = false;
    }

    public void TakeDamage(float damage)
    {
        if (_isInvulnerable != true)
        {
            if (_currentValue > 0)
            {
                _currentValue -= damage;


                if (_currentValue < 0)
                {
                    _currentValue = 0;
                    Died?.Invoke();
                }

                DamageTaked?.Invoke(damage);

                Debug.Log(gameObject.name + " Health : " + _currentValue);
            }
        }
    }
}
