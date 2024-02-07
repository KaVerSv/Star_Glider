using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketEngine : MonoBehaviour
{
    [SerializeField] private float speed = 30.0f;
    [SerializeField] private float engineRunTime = 4.0f;
    Rigidbody projectile;

    private bool engineRunning = true;

    void Start()
    {
        projectile = GetComponent<Rigidbody>();
        Invoke("OutOfFuel", engineRunTime);
    }

    void Update()
    {
        if (engineRunning) 
        {
            projectile.AddRelativeForce(Vector3.forward * speed);
        }
    }

    private void OutOfFuel()
    {
        engineRunning = false;
    }
}