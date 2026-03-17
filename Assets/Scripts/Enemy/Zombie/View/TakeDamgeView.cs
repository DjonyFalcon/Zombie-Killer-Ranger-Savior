using System.Collections;
using TMPro;
using UnityEngine;

public class TakeDamgeView : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 0.5f;
    [SerializeField] private Health _health;
    [SerializeField] private TextMeshProUGUI _damgeText;

    private WaitForSeconds _waitForSeconds;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _health.DamageTaked += ShowText;
    }

    private void OnDisable()
    {
        _health.DamageTaked -= ShowText;
    }

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(_lifeTime);
        _damgeText.enabled = false;
    }

    private void ShowText(float damage)
    {
        if (_coroutine != null)
            return;

        _damgeText.text = damage.ToString();
        _damgeText.enabled = true;
        _coroutine = StartCoroutine(HideText());
    }

    private IEnumerator HideText()
    {
        yield return _waitForSeconds;

        _damgeText.enabled = false;
        _coroutine = null;
    }
}