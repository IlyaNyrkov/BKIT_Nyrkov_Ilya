using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class player_health : MonoBehaviour
{
    Rigidbody2D rb;
    public static float healthAmount;
    void Start()
    {
        healthAmount = 0.3f;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (healthAmount <= 0)
        {
            Cursor.visible = true;
            SceneManager.LoadScene("menu");
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("enemyRandomSkin(Clone)"))
        {
            healthAmount -= 0.1f;
        }
    }
}
