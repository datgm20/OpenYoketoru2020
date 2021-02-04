using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefab = null;
    [SerializeField]
    int spawnCount = 10;

    void Start()
    {
        for (var i=0;i<spawnCount;i++)
        {
            Instantiate(prefab);
        }
    }
}
