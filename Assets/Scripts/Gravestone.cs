using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravestone : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D othercollider)
    {
        Attacker attacker = othercollider.GetComponent<Attacker>();

        if(attacker)
        {
            // do some animation
        }
    }
}
