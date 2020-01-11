using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMeister : MonoBehaviour
{
    [Range(0f, 5f)]
    float currentSpeed = 1f;
    GameObject currentarget;
    

    private void Update()
    {
        transform.Translate(Vector2.right * currentSpeed * Time.deltaTime);
        updateanimationState();
    }

    private void updateanimationState()
    {
        if(!currentarget)
        {
            currentSpeed = 1f;
            GetComponent<Animator>().SetBool("Miniattacked", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject othercollider = collision.gameObject;

        if(othercollider.GetComponent<Attacker>())
        {
            currentSpeed = 0;
            GetComponent<Animator>().SetBool("Miniattacked", true);
            currentarget = othercollider;
            
        }     
    }

   


}
