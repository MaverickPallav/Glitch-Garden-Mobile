using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{

    [Range(0f, 5f)]
    float currentSpeed = 1f;
    GameObject currentTarget;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void OnDestroy()
    {
          LevelController levelController =  FindObjectOfType<LevelController>();
        if (levelController != null)
        {
            levelController.AttackerKilled();
        }
    }

     void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
        //  SettingDifficultyOfAttacker();
    }

   /* private void SettingDifficultyOfAttacker()
    {
        var difficultyLevel = PlayerPrefsController.GetDifficultyLevel();
        if (difficultyLevel == 1)
        {
            
                GetComponent<Animator>().SetBool("Difficulty2", false);
                GetComponent<Animator>().SetBool("Difficulty3", false);
            
        }
        if (difficultyLevel == 2)
        {
           
            
                GetComponent<Animator>().SetBool("Difficulty2", true);
                GetComponent<Animator>().SetBool("Difficulty3", false);
            
        }
        if (difficultyLevel == 3)
        {
            
                GetComponent<Animator>().SetBool("Difficulty2", true);
                GetComponent<Animator>().SetBool("Difficulty3", false);
            
        }
    } */

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget) { return; }
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
        }
    }

}