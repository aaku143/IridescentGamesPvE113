using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    int playerHealth;

	// Use this for initialization
	void Start () {
        playerHealth = 3;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            --playerHealth;
            if (playerHealth <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
