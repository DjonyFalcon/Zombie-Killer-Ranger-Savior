using UnityEngine;

public class BodyRoator : MonoBehaviour
{
    [SerializeField] private Transform _aimPoint;

    public void SetAimPoint(Vector3 aimPoint)
    {
        _aimPoint.position = aimPoint;
    }
}