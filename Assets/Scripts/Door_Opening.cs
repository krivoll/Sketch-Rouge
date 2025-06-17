using UnityEditor.SearchService;
using UnityEngine;

public class Door_Opening : MonoBehaviour
{
    public GameObject enemies;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemies.transform.childCount == 0) {
            GetComponent<BoxCollider2D>().isTrigger = true; 
        }
    }
}
 