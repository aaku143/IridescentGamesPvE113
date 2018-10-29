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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var newProjectile = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //Vector2 tmpDir = mousePosition - (Vector2)newProjectile.transform.position;

            //newProjectile.GetComponent<Rigidbody2D>().velocity = Vector2.Lerp(newProjectile.transform.position, mousePosition, 100.0f / tmpDir.magnitude * Time.deltaTime);
            newProjectile.GetComponent<Rigidbody2D>().velocity = Vector3.MoveTowards(transform.position, mousePosition.normalized * 100.0f, 100.0f);
            Destroy(newProjectile, 2.0f);
        }

        ProjectileUpdate();

        transform.Translate(x, y, 0);
    }

    void ProjectileUpdate()
    {
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
    }
}
