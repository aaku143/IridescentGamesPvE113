﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    int health;
    public GameObject projectile;
    private GameObject newProjectile;
    private Animator animator;

    // Use this for initialization
    void Start()
    {
        health = 100;
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 10.0f;
        var y = Input.GetAxis("Vertical") * Time.deltaTime * 10.0f;

        UpdateMovementAnim(x, y);

        MouseShooting();

        KeyboardShooting();

        transform.Translate(x, y, 0);
    }

    private void UpdateMovementAnim(float x, float y)
    {

        if (x > 0)
        {
            animator.SetInteger("Direction", 1);
        }
        else if (x < 0)
        {
            animator.SetInteger("Direction", 0);
        }
        else if (x == 0 && y == 0)
        {
            animator.SetInteger("Direction", 2);
        }
    }

    private void UpdatePickupAnim()
    {
        animator.SetInteger("Pickup", 1);
    }

    private void MouseShooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            var playerObject = GameObject.Find("Player");
            Vector3 playerPos = playerObject.transform.position;

            Vector2 direction = (mousePosition - playerPos);
            direction.Normalize();
            direction *= 20;

            var newProjectile = Instantiate(projectile, transform.position + (Vector3)direction * 0.1f, transform.rotation) as GameObject;

            //Vector2 tmpDir = mousePosition - (Vector2)newProjectile.transform.position;

            //newProjectile.GetComponent<Rigidbody2D>().velocity = Vector2.Lerp(newProjectile.transform.position, mousePosition, 100.0f / tmpDir.magnitude * Time.deltaTime);
            newProjectile.GetComponent<Rigidbody2D>().velocity = Vector3.MoveTowards(transform.position, direction, 100.0f);
            Destroy(newProjectile, 2.0f);
        }
    }

    private void KeyboardShooting()
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            --health;
            if (health <= 0)
            {
                Destroy(this.gameObject);
            }
        }
        else if (collision.gameObject.tag == "Pickup")
        {
            Debug.Log("Gun pickup");
            UpdatePickupAnim();
            Destroy(collision.gameObject);
        }
    }
}