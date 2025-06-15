using UnityEngine;
using UnityEngine.InputSystem;

public class BulletMovement : MonoBehaviour

{
    public GameObject player;
    public Vector2 position;
    public InputActionReference move;
    public InputActionReference direction;
    public Vector2 speed;
    public Rigidbody2D rb;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        position = move.action.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        // rb.linearVelocity = new Vector2(retning.x * fart, retning.y * fart);

        transform.position = player.transform.position;
    }
}
