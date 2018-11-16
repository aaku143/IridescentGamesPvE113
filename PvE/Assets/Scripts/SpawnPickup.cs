using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPickup : MonoBehaviour {

    public GameObject healthPack;
	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", 1.0f, 10.0f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void Spawn()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        do
        {
            healthPack.transform.position = new Vector3(player.transform.position.x + Random.Range(-10.0f, 10.0f)
                , player.transform.position.y + Random.Range(-10.0f, 10.0f), 0);
        } while (Vector3.Distance(player.transform.position, healthPack.transform.position) < 8.0f);



        Instantiate(healthPack);
    }
}
