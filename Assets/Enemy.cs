using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var playerObject = GameObject.Find("Player");
        Vector3 playerPos = playerObject.transform.position;
        Vector3 enemyPos = transform.position;

        Vector2 direction = (playerPos - enemyPos);
        direction.Normalize();
        direction *= 10;

        this.GetComponent<Rigidbody2D>().velocity = Vector3.MoveTowards(transform.position, direction, 100.0f);
    }
}
