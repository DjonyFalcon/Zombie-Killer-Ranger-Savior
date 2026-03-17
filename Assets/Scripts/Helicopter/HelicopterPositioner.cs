using UnityEngine;
using Zenject;

public class HelicopterPositioner : MonoBehaviour
{
    private Transform _surviorTransform;

    private Transform _transform;
    private Vector3 _offset;

    [Inject]
    private void Construct(Survior survior) 
    {
        _surviorTransform = survior.transform;
    }

    private void Awake()
    {
        _transform = transform;
        _offset = transform.position;
    }
  
    private void FixedUpdate()
    {
        _transform.position = _surviorTransform.position + _offset;
        Rotate();
    }

    private void Rotate()
    {
        Vector3 direction = _surviorTransform.position - transform.position;
        Vector3 right = transform.right;

        direction = direction.normalized;
        direction = Vector3.ProjectOnPlane(direction, Vector3.up);

        float angel = Vector3.Angle(right, direction);

        Quaternion quaternion = Quaternion.AngleAxis(angel, Vector3.up);

        _transform.rotation *= quaternion; 
    }
}