using UnityEngine;

public class ChestClickHandler : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Animation _keyAnimation;

    public void HandleClick()
    {
        if (!_animator.GetBool(Global.Constants.ChestAnimator.openChestTrigger)){
            _animator.SetBool(Global.Constants.ChestAnimator.openChestTrigger, true);
        }
    }

}
