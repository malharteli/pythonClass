using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float health=10;
    public float points= 10;

    public float speed = 4.0f;  // a float that represents the speed of the player

    private Rigidbody2D rb; //Store a reference to a Rigidbody2D component 

    private Rigidbody2D player; 

    private Shooting shooter;

    public float waitTime = 1f;

    public float holdTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        shooter = GetComponent<Shooting>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            Vector2 lookDir = player.position - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
        }
        
    }

    void FixedUpdate(){
        if (holdTime >= waitTime)
        {
            shooter.fire = true;
            holdTime = 0f;
        }
        else {
            holdTime += 1 * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag== "Player")
        {
            player = other.GetComponent<Rigidbody2D>();
        }
    }

    // Hit will receive a bullet and receive the requisite damage from it
    public void Hit(int damage) {
        Debug.Log("Enemy Hit!");
        health-= damage;
        if (health < 1)
        {
            Destroy(gameObject);
        }
    }

}
