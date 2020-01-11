using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerMachine : MonoBehaviour
{
    [SerializeField] float MoveMentSpeed = 2f;
    Rigidbody2D rb;
    Vector2 Limit;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Limit = new Vector2(20, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        GameObject otherObject = collision.gameObject;

        if(otherObject.GetComponent<CatchSun>())
        {
            return;
        }

        if(otherObject.GetComponent<EnemyProjectile>())
        {
            Destroy(otherObject);
        }
        
        if (otherObject.GetComponent<Attacker>())
        {
            SetSpeedKillerMachine();
            Destroy(otherObject);
        }
    }

    public void SetSpeedKillerMachine()
    {
        rb.velocity = new Vector2(MoveMentSpeed, 0);
    }

    private void Update()
    {
        if(transform.position.x >= Limit.x)
        {
            Destroy(this.gameObject);
        }
    }
}
