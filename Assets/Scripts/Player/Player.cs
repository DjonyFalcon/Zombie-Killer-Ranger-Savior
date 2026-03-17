using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private InputReader _inputReader;
        [SerializeField] private Aimer _aimer;
        [SerializeField] private Weapon _weapon;
        [SerializeField] private WeaponAnimationHandler _weaponAnimationHandler;

        private void OnEnable()
        {
            _weapon.Shooted += _weaponAnimationHandler.PlayShootAnimation;
        }

        private void OnDisable()
        {
            _weapon.Shooted -= _weaponAnimationHandler.PlayShootAnimation;
        }

        private void Update()
        {
            _aimer.Aim(_inputReader.ScreenPointPosition);
            _weapon.Shooting();
        }
    }
}
