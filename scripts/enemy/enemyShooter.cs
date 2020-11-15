using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShooter : MonoBehaviour
{
    public GameObject enemy;
    public GameObject blazerodPrefab;
    public float blazerodSpeed = 60.0f;
    public int ShootCoolDown = 100;
    public GameObject rodStart;

    int shootCD = 0;
    void Update()
    {
        Vector3 difference = enemy.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        enemy.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        shootCD++;
        float distance = difference.magnitude;
        Vector2 direction = difference / distance;
        direction.Normalize();
        if (shootCD >= ShootCoolDown) 
        {
            throwRod(direction, rotationZ);
            shootCD = 0;
        }
    }
    void throwRod(Vector2 direction, float rotationZ)
    {
        GameObject b = Instantiate(blazerodPrefab);
        b.transform.position = rodStart.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * blazerodSpeed;
        Destroy(b, 1);
    }
}
