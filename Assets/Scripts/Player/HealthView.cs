using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Health _health;
    [SerializeField] private float _smoothDecreseDuration = 0.5f;

    private Coroutine _coroutine;

    private void Start()
    {
        _healthSlider.maxValue = _health.MaxValue;
        _healthSlider.value = _health.CurrentValue;
    }

    private void OnEnable()
    {
        _health.ValueChanged += ChangeHealth;
    }

    private void OnDisable()
    {
        _health.ValueChanged -= ChangeHealth;
    }

    private void ChangeHealth(float value)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(ChangeSmoothly(value));
    }

    private IEnumerator ChangeSmoothly(float target)
    {
        float dealpsedTime = 0.0f;
        float prviosValue = _healthSlider.value;

        while (dealpsedTime < _smoothDecreseDuration)
        {
            dealpsedTime += Time.deltaTime;

            float normalazedTime = dealpsedTime / _smoothDecreseDuration;
            float intermindateValue = Mathf.Lerp(prviosValue, target, normalazedTime);

            _healthSlider.value = intermindateValue;

            yield return null;
        }
    }
}