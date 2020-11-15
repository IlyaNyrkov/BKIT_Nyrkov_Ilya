using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class pointANDshoot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject crosshairs;
    public GameObject player;
    //blazerod
    public GameObject blazerodPrefab;
    public float blazerodSpeed = 60.0f;
    public int ShootCoolDown = 100;
    public GameObject rodStart;
    //player
    private Vector3 target;
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    int shootCD = 0;
    
    void Update()
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint
            (new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        //определение положения мыши в самой игре
        crosshairs.transform.position = new Vector2(target.x, target.y);
        Vector3 difference = target - player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        shootCD++;
        if (Input.GetMouseButtonDown(0))
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            if (shootCD >= ShootCoolDown)
            {
                throwRod(direction, rotationZ);
                shootCD = 0;
            }
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

