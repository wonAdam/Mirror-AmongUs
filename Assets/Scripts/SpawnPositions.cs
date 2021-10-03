using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPositions : MonoBehaviour
{
    [SerializeField] private List<Transform> positions;

    private int index;

    public Vector3 GetSpawnPosition()
    {
        Vector3 pos = positions[index++].position;
        if(index >= positions.Count)
        {
            index = 0;
        }
        return pos;
    }
}
