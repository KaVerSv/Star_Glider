using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class for implementng bullet like projectile launch
public class MoveForward : MonoBehaviour
{
    [SerializeField] private float speed = 40.0f;
    Rigidbody projectile;

    void Start()
    {
        projectile = GetComponent<Rigidbody>();
        projectile.AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
    }

    void Update()
    {
        
    }
}
