using System.Collections.Generic;
using UnityEngine;

public class ExitGatePlacement : MonoBehaviour
{
    [SerializeField] private GameObject _exitGatePrefab;

    [SerializeField] private List<GameObject> _exitGateSpawnPoints;
    private List<int> _occupiedIndexes;

    private void Awake()
    {
        _occupiedIndexes = new List<int>();

        int numOfExitGatesInGame = Random.Range(
            (_exitGateSpawnPoints.Count - 1) / 2, _exitGateSpawnPoints.Count);

        for (int i = 0; i <= numOfExitGatesInGame; i++){

            int randomIndex;

            while (true)
            {
                randomIndex = Random.Range(0, _exitGateSpawnPoints.Count);

                if (_occupiedIndexes.IndexOf(randomIndex) != -1){
                    continue;
                }

                _occupiedIndexes.Add(randomIndex);
                break;
            }

            GameObject pickedPoint = _exitGateSpawnPoints[randomIndex];

            ExitGateSpawnRequirements spawnReqs = pickedPoint.GetComponent<ExitGateSpawnRequirements>();
            
            GameObject wallToDisable = spawnReqs.GetWallToDisable();
            wallToDisable.SetActive(false);

            Instantiate(_exitGatePrefab, pickedPoint.transform);
        }
    }
}
