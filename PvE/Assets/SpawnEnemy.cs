using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

    public GameObject enemy;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", 1.0f, 1.0f);

	}

    void Spawn()
    {
        transform.position = new Vector3(2.0f, 2.0f, 0);
        Instantiate(enemy, transform);
    }
}
