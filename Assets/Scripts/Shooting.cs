using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public float bulletSpeed;

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
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
}
