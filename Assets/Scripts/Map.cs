using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private List<WayPoint> _surviorWayPoints;
    [SerializeField] private Transform _surviorSpawnPoint;
    [SerializeField] private Transform _helicopterSpawnPoint;

    public Vector3 SurviorSpawnPoint => _surviorSpawnPoint.position;
    public Vector3 HelicopterSpawnPoint => _helicopterSpawnPoint.position;
    
    public IReadOnlyList<WayPoint> WayPoints => _surviorWayPoints;
}
