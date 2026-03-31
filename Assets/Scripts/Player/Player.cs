using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [Inject] private InputReader _inputReader;

    [SerializeField] private Aimer _aimer;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private WeaponAnimationHandler _weaponAnimationHandler;
    [SerializeField] private HelicopterPositioner _helicopterPositioner;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private BodyRoator _bodyRoator;
    [SerializeField] private WeaponAudioPlayer _weaponAudioPlayer;

    private void OnEnable()
    {
        _weapon.Shooted += _weaponAudioPlayer.PlayShootClip;
        _weapon.StartReloading += _weaponAudioPlayer.PlayRealoadClip;
        _weapon.Shooted += _weaponAnimationHandler.PlayShootAnimation;
    }

    private void OnDisable()
    {
        _weapon.Shooted -= _weaponAudioPlayer.PlayShootClip;
        _weapon.StartReloading -= _weaponAudioPlayer.PlayRealoadClip;
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
        _bodyRoator.SetAimPoint(_weapon.AimPoint);
    }
}