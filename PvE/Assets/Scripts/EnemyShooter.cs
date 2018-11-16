using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour {

    public GameObject player;

    public GameObject enemyProjectile;
    private GameObject newProjectile;

	// Use this for initialization
	void Start () {
        InvokeRepeating("EnemyShoot", 5.0f, 2.0f);
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 enemyPos = transform.position;

        Vector2 direction = (player.gameObject.transform.position - enemyPos);
        direction.Normalize();
        direction *= 10;

        this.GetComponent<Rigidbody2D>().velocity = Vector3.MoveTowards(transform.position, direction, 100.0f);
    }

    void EnemyShoot()
    {
        Vector3 enemyPos = transform.position;

        Vector2 direction = (player.gameObject.transform.position - enemyPos);
        direction.Normalize();
        direction *= 10;

        this.GetComponent<Rigidbody2D>().velocity = Vector3.MoveTowards(transform.position, direction, 100.0f);

        var newProjectile = Instantiate(enemyProjectile, transform.position + (Vector3)direction * 0.1f, transform.rotation) as GameObject;

        newProjectile.GetComponent<Rigidbody2D>().velocity = Vector3.MoveTowards(transform.position, direction, 100.0f);
        Destroy(newProjectile, 2.0f);
    }
}
