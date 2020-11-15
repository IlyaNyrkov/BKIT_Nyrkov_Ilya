using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_health : MonoBehaviour
{
    public GameObject healthbar;
    Rigidbody2D rb;
    private float healthAmount;
    public float HP;

    Vector3 localscale;
    // Start is called before the first frame update
    void Start()
    {
        healthAmount = HP;
        rb = GetComponent<Rigidbody2D>();
        healthbar.transform.localScale = new Vector2(healthAmount * 1.5f, 1);
    }

    // Update is called once per frame
    void Update()
    { 
        if (healthAmount <= 0)
        {
            Destroy(gameObject);
            playerScore.score++;
        }
        if (player_health.healthAmount <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("blaserod(Clone)"))
        {
            healthAmount -= 0.1f;
            healthbar.transform.localScale = new Vector2(healthAmount * 1.5f, 1);
        }
    }
}
