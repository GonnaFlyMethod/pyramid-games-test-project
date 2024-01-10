using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastingFromCamera : MonoBehaviour
{
    [SerializeField] private Camera _cam;

    public Collider? PerformRaycastFromCamera()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Ray ray = _cam.ScreenPointToRay(mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            return hit.collider;
        }

        return null;
    }
}
