using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class BulletMovement : MonoBehaviour

{
    public GameObject player;
    public Vector2 position;
    public float bulletSpeed = 10f;
    public Rigidbody2D rb;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // rb.linearVelocity = new Vector2(retning.x * fart, retning.y * fart);

        //transform.position = player.transform.position;
        float posx, posy;
        if (position.x > position.y) { posy = 0; posx = position.x; }
        else { posx = 0; posy = position.y; }

        rb.linearVelocity = new Vector2(posx * bulletSpeed, posy*bulletSpeed);
    }
}
