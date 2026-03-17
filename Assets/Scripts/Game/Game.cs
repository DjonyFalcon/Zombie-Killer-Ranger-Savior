using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private ZombieSpawner _zombieSpawner;
    [SerializeField] private Health _surviorHealth;
    [SerializeField] private SaveZone _saveZone;

    private void OnEnable()
    {
        _surviorHealth.Died += Lose;
        _saveZone.SurviorArrived += Win;
    }

    private void OnDisable()
    {
        _surviorHealth.Died -= Lose;
        _saveZone.SurviorArrived -= Win; 
    }

    private void Lose() 
    {
        Debug.Log("Win");
    }

    private void Win() 
    {
        Debug.Log("Win");    
    }
}
