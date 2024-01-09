using UnityEngine;

public class GateSpawnRequirements : MonoBehaviour
{
    [SerializeField] private GameObject[] _wallsToDisable;

    public GameObject[] GetWallsToDisable()
    {
        return _wallsToDisable;
    }
}
