using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

    public GameObject enemy;
    public GameObject enemyShooter;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnSlime", 1.0f, 2.0f);
        InvokeRepeating("SpawnShooter", 3.0f, 5.0f);
	}

    void SpawnSlime()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        do
        {
            enemy.transform.position = new Vector3(player.transform.position.x + Random.Range(-10.0f, 10.0f)
                , player.transform.position.y + Random.Range(-10.0f, 10.0f), 0);
        } while (Vector3.Distance(player.transform.position, enemy.transform.position) < 8.0f);

        Instantiate(enemy); 
    }

    void SpawnShooter()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        do
        {
            enemyShooter.transform.position = new Vector3(player.transform.position.x + Random.Range(-10.0f, 10.0f)
                , player.transform.position.y + Random.Range(-10.0f, 10.0f), 0);
        } while (Vector3.Distance(player.transform.position, enemy.transform.position) < 8.0f);
 
        Instantiate(enemyShooter);
    }
}
