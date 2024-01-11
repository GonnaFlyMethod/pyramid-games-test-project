using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private PlayerInputActions _playerInputActions;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private Transform _centerPoint;

    private void Awake()
    {
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

    // Update is called once per frame
    private void Update()
    {
        if (DialogUI.Instance.isPlayerInDialog())
        {
            return;
        }

        Vector2 camMovementRaw = _playerInputActions.Player.Movement.ReadValue<Vector2>();

        Vector3 camFinalMovement = _centerPoint.transform.forward * camMovementRaw.y + _centerPoint.transform.right * camMovementRaw.x;
        _centerPoint.transform.position += camFinalMovement * _movementSpeed * Time.deltaTime;
    }
}
