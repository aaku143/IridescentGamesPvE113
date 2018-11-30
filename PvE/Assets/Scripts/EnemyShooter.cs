using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour {

    public GameObject player;

    public GameObject enemyProjectile;
    //private GameObject newProjectile;

	// Use this for initialization
	void Start () {
        InvokeRepeating("EnemyShoot", 2.0f, 3.0f);
	}

    // Update is called once per frame
    void Update()
    {
        var playerObject = GameObject.Find("Player");
        Vector3 playerPos = playerObject.transform.position;
        Vector3 enemyPos = transform.position;

        Vector2 direction = (playerPos - enemyPos);
        if (direction.magnitude > 10.0f)
        {
            direction.Normalize();
            direction *= 5;

            this.GetComponent<Rigidbody2D>().velocity = Vector3.MoveTowards(transform.position, direction, 100.0f);
        }
    }

    void EnemyShoot()
    {
        Vector3 enemyPos = transform.position;
        var playerObject = GameObject.Find("Player");
        Vector3 playerPos = playerObject.transform.position;

        Vector2 direction = (playerPos - enemyPos);
        direction.Normalize();
        direction *= 20;

        //this.GetComponent<Rigidbody2D>().velocity = Vector3.MoveTowards(transform.position, direction, 100.0f);

        var newProjectile = Instantiate(enemyProjectile, transform.position + (Vector3)direction * 0.1f, transform.rotation) as GameObject;

        newProjectile.GetComponent<Rigidbody2D>().velocity = Vector3.MoveTowards(transform.position, direction, 100.0f);
        Destroy(newProjectile, 2.0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile" || collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
