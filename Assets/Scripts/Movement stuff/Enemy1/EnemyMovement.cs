
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float EnemySpeed; 

    public Rigidbody2D rb; 

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Transform TransformedPlayer = Player.Instance.GetComponent<Transform>();
        Vector2 direction = TransformedPlayer.position;
        transform.position = Vector2.MoveTowards(transform.position, direction, EnemySpeed * Time.deltaTime);
    }
}
