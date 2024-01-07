using UnityEngine;
using UnityEngine.InputSystem;
using Global;

public class CameraMouseClickHandler : MonoBehaviour
{
    [SerializeField] private Camera _cam;

    [SerializeField] private ChestClickHandler _chestClickHandler;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Clicked(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Ray ray = _cam.ScreenPointToRay(mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    switch (hit.collider.tag){
                        case Global.Constants.Tags.chest:
                            _chestClickHandler.HandleClick();
                            break;
                    }


                    Debug.Log(hit.collider.gameObject.name);
                }
            }
        }
    }
}
