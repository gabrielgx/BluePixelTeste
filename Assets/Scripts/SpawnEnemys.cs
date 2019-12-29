using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemys : MonoBehaviour
{

    public Transform[] portal;
    public GameObject[] enemy;
    float timeSpawn=3.0f;
    void Start()
    {
        InvokeRepeating("Spawn", timeSpawn, timeSpawn);
    }


    void Spawn()
    {
        int indice = Random.Range(0, portal.Length);
        Instantiate(enemy[indice], portal[indice].position, Quaternion.identity);
    }
}
