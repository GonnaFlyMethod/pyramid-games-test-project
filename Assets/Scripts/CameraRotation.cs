using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

enum CamPosition {
    Up = 0, Right = 1, Buttom = 2, Left = 3
}

enum RotationDirection
{
    Left, Right
}

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private Transform _camHolder;
    [SerializeField] private Camera _cam;

    // Elements go in clock-wise order:
    // Up - index 0
    // Right - index 1
    // Buttom - index 2
    // Left - index 3
    [SerializeField] private List<Transform> _possibleCameraPositions;
    [SerializeField] private Transform _focusPointDuringRotation;
    [SerializeField] private float _rotationSpeed;

    private CamPosition _camCurrentPos;
    private CamPosition _camNewPos;

    // Start is called before the first frame update
    private void Start()
    {
        _camCurrentPos = CamPosition.Buttom;
        _camNewPos = CamPosition.Buttom;

        Transform camButtomPosTransform = _possibleCameraPositions[(int)CamPosition.Buttom];
        _cam.transform.position = camButtomPosTransform.position;

        LookAtFocusPoint();
    }

    private void Update()
    {
        if (_camCurrentPos != _camNewPos)
        {
            Vector3 targetPos = _possibleCameraPositions[(int)_camNewPos].transform.position;

            _cam.transform.position = Vector3.MoveTowards(
                _cam.transform.position, targetPos, _rotationSpeed * Time.deltaTime);

            LookAtFocusPoint();

            if (Vector3.Distance(_cam.transform.position, targetPos) <= 0)
            {
                _camCurrentPos = _camNewPos;
            }
        }
    }

    private void LookAtFocusPoint()
    {
        _cam.transform.rotation = Quaternion.LookRotation(
                _focusPointDuringRotation.position - _cam.transform.position, Vector3.up);
  
    }

    public void RotateCameraLeft()
    {
        if (_camCurrentPos == _camNewPos)
        {
            SetAppropriateCamPos(RotationDirection.Left);
        }
    }

    public void RotateCameraRight()
    {
        if (_camCurrentPos == _camNewPos)
        {
            SetAppropriateCamPos(RotationDirection.Right);
        }
    }

    private void SetAppropriateCamPos(RotationDirection rotationDirection)
    {
        // Left Rotation

        if (_camNewPos == CamPosition.Up && rotationDirection == RotationDirection.Left)
        {
            _camNewPos = CamPosition.Right;
            return;
        }

        if (_camNewPos == CamPosition.Right && rotationDirection == RotationDirection.Left)
        {
            _camNewPos = CamPosition.Buttom;
            return;
        }

        if (_camNewPos == CamPosition.Buttom && rotationDirection == RotationDirection.Left)
        {
            _camNewPos = _camNewPos = CamPosition.Left;
            return;
        }

        if (_camNewPos == CamPosition.Left && rotationDirection == RotationDirection.Left)
        {
            _camNewPos = _camNewPos = CamPosition.Up;
            return;
        }

        // Right Rotation

        if (_camNewPos == CamPosition.Up && rotationDirection == RotationDirection.Right)
        {
            _camNewPos = CamPosition.Left;
            return;
        }

        if (_camNewPos == CamPosition.Right && rotationDirection == RotationDirection.Right)
        {
            _camNewPos = CamPosition.Up;
            return;
        }

        if (_camNewPos == CamPosition.Buttom && rotationDirection == RotationDirection.Right)
        {
            _camNewPos = _camNewPos = CamPosition.Right;
            return;
        }

        if (_camNewPos == CamPosition.Left && rotationDirection == RotationDirection.Right)
        {
            _camNewPos = _camNewPos = CamPosition.Buttom;
            return;
        }
    }
}
