using System.Collections;
using UnityEngine;

public class SpawnPointActivator : MonoBehaviour
{
    [SerializeField] private float _sphereRadius = 20f;
    [SerializeField] private float ActivationDelayTime = 2f;
    [SerializeField] private LayerMask _spanwPointMask;

    private WaitForSeconds _waitForSeconds;
    private Transform _transform;
    private Coroutine _coroutine;

    private int _maxActivationCount = 1000;

    public float SpehreRadius => _sphereRadius;

    private void Awake()
    {
        _transform = transform;
        _waitForSeconds = new WaitForSeconds(ActivationDelayTime);
        StartActivatingPoints();
    }

    public void StartActivatingPoints()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ActivatePoints());
    }

    public void StopActivatingPoints()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private IEnumerator ActivatePoints()
    {
        for (int i = 0; i < _maxActivationCount; i++)
        {
            yield return _waitForSeconds;

            Collider[] colliders = Physics.OverlapSphere(_transform.position, _sphereRadius, _spanwPointMask);

            foreach (Collider collider in colliders)
            {
                if (collider.TryGetComponent(out ZombieSpawnPoint zombieSpawnPoint))
                {
                        zombieSpawnPoint.Activate();
                }
            }
        }
    }
}
