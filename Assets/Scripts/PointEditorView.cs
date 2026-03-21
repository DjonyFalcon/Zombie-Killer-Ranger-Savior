using UnityEngine;

public class PointEditorView : MonoBehaviour
{
    [SerializeField] private Color _color = Color.black;
    [SerializeField] private float _radius = 1f;

    private void OnDrawGizmos()
    {
        Gizmos.color = _color;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
