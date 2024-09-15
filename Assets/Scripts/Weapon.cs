using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 20f;

    public void Fire(float rotation)
    {
        // Instantiate the bullet at the firePoint position and rotation
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
        // Get the Rigidbody2D component from the bullet
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        
        // Apply force to the bullet
        bulletRb.AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
        bulletRb.SetRotation(rotation);

        // bulletRb.rotation = firePoint.rotation.eulerAngles.z;
        
        // Optionally, if you want to adjust the bullet's rotation to match firePoint's rotation
        // you can also ensure the bullet's transform.rotation is aligned with firePoint's rotation
        // bullet.transform.rotation = firePoint.rotation;
    }

    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
