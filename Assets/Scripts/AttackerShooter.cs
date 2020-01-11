using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerShooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float offset = 0.6f;
    Vector2 projectilepos;
    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";


    private void Start()
    {
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }


    

    public void shootprojectile()
    {
        projectilepos = new Vector2(transform.position.x + offset, transform.position.y);
        GameObject newProjectile = Instantiate(projectile, projectilepos, transform.rotation);
        newProjectile.transform.parent = projectileParent.transform;
    }
}
