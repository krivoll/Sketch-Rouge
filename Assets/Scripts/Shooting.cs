using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
  
    public float atkSpeed = 1f; 
    public Boolean canShoot = true; 
    public GameObject bullet;
    public InputActionReference skyt;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
   
    }
    // Update is called once per frame
    void FixedUpdate()
    {

    }
    void OnEnable()
    {
        skyt.action.started += Fire;
    }
    void OnDisable()
    {
        skyt.action.started -= Fire;
    }
    private void Fire(InputAction.CallbackContext obj)
    {   
        if (!canShoot) return; //Hindrer å skyte for tidlig

        Vector2 direction = Vector2.zero;

        if (Keyboard.current.rightArrowKey.isPressed) {direction = Vector2.right;}
        if (Keyboard.current.leftArrowKey.isPressed) {direction = Vector2.left;}
        if (Keyboard.current.upArrowKey.isPressed) {direction = Vector2.up;}
        if (Keyboard.current.downArrowKey.isPressed) {direction = Vector2.down;}

        
        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);   //Instansierer kula
        BulletMovement bulletMovement = newBullet.GetComponent<BulletMovement>();              //Setter Scriptet "BulletMovement" til newBullet
        bulletMovement.direction = direction;                                                  //bestemmer hvilken retning den skal få
      
        StartCoroutine(Toggle());                                                              //Starter atkSpeed timeren 
    }
       IEnumerator Toggle() {                                                                   //atkSpeed timeren
         
        canShoot = false; 
        yield return new WaitForSeconds(1f/atkSpeed);
        canShoot = true; 
        
    }
}