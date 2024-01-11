using UnityEngine;
using UnityEngine.EventSystems;

public class KeyClickHandler : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData _)
    {
        DialogUI.Instance.ShowYesNoDialog("Take?", () => {
            InventorySystem.Instance.CollectKey();

            SFXSystem.Instance.PlayKeyCollectSFX();

            gameObject.SetActive(false);
        }, () => { Debug.Log("Key click");  });
    }
}
