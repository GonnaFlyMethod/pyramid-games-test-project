using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private Transform _centerPoint;

    // Update is called once per frame
    private void Update()
    {
        Vector3 _movementRaw = InputSystem.Instance.GetMovementInput();

        if (DialogUI.Instance.isPlayerInDialog())
        {
            return;
        }

        Vector3 camFinalMovement = _centerPoint.transform.right * _movementRaw.x +
                                    _centerPoint.transform.forward * _movementRaw.y; 
                                    ;
        _centerPoint.transform.position += camFinalMovement * _movementSpeed * Time.deltaTime;
    }
}
