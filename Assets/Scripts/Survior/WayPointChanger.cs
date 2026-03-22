using System.Collections.Generic;
using UnityEngine;

public class WayPointChanger : MonoBehaviour
{
    [SerializeField] private IReadOnlyList<WayPoint> _wayPoints;
    [SerializeField] private DistanceMeter _distanceMeter;

    private WayPoint _currentWayPoint;
    private int _currentWayPointIndex;

    public Vector3 CurrentWayPointPosition => _currentWayPoint.Position;

    private void OnEnable()
    {
        _distanceMeter.IsGotClose += ChangeWayPoint;   
    }

    private void OnDisable()
    {
        _distanceMeter.IsGotClose -= ChangeWayPoint;   
    }

    public void Measure() 
    {
        _distanceMeter.Measure();
    }

    public void SetWayPointsList(IReadOnlyList<WayPoint> wayPoints)
    {
        _wayPoints = wayPoints;
        _currentWayPointIndex = 0;
        _currentWayPoint = _wayPoints[_currentWayPointIndex];
        _distanceMeter.SetTarget(_currentWayPoint.transform);
    }

    private void ChangeWayPoint()
    {
        _currentWayPointIndex += 1;

        if (_currentWayPointIndex < _wayPoints.Count)
        {
            _currentWayPoint = _wayPoints[_currentWayPointIndex];
            _distanceMeter.SetTarget(_currentWayPoint.transform);
        }
    }
}
