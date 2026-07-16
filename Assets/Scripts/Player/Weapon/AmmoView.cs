using TMPro;
using UnityEngine;

public class AmmoView : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private TextMeshProUGUI _ammoText;

    private void Awake()
    {
        _ammoText.text = _weapon.CurrentAmmo.ToString();    
    }

    private void OnEnable()
    {
        _weapon.AmmoChanged += ChangeAmmo;
    }

    private void OnDisable()
    {
        _weapon.AmmoChanged -= ChangeAmmo;
    }

    private void ChangeAmmo(int currentAmmo) 
    {
       _ammoText.text = currentAmmo.ToString();
    }
}
