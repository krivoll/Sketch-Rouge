using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float healthPlayer;
    void Start()
    {
        healthPlayer = 100f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
    void OnCollisionEnter(Collision damage)
    {
        if (damage.gameObject.name.Equals("EnemyAttack"))
        {
            //float damageCount = damage.gameObject.
            //healthPlayer -= 
        }
    }
}
