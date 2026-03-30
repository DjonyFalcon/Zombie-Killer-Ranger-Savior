using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartLevelButton : MonoBehaviour
{
    private const string GameSceneName = "GameScene";

    [SerializeField] private Button _playButton;

    private void OnEnable()
    {
        _playButton.onClick.AddListener(Play);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(Play);
    }

    private void Play() 
    {
        SceneManager.LoadScene(GameSceneName);
    }
}
