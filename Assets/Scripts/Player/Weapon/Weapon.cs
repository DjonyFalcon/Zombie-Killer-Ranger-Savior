using System;
using System.Collections;
using UnityEngine;

namespace Player
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Transform _shootingPosition;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private int _maxAmmo = 15;
        [SerializeField] private float _damage = 10;
        [SerializeField] private float _reloadTime = 3f;
        [SerializeField] private float _timeBetweenShots = 1f;
        [SerializeField] private Transform _weaponTransform;

        private WaitForSeconds _waitReloadTime;
        private WaitForSeconds _waitBetweenShots;
  
        private Coroutine _reloadCoroutine;

        private int _currentAmmo;

        private bool _isAvailiable;

        public event Action<int> AmmoChanged;
        public event Action Shooted;

        private void Awake()
        {
            _isAvailiable = true;
            _waitReloadTime = new WaitForSeconds(_reloadTime);
            _waitBetweenShots = new WaitForSeconds(_timeBetweenShots);
            _currentAmmo = _maxAmmo;
        }

        public void Shooting() 
        {
            Ray ray = new Ray(_shootingPosition.position, _shootingPosition.forward);

            if (Physics.Raycast(ray, out RaycastHit hitInfo,Mathf.Infinity, _layerMask, QueryTriggerInteraction.Ignore))
            {
                _weaponTransform.LookAt(hitInfo.point);

                if (hitInfo.collider.TryGetComponent<IDamageable>(out IDamageable damageable))
                {
                    if (_currentAmmo > 0 && _isAvailiable)
                    {
                        Shooted?.Invoke();
                        _isAvailiable = false;
                        _currentAmmo--;
                        AmmoChanged?.Invoke(_currentAmmo);
                        damageable.TakeDamage(_damage);
                        StartCoroutine(DelayBetweenShoots());
                       
                    }
                    else if (_currentAmmo == 0 && _reloadCoroutine == null)
                    { 
                        _reloadCoroutine = StartCoroutine(Reload());
                    }
                }
            }
        }

        private IEnumerator DelayBetweenShoots() 
        {
            yield return _waitBetweenShots;

            _isAvailiable = true;
        }

        private IEnumerator Reload() 
        {
            yield return _waitReloadTime;

            _currentAmmo = _maxAmmo;
            AmmoChanged?.Invoke(_currentAmmo);
            _reloadCoroutine = null;
        }
    }
}