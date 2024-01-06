using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSyncRotationY : MonoBehaviour
{
    [SerializeField] private Camera _cam;

    // Update is called once per frame
    void Update()
    {
        float yCoordOfCamera = _cam.transform.eulerAngles.y;

        Vector3 rotationToSet = new Vector3(
            transform.eulerAngles.x, yCoordOfCamera, transform.eulerAngles.z);
        transform.eulerAngles = rotationToSet;
    }
}
