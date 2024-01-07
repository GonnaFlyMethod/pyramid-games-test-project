using UnityEngine;

public class KeyClickHandler : MonoBehaviour
{
    GameObject parentGO;

    private bool keyCollected = false;
    
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
        keyCollected = true;
        parentGO.SetActive(false);
    }
}
