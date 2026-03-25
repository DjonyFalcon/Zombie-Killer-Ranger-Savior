using UnityEngine;

public class SpawnPointActivatorEditorVeiw : MonoBehaviour
{
    [SerializeField] private SpawnPointActivator _spawnPointActivator;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _spawnPointActivator.SpehreRadius);
    }
}
