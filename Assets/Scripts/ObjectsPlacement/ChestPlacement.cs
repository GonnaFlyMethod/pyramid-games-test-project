using System.Collections.Generic;
using UnityEngine;

public class ChestPlacement : MonoBehaviour
{
    [SerializeField] private List<Transform> _chestSpawnPoints;
    [SerializeField] private GameObject _chestPrefab;
    
    private void Awake()
    {
        int randomIndex = Random.Range(0, _chestSpawnPoints.Count);
        Transform pickedSpawnPoint = _chestSpawnPoints[randomIndex];

        Instantiate(_chestPrefab, pickedSpawnPoint);
    }
}
