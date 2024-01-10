using UnityEngine;

public class KeyClickHandler : MonoBehaviour
{
    GameObject _keyGO;
    
    // Start is called before the first frame update
    private void Start()
    {
        _keyGO = transform.parent.gameObject;
    }

    public void HandleClick()
    {
        DialogUI.Instance.ShowYesNoDialog("Take?", () => {
            InventorySystem.Instance.CollectKey();
            
            _keyGO.SetActive(false);
        }, () => { });
    }
}
