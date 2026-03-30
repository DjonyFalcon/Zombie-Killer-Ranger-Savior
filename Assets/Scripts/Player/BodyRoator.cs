using UnityEngine;

public class BodyRoator : MonoBehaviour
{
    [SerializeField] private Animator _femaleAnimator;

    private Vector3 _target;

    public void SetTarget(Vector3 target)
    {
        _target = target;
    }

    private void OnAnimatorIK(int layerIndex)
    {
        _femaleAnimator.SetLookAtWeight(1f, 1f, 1f);
        _femaleAnimator.SetLookAtPosition(_target);

    }
}