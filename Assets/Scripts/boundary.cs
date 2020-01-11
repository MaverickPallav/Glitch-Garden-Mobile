using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundary : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;

        if (otherObject.GetComponent<KillerMachine>())
        {
            Destroy(otherObject);
        }
        else
        {
            Destroy(collision.gameObject);
            if (otherObject.GetComponent<Attacker>())
            {
                StartCoroutine(LoseScreen());
            }
        }
    }
    IEnumerator LoseScreen()
    {
        
        yield return new WaitForSeconds(1f);
        FindObjectOfType<LevelController>().LoseScreen();
        Time.timeScale = 0;
    }
}
