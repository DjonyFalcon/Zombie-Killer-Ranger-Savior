using System;
using UnityEngine;

public class SaveZone : MonoBehaviour
{
    public event Action SurviorArrived;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision != null && collision.collider.TryGetComponent(out Survior survior))
        {
            SurviorArrived?.Invoke();
        }
    }
}
