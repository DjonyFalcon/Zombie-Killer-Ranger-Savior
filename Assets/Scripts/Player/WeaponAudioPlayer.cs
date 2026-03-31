using UnityEngine;

public class WeaponAudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip _pistolShootClip;
    [SerializeField] private AudioClip _rifleShootClip;
    [SerializeField] private AudioClip _realoadClip;
    [SerializeField] private AudioSource _shootAudioSource;
    [SerializeField] private AudioSource _reloadAudioSource;

    private void Awake()
    {
        _shootAudioSource.clip = _pistolShootClip;
        _reloadAudioSource.clip = _realoadClip;
    }

    public void SchangeClip() 
    {
    
    }

    public void PlayShootClip() 
    {
        _shootAudioSource.Play();   
    }

    public void PlayRealoadClip() 
    {
        _reloadAudioSource.Play();
    }
}
