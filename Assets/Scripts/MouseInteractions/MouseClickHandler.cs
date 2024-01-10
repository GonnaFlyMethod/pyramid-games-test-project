using UnityEngine;
using UnityEngine.InputSystem;

public class MouseClickHandler : MonoBehaviour
{
    [SerializeField] private RaycastingFromCamera _raycastFromCamera;

    public void Clicked(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Collider? col = _raycastFromCamera.PerformRaycastFromCamera();

            if (col != null)
            {
                GameObject go = col.gameObject;

                switch (go.tag)
                {
                    case GlobalConstants.Tags.chest:
                        ChestClickHandler clickHandler = go.GetComponent<ChestClickHandler>();

                        clickHandler.HandleClick();
                        break;
                    case GlobalConstants.Tags.key:
                        KeyClickHandler keyClickHandler = go.GetComponent<KeyClickHandler>();

                        keyClickHandler.HandleClick();
                        break;
                    case GlobalConstants.Tags.exitDoor:
                        ExitDoorClickHandler exitDoorClickHandler = go.GetComponent<ExitDoorClickHandler>();

                        exitDoorClickHandler.HandleClick();
                        break;
                }
            }
        }
    }
}
