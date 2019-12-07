using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panda : MonoBehaviour
{
    [Header("Constant Forces")]
    public float forwardForce;
    public float e_forwardForce;
    public float horizontalForce, downwardForce, upwardForce;
    public float e_horizontalForce, e_downwardForce, e_upwardForce;
    [Space(10)]
    public float breakForce;

    [Header("Shortterm Impulses")]
    public float forwardImpulsePower;
    public float horizontalImpulsePower, downwardImpulsePower, upwardImpulsePower;

    [Header("Timers")]
    public float forwardImpulseTime;
    public float horizontalImpulseTime, downwardImpulseTime, upwardImpulseTime;
    private float e_horizontalImpulseTime, e_forwardImpulseTime, e_downwardImpulseTime, e_upwardImpulseTime;
    public float airTime, e_AirTime;

    [Header("Other values")]
    public Rigidbody rb;
    public int maxJumpCount, currentJumpCount;
    public float minVelocityBeforeForceMultiply, FallAfterJumpSpeed;
    public RaycastHit groundCheck;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetBasicValues();
    }


    void Update()
    {
        PrintDetails();
        TimersCountdown();
        CoditionExecutionManager();
    }


    /// <summary>
    /// Handles the right call of each force
    /// </summary>
    void CoditionExecutionManager()
    {
        float moveX = Input.GetAxisRaw("Horizontal");

        // If it doesn't touch the ground
        if (!Physics.Raycast(transform.position, new Vector3(0f, -1f, 0f), out groundCheck, 1.5f, LayerMask.NameToLayer("Ground")))
        {
            Debug.DrawRay(transform.position, new Vector3(0f, -1f, 0f) * groundCheck.distance, Color.red);

            // Count Down before quick fall
            if (isTimeToFall()) rb.AddForce(new Vector3(0f, -1f, 0f) *
            (downwardForce / FallAfterJumpSpeed) * Time.deltaTime, ForceMode.Impulse);
        }

        if (Physics.Raycast(transform.position, new Vector3(0f, -1f, 0f), out groundCheck, 1.5f, LayerMask.NameToLayer("Ground")))
        {
            Debug.Log("Test");
        }

        if (Input.GetButton("Vertical") && Input.GetAxisRaw("Vertical") < 0f) return;
        else
        {
            if (Input.GetButtonDown("Horizontal")) e_horizontalImpulseTime = horizontalImpulseTime;
            if (Input.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical") > 0f) e_forwardImpulseTime = forwardImpulseTime;
            //if (Input.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical") < 0f) e_downwardImpulseTime = downwardImpulseTime;
            if (Input.GetButtonDown("Jump") && currentJumpCount < maxJumpCount)
            {
                currentJumpCount++;
                e_AirTime = airTime;
                e_upwardImpulseTime = upwardImpulseTime;
            }

            ForwardForceHandler();

            if (e_horizontalImpulseTime > 0f) ApplyHorizontalImpulse(moveX);
            if (e_forwardImpulseTime > 0f) ApplyForwardImpulse();
            if (e_downwardImpulseTime > 0f) ApplyDownwardImpulse();
            if (e_upwardImpulseTime > 0f) ApplyUpwardImpulse();

            if (e_forwardImpulseTime <= 0f) ApplyForwardForce();
            if (e_horizontalImpulseTime <= 0f) ApplyHorizontalForce(moveX);
            if (e_downwardImpulseTime <= 0f && e_upwardImpulseTime <= 0f) ApplyDownwardForce();
            if (e_upwardImpulseTime <= 0f) ApplyUpwardForce();
        }
    }


    private bool isTimeToFall()
    {
        if (e_AirTime <= 0f)
        {
            return true;
        }
        if (e_AirTime > 0f) e_AirTime -= Time.deltaTime;
        return false;
    }


    private void TimersCountdown()
    {
        if (e_horizontalImpulseTime > 0f) e_horizontalImpulseTime -= Time.deltaTime;
        if (e_forwardImpulseTime > 0f) e_forwardImpulseTime -= Time.deltaTime;
        if (e_downwardImpulseTime > 0f) e_downwardImpulseTime -= Time.deltaTime;
        if (e_upwardImpulseTime > 0f) e_upwardImpulseTime -= Time.deltaTime;
    }


    private void OnCollisionEnter(Collision collision)
    {
        currentJumpCount = 0;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Roof")
        {
            e_downwardImpulseTime = downwardImpulseTime;
            Debug.Log("SLAM DUNK!");
        }
    }


    private void ForwardForceHandler()
    {
        if (rb.velocity.x > minVelocityBeforeForceMultiply * -1f)
        {
            e_forwardForce *= 1.01f;
            e_upwardForce *= 1.015f;
        }
        if (rb.velocity.x < minVelocityBeforeForceMultiply * -1f)
        {
            e_forwardForce = forwardForce;
            e_upwardForce = upwardForce;
        }
    }


    #region Forces USE THE FORCE LUKE!
    private void ApplyForwardForce()
    {
        if (e_forwardForce == forwardForce)
            rb.AddForce(new Vector3(1f, 0f, 0f) * forwardForce * Time.deltaTime * -1f, ForceMode.Force);
        if (e_forwardForce > forwardForce)
        {
            rb.AddForce(new Vector3(1f, 0f, 0f) * e_forwardForce * Time.deltaTime * -1f, ForceMode.Force);
            rb.AddForce(new Vector3(0f, 1f, 0f) * e_upwardForce * Time.deltaTime * -1f, ForceMode.Force);
        }
    }


    void ApplyHorizontalForce(float moveX)
    {
        rb.AddForce(new Vector3(0f, 0f, moveX) * horizontalForce * Time.deltaTime, ForceMode.Force);
        //rb.AddTorque(new Vector3(moveX, 0, 0) * tourqueForce * Time.deltaTime, ForceMode.Force);
    }


    private void ApplyDownwardForce()
    {
        if (currentJumpCount < 0)
            rb.AddForce(new Vector3(0f, -1f, 0f) * downwardForce * Time.deltaTime, ForceMode.Force);
    }


    private void ApplyUpwardForce()
    {
        rb.AddForce(new Vector3(0f, 1f, 0f) * upwardForce * Time.deltaTime, ForceMode.Force);
    }
    #endregion

    #region Impulses DON'T GIVE TO YOUR IMPULSES LUKE!
    private void ApplyForwardImpulse()
    {
        rb.AddForce(new Vector3(1f, 0f, 0f) * forwardImpulsePower * Time.deltaTime * -1f, ForceMode.Impulse);
    }

    private void ApplyHorizontalImpulse(float moveX)
    {
        rb.AddForce(new Vector3(0f, 0f, moveX) * horizontalImpulsePower * Time.deltaTime, ForceMode.Impulse);
    }

    private void ApplyDownwardImpulse()
    {
        rb.AddForce(new Vector3(0f, -1f, 0f) * downwardImpulsePower * Time.deltaTime, ForceMode.Impulse);
    }

    private void ApplyUpwardImpulse()
    {
        rb.AddForce(new Vector3(0f, 1f, 0f) * upwardImpulsePower * Time.deltaTime, ForceMode.Impulse);
    }
    #endregion


    private void SetBasicValues()
    {
        e_forwardForce = forwardForce;
        e_horizontalForce = horizontalForce;
        e_downwardForce = downwardForce;
        e_upwardForce = upwardForce;
    }


    /// <summary>
    /// Prints Details About ball status
    /// </summary>
    private void PrintDetails()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log(rb.GetPointVelocity(transform.position));
            Debug.Log(rb.velocity);
        }
    }
}
