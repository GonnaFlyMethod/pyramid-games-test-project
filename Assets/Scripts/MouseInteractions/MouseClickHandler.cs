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

                        //clickHandler.HandleClick();
                        break;
                    case Global.Constants.Tags.key:
                        //KeyClickHandler2 keyClickHandler = go.GetComponent<KeyClickHandler2>();

                        //keyClickHandler.HandleClick();
                        //break;
                    case Global.Constants.Tags.exitDoor:
                        //ExitDoorClickHandler1 exitDoorClickHandler = go.GetComponent<ExitDoorClickHandler1>();

                        //exitDoorClickHandler.HandleClick();
                        break;
                }
            }
        }
    }
}
