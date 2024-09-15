using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   
    public Rigidbody2D rb;
    Vector2 mousePosition;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        // check if you hit the enemy
    }
    // // Start is called before the first frame update
    void Start()
    {
        
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
