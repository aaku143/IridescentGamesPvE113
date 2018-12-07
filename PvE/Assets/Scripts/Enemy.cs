using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int scoreValue = 10;
    public float movementSpeed;

    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        var playerObject = GameObject.Find("Player");
        Vector3 playerPos = playerObject.transform.position;
        Vector3 enemyPos = transform.position;

        Vector2 direction = (playerPos - enemyPos);
        direction.Normalize();
        direction *= 10;

        this.GetComponent<Rigidbody2D>().velocity = Vector3.MoveTowards(transform.position, direction, movementSpeed);

        UpdateAnimationDirection(direction);
    }

    private void UpdateAnimationDirection(Vector2 direction)
    {
        if (direction.x >= 0)
        {
            animator.SetInteger("Direction", 1);
        }
        else
        {
            animator.SetInteger("Direction", 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            ScoreManager.score += scoreValue;
            Death();
        }
        else if (collision.gameObject.tag == "Player")
        {
            Death();
        }
    }

    private void Death()
    {
        Destroy(this.gameObject);
    }
}
