using UnityEngine;

public class ExitGateSpawnRequirements : MonoBehaviour
{
    [SerializeField] private GameObject _wallToDisable;

    public GameObject GetWallToDisable()
    {
        return _wallToDisable;
    }
}
