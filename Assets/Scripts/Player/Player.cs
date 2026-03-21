using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [SerializeField] private Aimer _aimer;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private WeaponAnimationHandler _weaponAnimationHandler;
    [SerializeField] private HelicopterPositioner _helicopterPositioner;
    [SerializeField] private Transform _playerTransform;


    [SerializeField]private InputReader _inputReader;

    private void OnEnable()
    {
        _weapon.Shooted += _weaponAnimationHandler.PlayShootAnimation;
    }

    private void OnDisable()
    {
        _weapon.Shooted -= _weaponAnimationHandler.PlayShootAnimation;
    }

    private void FixedUpdate()
    {
        _helicopterPositioner.Move(_playerTransform);
    }

    private void Update()
    {
        _aimer.Aim(_inputReader.ScreenPointPosition);
        _weapon.Shooting();
    }

    [Inject]
    private void Construct(InputReader inputReader)
    {
        _inputReader = inputReader;
    }
}