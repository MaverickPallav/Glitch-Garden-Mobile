using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderShooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float offset = 0.6f;
    Vector2 projectilepos;
    EnemySpawner myLaneSpawner;
     Animator animator;
    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";
    

    private void Start()
    {
        setLaneSpawner();
        animator = GetComponent<Animator>();
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if(!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void Update()
    {
        if (isAttackerInLane())
        {
            
            animator.SetBool("isAttacking", true);
        }
        else
        {
            
            animator.SetBool("isAttacking", false);
        }
    }

    private void setLaneSpawner()
    {
        EnemySpawner[] Enemyspawners = FindObjectsOfType<EnemySpawner>();

        foreach(EnemySpawner Spawner in Enemyspawners)
        {
            bool isCloseEnough = (Mathf.Abs(Spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);

            if(isCloseEnough)
            {
                myLaneSpawner = Spawner;
            }
        }
        
    }

    private bool isAttackerInLane()
    {
        if( myLaneSpawner && myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void shootprojectile()
    {
        projectilepos = new Vector2(transform.position.x + offset, transform.position.y);
        GameObject  newProjectile = Instantiate(projectile, projectilepos, transform.rotation) ;
        newProjectile.transform.parent = projectileParent.transform;
    }
}
