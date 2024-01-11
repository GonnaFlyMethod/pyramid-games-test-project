using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem Instance { get; private set; }
    
    private bool _isKeyCollected = false;

    private void Awake()
    {
        Instance = this;
    }

    public void CollectKey()
    {
        _isKeyCollected = true;
    }

    public bool IsKeyCollected()
    {
        return _isKeyCollected;
    }
}
