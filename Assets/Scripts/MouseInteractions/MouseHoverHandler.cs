using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHoverHandler : MonoBehaviour
{
    [SerializeField] private RaycastingFromCamera _raycastFromCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        Collider? col = _raycastFromCamera.PerformRaycastFromCamera();
    
        if (col != null)
        {
            GameObject go = col.gameObject;
            switch (go.tag)
            {
                //case "Table":
                    //go.GetComponent<Renderer>().material.color = Color.white;
                    //break;
            }
        }
    }
}
