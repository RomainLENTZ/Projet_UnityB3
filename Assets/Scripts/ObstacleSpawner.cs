using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoint;
    [SerializeField] GameObject[] obstaclePrefabs;

    [Header("Timers")]
    [SerializeField] float timeToSpawn = 2;
    [SerializeField] float timeIntervall = 2;
    [SerializeField] int itemRarity = 10;
    [SerializeField] float timeIntervalIncrease = 0.1f;
    [SerializeField] float minTimeBetweenSpawns = 1f;


    void Update()
    {
        if(Time.time > timeToSpawn && Time.time - timeToSpawn > minTimeBetweenSpawns){
            SpawnObstacle();
            timeToSpawn = Time.time + timeIntervall;
            timeIntervall -= timeIntervalIncrease;
            timeIntervall = Mathf.Clamp(timeIntervall, 0.5f, 3);
        }
    }

    void SpawnObstacle(){
        int randomIndex = Random.Range(0, spawnPoint.Length);

        for( int i = 0; i < spawnPoint.Length; i++ ){
            if( randomIndex != i ){
                if(InvicibilityItemShouldSpawn()){
                    Instantiate(obstaclePrefabs[1], spawnPoint[i].position, Quaternion.identity);
                }
                else{
                    Instantiate(obstaclePrefabs[0], new Vector3(spawnPoint[i].position.x, spawnPoint[i].position.y, spawnPoint[i].position.z) , Quaternion.identity);
                }
            }
        }
    }

    bool InvicibilityItemShouldSpawn(){
        int randomRarityItem = Random.Range(0, itemRarity);
        return randomRarityItem == 1;
    }
}
