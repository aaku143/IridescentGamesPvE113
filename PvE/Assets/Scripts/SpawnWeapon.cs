using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWeapon : MonoBehaviour {

    public GameObject gun;
    public GameObject sword;
    public Transform[] spawnLocations;

	// Use this for initialization
	void Start () {
        SpawnGunWeapon();
        //SpawnSword();
    }
	
	private void SpawnGunWeapon()
    {
        //transform.position = new Vector3(3.5f, 0.5f, 0);
        Instantiate(sword, spawnLocations[0]);

        //transform.position = new Vector3(-2.0f, -0.5f, 0);
        Instantiate(gun, spawnLocations[1]);
    }
}
