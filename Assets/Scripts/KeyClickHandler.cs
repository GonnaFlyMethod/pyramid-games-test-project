using UnityEngine;

public class KeyClickHandler : MonoBehaviour
{
    GameObject _keyGO;

    private bool keyCollected = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _keyGO = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleClick()
    {
        DialogUI.Instance.ShowYesNoDialog("Take?", () => {
            keyCollected = true;
            _keyGO.SetActive(false);
        }, () => { });
    }
}
