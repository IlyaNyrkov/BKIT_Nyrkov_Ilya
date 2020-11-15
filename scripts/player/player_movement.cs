using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed;
    public Rigidbody2D rb;

    private Vector2 moveDirection;
    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); // A, D, left/right arrow keys
        float moveY = Input.GetAxisRaw("Vertical"); // W, S, up/down
        moveDirection = new Vector2(moveX, moveY).normalized; //to make diagonal movement's speed normal
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }


}
