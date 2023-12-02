using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int spawnRate;

    void enemySpawn()
    {
        float randX = Random.Range(1f, 3f);
        float randZ = Random.Range(1f, 3f);
        Vector3 pos = transform.position;
        Instantiate(enemyPrefab, new Vector3(pos.x + randX, pos.y, pos.z + randZ), Quaternion.identity);
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("enemySpawn", spawnRate, spawnRate);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
