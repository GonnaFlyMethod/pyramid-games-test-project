using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KeyClickHandler : MonoBehaviour, IPointerClickHandler
{
    GameObject _keyGO;

    // Start is called before the first frame update
    private void Start()
    {
        _keyGO = transform.parent.gameObject;
    }

    public void OnPointerClick(PointerEventData _)
    {
        DialogUI.Instance.ShowYesNoDialog("Take?", () => {
            InventorySystem.Instance.CollectKey();

            _keyGO.SetActive(false);
        }, () => { });
    }
}
