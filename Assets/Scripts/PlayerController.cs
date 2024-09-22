using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Weapon weapon;
    public Transform armBone;
    public Animator animator;
    public float health = 100f;


    Vector3 mousePosition;
    float currentAngle;

    void LateUpdate()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RotateArmAndWeaponTowardsMouse();

        if(Input.GetMouseButtonDown(0))
        {
            weapon.Fire(currentAngle);
        }
    }

    void RotateArmAndWeaponTowardsMouse()
    {
        Vector3 direction = mousePosition - armBone.position;

        currentAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        armBone.rotation = Quaternion.Euler(new Vector3(0, 0, currentAngle));
    }

    public void TakeDamage(float damage, string hitLocation = "")
    {
        health -= damage;
        Debug.Log("Player tomou dano: " + damage + " | Vida restante: " + health);

        if (health <= 0)
        {
            Die();
            return;
        }

        if (hitLocation == "foot")
        {
            animator.SetTrigger("FootShotTrigger");
        }
    }

    void Die()
    {
        // Implementar a lógica de morte do player (destruição, animação, etc.)
        Debug.Log("Player morreu!");
        Destroy(gameObject);
    }
}