using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        //var colliderToIgnore = player.GetComponent<BoxCollider2D>();
        //Physics2D.IgnoreCollision(colliderToIgnore, GetComponent<BoxCollider2D>());

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
