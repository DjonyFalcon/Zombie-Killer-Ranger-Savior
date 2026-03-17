using UnityEngine;

public class InputReader : MonoBehaviour
{
    private InputActions _inputActions;

    private Vector2 screenPointPosition;

    public Vector2 ScreenPointPosition => screenPointPosition;

    private void Awake()
    {
        _inputActions = new InputActions();
    }

    private void OnEnable()
    {
        _inputActions.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }

    public void Update()
    {
        screenPointPosition = _inputActions.Weapon—ontrol.Aiming.ReadValue<Vector2>();
    }
}
