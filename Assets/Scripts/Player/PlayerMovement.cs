using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System;
using System.Threading;

public class PlayerMovement : MonoBehaviour
{

    PlayerControll controls;
    private Rigidbody playerRb;

    //movement related values
    //use for game balancing
    [SerializeField] private float speed = 20f;
    [SerializeField] private float RotSpeed = 0.2f;
    [SerializeField] float decelerationSpeed = 0.7f;
    [SerializeField] float dashForce = 50f;
    [SerializeField] float dashRechargeTime = 8f;

    //movement values
    Vector2 move;
    //Vector2 rot;
    //stablized mode staus
    bool stablized = true;
    //dash 
    private bool redyToDash = true;

    //Audio - engine
    //public AudioSource audioSource;
    public float maxVolume = 1.0f;
    public float timeToMaxVolume = 2.0f;
    public float timeToZeroVolume = 2.0f;

    private float currentVolume = 0.0f;
    private bool isIncreasingVolume = false;
    private float buttonPressStartTime = 0.0f;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Awake()
    {
        controls = new PlayerControll();

        //movement
        controls.playerMovement.Movement.performed += cntxt => move = cntxt.ReadValue<Vector2>();
        controls.playerMovement.Movement.canceled += cntxt => move = Vector2.zero;
        //rotation
        //controls.playerMovement.Rotate.performed += cntxt => rot = cntxt.ReadValue<Vector2>();
        //controls.playerMovement.Rotate.canceled += cntxt => rot = Vector2.zero;
    }

    void Update()
    {
        if (controls.playerMovement.Stabilization.WasPressedThisFrame())
        {
            stablized = !stablized;
        }
        
        if (stablized)
        {
            MoveShip();
            Dash();
            if (!controls.playerMovement.Movement.IsPressed())
            {
                playerRb.velocity *= (1f - Time.fixedDeltaTime * decelerationSpeed);
            }

            CounterRotation();
        }
        else
        {
            MoveShip();
            Dash();
            CounterRotation();
        }

        //Sound

        if (controls.playerMovement.Movement.IsPressed() || controls.playerMovement.elevate.IsPressed())
        {
            if (!isIncreasingVolume)
            {
                isIncreasingVolume = true;
                buttonPressStartTime = Time.time;
                //audioSource.Play();
            }

            float timeElapsed = Time.time - buttonPressStartTime;

            if (timeElapsed <= timeToMaxVolume)
            {
                currentVolume = Mathf.Clamp01(timeElapsed / timeToMaxVolume) * maxVolume;
            }
            else
            {
                currentVolume = maxVolume;
            }
        }
        else
        {
            if (isIncreasingVolume)
            {
                isIncreasingVolume = false;
                buttonPressStartTime = Time.time;
            }

            float timeElapsedSinceRelease = Time.time - buttonPressStartTime;

            if (timeElapsedSinceRelease <= timeToZeroVolume)
            {
                currentVolume = Mathf.Lerp(maxVolume, 0.0f, timeElapsedSinceRelease / timeToZeroVolume);
            }
            else
            {
                currentVolume = 0.0f;
                //audioSource.Stop();
            }
        }
        //audioSource.volume = currentVolume;
    }

    private void MoveShip()
    {
        playerRb.AddForce(Vector3.forward * move.y * speed, ForceMode.Force);
        playerRb.AddForce(Vector3.right * move.x * speed, ForceMode.Force);

        // Ogranicz pozycjê statku w zakresie x od -100 do 100
        float clampedX = Mathf.Clamp(transform.position.x, -100f, 100f);

        // Ogranicz pozycjê statku w zakresie y od 0 do 50
        float clampedZ = Mathf.Clamp(transform.position.z, 0f, 50f);

        // Zaktualizuj pozycjê statku
        transform.position = new Vector3(clampedX, transform.position.y, clampedZ);

        // Obróæ statek
        //GetComponent<Transform>().Rotate(Vector3.up * rot.x * RotSpeed);
        //GetComponent<Transform>().Rotate(Vector3.right * rot.y * RotSpeed);
    }

    private void CounterRotation()
    {
        // Counteracting the rotational forces caused by the collision
        float rotationSpeed = 10f; // Adjust this value as needed
        playerRb.angularVelocity *= (1f - Time.fixedDeltaTime * rotationSpeed);
    }

    private void Dash()
    {
        if (controls.playerMovement.Dash.WasPressedThisFrame() && redyToDash == true)
        {
            redyToDash = false;
            Vector3 direction = Direction();
            playerRb.AddRelativeForce(direction * dashForce, ForceMode.Impulse);
            Invoke("DashRecharge", dashRechargeTime);
        }
    }

    private void DashRecharge()
    {
        redyToDash = true;
    }

    private Vector3 Direction()
    {
        // Porównanie bezwzglêdnych wartoœci x i y z move
        float absX = Mathf.Abs(move.x);
        float absY = Mathf.Abs(move.y);

        // Utworzenie Vector3 na podstawie najwiêkszej wartoœci
        Vector3 resultVector;

        if (absX > absY)
        {
            resultVector = move.x > 0 ? Vector3.right : Vector3.left;
        }
        else
        {
            resultVector = move.y > 0 ? Vector3.forward : Vector3.back;
        }

        return resultVector;
    }

    private void OnEnable()
    {
        controls.playerMovement.Enable();
    }

    private void OnDisable()
    {
        controls.playerMovement.Disable();
    }
}