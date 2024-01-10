using UnityEngine;

public class ExitDoorClickHandler : MonoBehaviour
{
    public void HandleClick()
    {
        if (InventorySystem.Instance.IsKeyCollected())
        {
            DialogUI.Instance.ShowYesNoDialog("Open", () =>
            {
                GameManager.Instance.GameOver();
            }, () => { });

            return;
        }

        DialogUI.Instance.ShowMessageOnlyDialog("You need a key!", () => { });
    }
}
