using System;
using UnityEngine;

public class DistanceMeter : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private float _minDistance;

    private Transform _target;
    public event Action IsGotClose;

    public void SetTarget(Transform target) 
    {
        _target = target;    
    }

    public void Measure() 
    {
        if (_transform.position.IsEnoughClose(_target.position,_minDistance)) 
        {
            IsGotClose?.Invoke();
        }
    }
}
