using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem Instance { get; private set; }
    
    private bool _isKeyCollected = false;

    // Start is called before the first frame update
    void Awake()
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
