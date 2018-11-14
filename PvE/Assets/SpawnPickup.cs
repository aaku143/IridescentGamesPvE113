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
        transform.position = new Vector3(-2.0f, 2.0f, 0);
        Instantiate(healthPack, transform);
    }
}
