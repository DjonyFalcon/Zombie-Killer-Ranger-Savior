using UnityEngine;

public class ZombieAnimatorHandler : MonoBehaviour
{
    private const string Die = nameof(Die);
    private const string Attack = nameof(Attack);

    [SerializeField] private Animator _animator;

    private readonly int _dieTrigger = Animator.StringToHash(Die);
    private readonly int _attackTrigger = Animator.StringToHash(Attack);

    public void PlayDeathAnimation() 
    {
        _animator.SetTrigger(_dieTrigger);
    }

    public void PlayAttackAnimation() 
    {
        _animator.SetTrigger(_attackTrigger);   
    }
}
