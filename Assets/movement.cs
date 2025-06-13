using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float fart = 5f;
    public InputActionReference move;
    private Vector2 retning;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        retning = move.action.ReadValue<Vector2>();
    }
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(retning.x * fart, retning.y * fart);
    }
}
