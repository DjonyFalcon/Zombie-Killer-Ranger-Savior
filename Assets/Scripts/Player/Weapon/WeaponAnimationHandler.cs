using UnityEngine;

public class WeaponAnimationHandler : MonoBehaviour
{
    private const string Shoot = nameof(Shoot);

    [SerializeField] private Animator _animator;

    private readonly int _shootTrigger = Animator.StringToHash(Shoot);

    public void PlayShootAnimation() 
    {
        _animator.SetTrigger(_shootTrigger);
    }
}
