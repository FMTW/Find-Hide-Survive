using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Camera viewCamera;

    public float sprintSpeed = 50;
    public float walkSpeed = 20;
    
    private Rigidbody2D rb2d;
    private Vector3 MousePos;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        viewCamera = Camera.main;

    }

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        move(movement);

        faceMouse();  // Aim the game object towards the mouse position.

    }

    void Update() {

    }


    // Check if "Shift" is pressed then increase speed.
    void move(Vector2 _movement) {
        if (Input.GetKey(KeyCode.LeftShift))
            rb2d.AddForce(_movement * sprintSpeed);
        else
            rb2d.AddForce(_movement * walkSpeed);
    }

    // Hey Purich, this should fix the issue with where the character will aim towards.
    void faceMouse()
    {
        Vector3 MousePos = Input.mousePosition;
        MousePos = Camera.main.ScreenToWorldPoint(MousePos);

        Vector2 direction = new Vector2(MousePos.x - transform.position.x, MousePos.y - transform.position.y);

        transform.up = direction;
    }

}
