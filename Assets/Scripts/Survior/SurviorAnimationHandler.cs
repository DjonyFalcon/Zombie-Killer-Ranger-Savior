using UnityEngine;

public class SurviorAnimationHandler : MonoBehaviour
{
    private const string Die = nameof(Die);

    [SerializeField] private Animator _animator;

    private readonly int _dieTrigger = Animator.StringToHash(Die);

    public void PlayeDeathAnimation() 
    {
        _animator.SetTrigger(_dieTrigger);
    }
}
