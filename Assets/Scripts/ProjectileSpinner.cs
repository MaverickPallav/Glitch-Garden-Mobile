using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpinner : MonoBehaviour
{
    [SerializeField] float speedofspin = 1f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, speedofspin * Time.deltaTime);
    }
}
