using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour {
    //tag = HealthPack
    // Use this for initialization

    int healAmount = 5;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if ( player.maxHealth < player.health + healAmount )
            {
                player.health = player.maxHealth;
            }
            else
            {
                player.health += healAmount;
            }

            Destroy(this.gameObject);
        }
    }
}
