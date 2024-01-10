using UnityEngine;

public class ChestClickHandler : MonoBehaviour
{
    [SerializeField] private Animator _animatorChest;
    [SerializeField] private Animator _animatorKey;

    private bool _opened = false;

    public void HandleClick()
    {
        if (_opened) {
            return;
        }

        DialogUI.Instance.ShowYesNoDialog("Open?", () => {
            _opened = true;

            _animatorChest.SetBool(GlobalConstants.ChestAnimator.openChestTrigger, true);
            _animatorKey.SetBool(GlobalConstants.ChestAnimator.isKeyShowing, true);

        }, () => { });
    }

}
