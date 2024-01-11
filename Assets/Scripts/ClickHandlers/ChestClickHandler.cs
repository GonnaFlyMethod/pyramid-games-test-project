using UnityEngine;
using UnityEngine.EventSystems;

public class ChestClickHandler : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Animator _animatorChest;
    [SerializeField] private Animator _animatorKey;

    private bool _opened = false;

    public void OnPointerClick(PointerEventData _)
    {
        if (_opened)
        {
            return;
        }

        DialogUI.Instance.ShowYesNoDialog("Open?", () => {
            _opened = true;

            SFXSystem.Instance.PlayChestOpenSFX();

            _animatorChest.SetBool(Global.Constants.ChestAnimator.openChestTrigger, true);
            _animatorKey.SetBool(Global.Constants.ChestAnimator.isKeyShowing, true);

        }, () => {});
    }
}
