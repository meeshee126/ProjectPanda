using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panda : MonoBehaviour
{
    [SerializeField]
    float tourqueForce;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Movement();
        ApplyForwardTourque();
    }

    void Movement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");

        rb.AddTorque(new Vector3(moveX, 0, 0) * tourqueForce * Time.deltaTime, ForceMode.Impulse);
     
    }

    private void ApplyForwardTourque()
    {
        rb.AddTorque(new Vector3(0f, 0f, 1f) * tourqueForce * Time.deltaTime, ForceMode.Force);
    }
}
