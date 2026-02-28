using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float enemyCount;
    public int enemyAmount = 3;
    private float spawnRange = 9;
    public GameObject enemyPrefab;
    public GameObject powerPrefab;
    // Start is called before the first frame update
    void Start()
    {


        Wave();
        
        
    }
    void Wave()
    {

        for (int i = 0; i < enemyAmount; i++)
        {
            Instantiate(enemyPrefab, Randomsumshi(), enemyPrefab.transform.rotation);
        }

    }
    void powerWave()
    {
        int powerRandom = Random.Range(1, 3);
        if(powerRandom == 1)
        {
            Instantiate(powerPrefab, Randomsumshi(), enemyPrefab.transform.rotation);
        }

 
    }
    // Update is called once per frame
    void Update()
    {  }

    public void countEnemy()
    {
        int enemyCount = FindObjectsOfType<Enemymovement>().Length;
        if (enemyCount == 1)
        {
            enemyAmount++;
            Wave();
            GameObject powerupExist = GameObject.FindGameObjectWithTag("Power");
            if (powerupExist is null)
            {
                powerWave();
            }
        }
    }

private Vector3 Randomsumshi()
    {

        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 RandomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return RandomPos;
    }
}
