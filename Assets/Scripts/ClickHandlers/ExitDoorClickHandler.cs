using UnityEngine;

public class ExitDoorClickHandler : MonoBehaviour
{
    public void HandleClick()
    {
        if (InventorySystem.Instance.IsKeyCollected())
        {
            DialogUI.Instance.ShowYesNoDialog("Open", () =>
            {
                Debug.Log("Ending the game");
            }, () => { });

            return;
        }

        DialogUI.Instance.ShowMessageOnlyDialog("You need a key!", () => { });
    }
}
