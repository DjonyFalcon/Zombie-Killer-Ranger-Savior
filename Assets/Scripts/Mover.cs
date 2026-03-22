using System;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _minDistanceToTarget = 0.1f;

    public event Action EnoughClosed;

    public void MoveTo(Vector3 targetPosition, Transform transform, Rigidbody rigidbody)
    {
        if (transform.position.IsEnoughClose(targetPosition, _minDistanceToTarget) == false)
        {
            Vector3 direction = targetPosition - transform.position;

            direction = direction.normalized;
            rigidbody.velocity = direction * _speed * Time.deltaTime;
            transform.LookAt(targetPosition);
        }
        else 
        {
            EnoughClosed?.Invoke();
            StopMoving(rigidbody);
        }
    }

    public void StopMoving(Rigidbody rigidbody) 
    {
        rigidbody.velocity = Vector3.zero;
    }
}
