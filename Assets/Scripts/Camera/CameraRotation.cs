using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private Transform _centerPoint;

    private void Update()
    {
        float rotationInput = InputSystem.Instance.GetRotationInput();
        _centerPoint.eulerAngles += new Vector3(0, rotationInput * _rotationSpeed * Time.deltaTime, 0);
    }
}
