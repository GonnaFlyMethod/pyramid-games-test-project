using UnityEngine;
using UnityEngine.EventSystems;

public class ExitGateClickHandler : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData _)
    {
        if (InventorySystem.Instance.IsKeyCollected())
        {
            DialogUI.Instance.ShowYesNoDialog("Open?", () =>
            {
                GameManager.Instance.GameOver();
            }, () => { });

            return;
        }

        DialogUI.Instance.ShowMessageOnlyDialog("You need a key!", () => { });
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
