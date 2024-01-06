using UnityEngine;

enum CamPosition {
    Up = 0, Right = 1, Buttom = 2, Left = 3
}

enum RotationDirection
{
    Left, Right
}

public class CameraRotation : MonoBehaviour
{

    [SerializeField] private float _rotationSpeed;
    [SerializeField] private Transform _centerPoint;

    private CamPosition _camCurrentPos;
    private CamPosition _camNewPos;

    private float _yRotation = 0;
    private bool _isRotating = false;

    // Start is called before the first frame update
    private void Start()
    {
        _camCurrentPos = CamPosition.Buttom;
        _camNewPos = CamPosition.Buttom;

        _centerPoint.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
    }

    private void Update()
    {
        if (_camCurrentPos != _camNewPos)
        {
            Quaternion quaternionRotation = new Quaternion();
            quaternionRotation = Quaternion.AngleAxis(_yRotation, Vector3.up);

            _centerPoint.transform.rotation = Quaternion.RotateTowards(
                _centerPoint.transform.rotation, quaternionRotation, _rotationSpeed * Time.deltaTime);

            if (quaternionRotation.eulerAngles.y == _centerPoint.eulerAngles.y)
            {
                _centerPoint.transform.rotation = quaternionRotation;
                _camCurrentPos = _camNewPos;
                _isRotating = false;

                if (_camCurrentPos == CamPosition.Buttom)
                {
                    _yRotation = 0;
                }
            }
        }
    }

    public void RotateCameraLeft()
    {
        if (_camCurrentPos == _camNewPos)
        {
            _isRotating = true;
            SetAppropriateCamPos(RotationDirection.Left);
        }
    }

    public void RotateCameraRight()
    {
        if (_camCurrentPos == _camNewPos)
        {
            _isRotating = true;
            SetAppropriateCamPos(RotationDirection.Right);
        }
    }

    private void SetAppropriateCamPos(RotationDirection rotationDirection)
    {
        // Left Rotation

        if (_camNewPos == CamPosition.Up && rotationDirection == RotationDirection.Left)
        {
            _camNewPos = CamPosition.Right;
            _yRotation += 90;
            return;
        }

        if (_camNewPos == CamPosition.Right && rotationDirection == RotationDirection.Left)
        {
            _camNewPos = CamPosition.Buttom;
            _yRotation += 90;
            return;
        }

        if (_camNewPos == CamPosition.Buttom && rotationDirection == RotationDirection.Left)
        {
            _yRotation += 90;
            _camNewPos = CamPosition.Left;
            return;
        }

        if (_camNewPos == CamPosition.Left && rotationDirection == RotationDirection.Left)
        {
            _yRotation += 90;
            _camNewPos = CamPosition.Up;
            return;
        }

        // Right Rotation

        if (_camNewPos == CamPosition.Up && rotationDirection == RotationDirection.Right)
        {
            _yRotation -= 90;
            _camNewPos = CamPosition.Left;
            return;
        }

        if (_camNewPos == CamPosition.Right && rotationDirection == RotationDirection.Right)
        {
            _yRotation -= 90;
            _camNewPos = CamPosition.Up;
            return;
        }

        if (_camNewPos == CamPosition.Buttom && rotationDirection == RotationDirection.Right)
        {
            _yRotation -= 90;
            _camNewPos = CamPosition.Right;
            return;
        }

        if (_camNewPos == CamPosition.Left && rotationDirection == RotationDirection.Right)
        {
            _yRotation -= 90;
            _camNewPos = CamPosition.Buttom;
            return;
        }
    }

    public bool isRotating()
    {
        return _isRotating;
    }
}
