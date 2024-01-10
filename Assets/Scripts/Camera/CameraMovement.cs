using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private Transform _centerPoint;

    private Vector3 _rawDirection;
    private float _currentX;
    private float _currentZ;


    private void Start()
    {
        _currentZ = _currentX = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        if (DialogUI.Instance.isPlayerInDialog())
        {
            return;
        }

        _rawDirection.x += _currentX;
        _rawDirection.z += _currentZ;

        Vector3 finalDirection = _centerPoint.transform.forward * _rawDirection.z + _centerPoint.transform.right * _rawDirection.x;
        _centerPoint.transform.position += finalDirection * _movementSpeed * Time.deltaTime;

        _rawDirection = Vector3.zero;
    }

    public void MoveForward(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _currentZ = 1.0f;
        }
        else if (context.canceled)
        {
            _currentZ = 0;
        }
    }

    public void MoveBackwards(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _currentZ = -1.0f;
        }
        else if (context.canceled)
        {
            _currentZ = 0;
        }
    }

    public void MoveRight(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _currentX = 1.0f;
        }
        else if (context.canceled)
        {
            _currentX = 0;
        }
    }

    public void MoveLeft(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _currentX = -1.0f;
        }
        else if (context.canceled)
        {
            _currentX = 0;
        }
    }
}
