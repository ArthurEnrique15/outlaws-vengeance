using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-2)]
public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Weapon weapon;
    public Transform armBone;
    public Animator animator;
    public float health = 100f;
    public HealthBar healthBar;
    public bool canShoot = false;
    public bool isDead = false;

    Vector3 mousePosition;
    float currentAngle;

    void LateUpdate()
    {
        if (health <= 0) return;

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RotateArmAndWeaponTowardsMouse();

        if(canShoot && Input.GetMouseButtonDown(0))
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
        healthBar.SetHealthSliderValue(health);

        if (health <= 0)
        {
            isDead = true;
            animator.SetTrigger("DeathTrigger");
        }
    }
}