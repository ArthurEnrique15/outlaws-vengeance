using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Weapon weapon;
    public Transform armBone;

    Vector3 mousePosition;
    float currentAngle;

    void Update()
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
}