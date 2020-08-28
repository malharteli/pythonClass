using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 4.0f;  // a float that represents the speed of the player

    private Rigidbody2D rb; //Store a reference to a Rigidbody2D component 

    private Camera mainCamera; //Store a reference to the main Camera in the game 

    private Vector2 mousePos; 
    private Vector2 movement;
    
    public int health = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get and store a reference to the Rigidbody2D component so that we can access it.
        mainCamera = FindObjectOfType<Camera>(); //Get and store a reference to the first Camera in the scene so we can access it.
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition); // Takes the mousePosition and finds the first point beneath it
        float moveHorizontal = Input.GetAxis("Horizontal"); // Gets the horizontal Input from the Unity Game
        float moveVertical = Input.GetAxis("Vertical"); // Gets the vertical Input from the Unity Game

        // Create a Vector2 that will take our horizontal and vertical inputs and combine them into a Vector2D object
        movement = new Vector2(moveHorizontal, moveVertical);

        if(Input.GetButtonDown("Fire1"))
        {
            Shooting shooter = GetComponent<Shooting>();
            shooter.fire = true;
        }
    }

    // FixedUpdate is called at a fixed interval (tick) and is independent of the frame rate. This is where we use Physics Code
    void FixedUpdate()
    {
        

        // Add movement, multiplied by our speed, to the Rigidbody2D of our character.
        rb.velocity = (movement * speed);

        // creating a relative direction
        Vector2 lookDir = mousePos- rb.position;
        // Tangent of lookDir.y and lookDir.x
        // Translate the tangent radians to degrees 
        // Subtract 90f degrees to make the lookDir face up
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    // Hit will receive a bullet and receive the requisite damage from it
    public void Hit(int damage) {
        health-= damage;
        if (health < 1)
        {
            Destroy(gameObject);
        }
    }
}
