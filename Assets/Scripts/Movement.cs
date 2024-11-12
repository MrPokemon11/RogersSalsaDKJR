using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] private int movementSpeed = 5;
    [SerializeField] private float jumpForce = 10;
    
    [DllImport("RogersSalsaDLL", EntryPoint = "GetSpeed")]
    private static extern int GetSpeed ();
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        try
        {
            movementSpeed = GetSpeed();
        }
        catch (Exception e)
        {
            //Console.WriteLine(e);
            //throw;
        }
    }
    
    
    
    // Design pattern: command
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveRight();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }


    }

    public void MoveLeft()
    {
        rb2d.position += Vector2.left * movementSpeed * Time.deltaTime;
    }

    public void moveRight()
    {
        rb2d.position += Vector2.right * movementSpeed * Time.deltaTime;
    }

    public void Jump()
    {
        rb2d.position += Vector2.up * jumpForce * Time.deltaTime;
    }
}
