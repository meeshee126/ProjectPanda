using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panda : MonoBehaviour
{
    public float tourqueForce;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Movement();
        ApplyForwardForce();
    }

    void Movement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");

        rb.AddForce(new Vector3(moveX, 0, 0) * tourqueForce * Time.deltaTime, ForceMode.Force);
        //rb.AddTorque(new Vector3(moveX, 0, 0) * tourqueForce * Time.deltaTime, ForceMode.Force);
     
    }


    /// <summary>
    /// GAS GAS GAS IM GONNA STEP ON THE GASSS
    /// </summary>
    private void ApplyForwardForce()
    {
        rb.AddForce(new Vector3(0f, 0f, 1f) * tourqueForce * Time.deltaTime, ForceMode.Force);
    }

    private void PrintDetails()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log(rb.GetPointVelocity(transform.position));
        }
    }
}
