using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public static InputSystem Instance { get; private set; }
    
    [SerializeField] private PlayerInputActions _playerInputActions;
    
    private void Awake()
    {
        Instance = this;
        _playerInputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        _playerInputActions.Enable();
    }

    private void OnDisable()
    {
        _playerInputActions.Disable();
    }

    public Vector2 GetMovementInput()
    {
        return _playerInputActions.Player.Movement.ReadValue<Vector2>();
    }

    public float GetRotationInput()
    {
        return _playerInputActions.Player.Rotation.ReadValue<float>();
    }
}
