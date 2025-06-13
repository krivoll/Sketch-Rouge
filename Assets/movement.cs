using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class movement : MonoBehaviour
{

    // Update is called once per frame
    private Vector2 moveInput;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        moveInput = context.ReadValue<Vector2>();
    }
    void FixedUpdate()
    {
        Vector2 retning = new Vector2(horizontal, vertical);
        rb.AddForce(retning, ForceMode2D.Force);
    }
}
