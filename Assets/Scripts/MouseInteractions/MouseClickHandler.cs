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
                    case Global.Constants.Tags.chest:
                        ChestClickHandler clickHandler = go.GetComponent<ChestClickHandler>();

                        clickHandler.HandleClick();
                        break;
                    case Global.Constants.Tags.key:
                        KeyClickHandler keyClickHandler = go.GetComponent<KeyClickHandler>();

                        keyClickHandler.HandleClick();
                        break;
                    case Global.Constants.Tags.exitDoor:
                        ExitDoorClickHandler exitDoorClickHandler = go.GetComponent<ExitDoorClickHandler>();

                        exitDoorClickHandler.HandleClick();
                        break;
                }
            }
        }
    }
}
