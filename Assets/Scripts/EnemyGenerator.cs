using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public GameObject BossEnemyPrefab;

    private int random;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 2f, 1f);
        Invoke("BossSpawn", 4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        Vector3 spawnPositon = new Vector3(
            Random.Range(-2.9f,2.9f),
            transform.position.y,
            transform.position.z);

        Instantiate(EnemyPrefab, spawnPositon, transform.rotation);
    }

    void BossSpawn()
    {
        Instantiate(BossEnemyPrefab, transform.position, transform.rotation);
        CancelInvoke();
    }

}
