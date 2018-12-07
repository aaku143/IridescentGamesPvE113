using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public int health;
    public int maxHealth = 10;
    public float movementSpeed;

    private int weaponPickup = 0;

    long frameIntervalCount;
    public GameObject projectile;
    public GameObject swordProjectile;
    private GameObject newProjectile;
    private Animator animator;


    //private Inventory inventory;


    // Use this for initialization
    void Start()
    {
        health = 10;
        frameIntervalCount = 10;
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed;
        var y = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;

        UpdateMovementAnim(x, y);

        MouseShooting();

        KeyboardShooting();

        transform.Translate(x, y, 0);
    }

    public int GetHealth()
    {
        return health;
    }

    private void CheckGameEnd() { 
        if(health <= 0){
            SceneManager.LoadScene(2);
        }
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

    private void UpdatePickupAnim(int weaponNum)
    {
        animator.SetInteger("Pickup", weaponNum);

    }

    private void MouseShooting()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        var playerObject = GameObject.Find("Player");
        Vector3 playerPos = playerObject.transform.position;

        Vector2 direction = (mousePosition - playerPos);
        direction.Normalize();
        direction *= 20;

        if (Input.GetMouseButton(0))
        {

            if (frameIntervalCount % 10 == 0)
            {
                if (weaponPickup == 1)
                {
                    var newProjectile = Instantiate(projectile, transform.position + (Vector3)direction * 0.1f, Quaternion.Euler(0, 0, Vector2.SignedAngle(playerPos, mousePosition - playerPos))) as GameObject;

                    //Debug.Log(Vector2.SignedAngle(playerPos, mousePosition - playerPos));

                    newProjectile.GetComponent<Rigidbody2D>().velocity = Vector3.MoveTowards(transform.position, direction, 100.0f);
                    Destroy(newProjectile, 2.0f);

                    frameIntervalCount = 0;
                }
            }
            else
            {
                if (weaponPickup == 2)
                {
                    MouseSword(direction);
                    frameIntervalCount = 0;
                    return;
                }
            }
        }

        frameIntervalCount++;
    }

    private void MouseSword(Vector2 direction)
    {
        if (direction.x >= 0)
        {
            var newProjectile = Instantiate(swordProjectile, transform.position + new Vector3(0.5f, 0f, 0f), transform.rotation) as GameObject;

            newProjectile.GetComponent<Rigidbody2D>().velocity = Vector3.MoveTowards(transform.position, new Vector3(20.0f, 0.0f, 0.0f), 50.0f);
            animator.SetInteger("Sword", 1);
        }
        else
        {
            var newProjectile = Instantiate(swordProjectile, transform.position + new Vector3(-0.5f,0f,0f), Quaternion.Euler(0, 0, 180)) as GameObject;

            newProjectile.GetComponent<Rigidbody2D>().velocity = Vector3.MoveTowards(transform.position, new Vector3(-20.0f, 0.0f, 0.0f), 50.0f);
            animator.SetInteger("Sword", 0);
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
                CheckGameEnd();
            }
        }
        else if (collision.gameObject.tag == "EnemyProjectile")
        {
            --health;
            if (health <= 0)
            {
                Destroy(this.gameObject);
                CheckGameEnd();
            }
        }
        else if (collision.gameObject.tag == "Pickup")
        {
            if (collision.gameObject.name.Contains("GunPickup"))
            {
                Debug.Log("gun pickup");
                weaponPickup = 1;
                UpdatePickupAnim(1);
                //inventory.AddItem(1);
            }
            else if (collision.gameObject.name.Contains("SwordSpawn"))
            {
                Debug.Log("sword pickup");
                weaponPickup = 2;
                UpdatePickupAnim(2);
                //inventory.AddItem(2);
            }
            Destroy(collision.gameObject);
        }
    }
}
