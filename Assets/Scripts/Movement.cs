using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] private int movementSpeed = 5;
    [SerializeField] private float jumpForce = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    
    // Design pattern: command
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb2d.position += Vector2.right * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb2d.position += Vector2.up * jumpForce * Time.deltaTime;
        }
    }

    public void MoveLeft()
    {
        rb2d.position += Vector2.left * movementSpeed * Time.deltaTime;
    }
}
