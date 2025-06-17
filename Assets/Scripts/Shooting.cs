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
        if (skyt)
        {
            skyt.action.Enable();
            skyt.action.started += Fire;    
        }
    }
    void OnDisable()
    {
        if (skyt)
        {
            skyt.action.started -= Fire;
        }
    }
    private void Fire(InputAction.CallbackContext obj)
    {   
        if (!canShoot) return; //Hindrer å skyte for tidlig

        Vector2 direction = Vector2.zero;
        Vector3 position = transform.position;

        if (Keyboard.current.rightArrowKey.isPressed) {direction = Vector2.right;}
        if (Keyboard.current.upArrowKey.isPressed) {direction = Vector2.up;}
        if (Keyboard.current.downArrowKey.isPressed) {direction = Vector2.down;}
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            direction = Vector2.left;
            position.y += 0.0001f;          // Vet ikke om dette skjedde med deg, men for meg så skjøt den ish
        }                                   // skrått nedover når jeg trykka left arrow, men dette fiksa det :))



        GameObject newBullet = Instantiate(bullet, position, Quaternion.identity);   //Instansierer kula
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