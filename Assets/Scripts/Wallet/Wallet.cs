using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private float _value;

    public event Action<float> ValueChanged;

    public void InceaseValue() 
    {
        ValueChanged?.Invoke(_value);
    }

    public void DecreaaseValue() 
    {
        ValueChanged?.Invoke(_value);
    }
}