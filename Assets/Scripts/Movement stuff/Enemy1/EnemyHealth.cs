using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private float enemyHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyHealth = 1f;
    }

    // Update is called once per frame
    void Update()
    {
         if (enemyHealth <= 0) 
        {
        Debug.Log("Enemy is dead");
        Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {   
       
        
        if (collision.gameObject.CompareTag("Weapon"))  //Inne på objektet så er det en "Tag" rett under objektnavnet. Har lagt til en Enemy tag.
        {   
            Debug.Log("Hallo");
            float damageCount = collision.gameObject.GetComponent<PlayerAttack>().damage;
            enemyHealth -= damageCount;
            Debug.Log("Enemy took " + damageCount + " damage. Health is now: " + enemyHealth);
            
        }
    }
}
