using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float healthPlayer;
  
    void Start()
    {
        healthPlayer = 100f;
        Debug.Log("Game Started and health is set to:" + healthPlayer);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (healthPlayer <= 0) 
        {
        Debug.Log("Player is dead!");
        Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    { 

        if (collision.gameObject.CompareTag("Enemy"))  //Inne på objektet så er det en "Tag" rett under objektnavnet. Har lagt til en Enemy tag.
        {   
            float damageCount = collision.gameObject.GetComponent<EnemyAttack>().damage;
            healthPlayer -= damageCount;
        }
    }
    
}
