using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyClickHandler : MonoBehaviour
{
    GameObject parentGO;
    
    // Start is called before the first frame update
    void Start()
    {
        parentGO = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleClick()
    {
        Debug.Log("Handling click for key");
        Destroy(parentGO);
    }
}
