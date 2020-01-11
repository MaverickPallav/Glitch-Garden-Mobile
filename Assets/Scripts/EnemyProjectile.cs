using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [Header("projectile movement")]
    [SerializeField] float velocityX;
    Rigidbody2D rb;

    [Header("projectiledamage")]
    [SerializeField] float damage = 100f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        rb.velocity = new Vector2(velocityX, 0);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var defender = otherCollider.GetComponent<Defender>();

        if (defender && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }

    }
}
