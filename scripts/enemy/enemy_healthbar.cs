using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_healthbar : MonoBehaviour
{
    Vector3 localScale;
    void Start()
    {
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
       // localScale.x = enemy_health.healthAmount;
        transform.localScale = localScale;
    }
}
