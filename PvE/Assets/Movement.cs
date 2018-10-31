using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public GameObject projectile;

    private GameObject newProjectile;

    //private Vector2 mousePosition;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 10.0f;
        var y = Input.GetAxis("Vertical") * Time.deltaTime * 10.0f;

        if (Input.GetMouseButtonDown(0))
        {
            
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            var playerObject = GameObject.Find("Player");
            Vector3 playerPos = playerObject.transform.position;

            Vector2 direction = (mousePosition - playerPos);
            direction.Normalize();
            direction *= 20;

            var newProjectile = Instantiate(projectile, transform.position + (Vector3)direction*0.1f, transform.rotation) as GameObject;

            //Vector2 tmpDir = mousePosition - (Vector2)newProjectile.transform.position;

            //newProjectile.GetComponent<Rigidbody2D>().velocity = Vector2.Lerp(newProjectile.transform.position, mousePosition, 100.0f / tmpDir.magnitude * Time.deltaTime);
            newProjectile.GetComponent<Rigidbody2D>().velocity = Vector3.MoveTowards(transform.position, direction, 100.0f);
            Destroy(newProjectile, 2.0f);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            var newProjectile = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
            newProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(-50.0f, 0.0f);
            Destroy(newProjectile, 2.0f);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            var newProjectile = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
            newProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 50.0f);
            Destroy(newProjectile, 2.0f);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            var newProjectile = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
            newProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, -50.0f);
            Destroy(newProjectile, 2.0f);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            var newProjectile = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
            newProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(50.0f, 0.0f);
            Destroy(newProjectile, 2.0f);
        }

        transform.Translate(x, y, 0);
    }
}
