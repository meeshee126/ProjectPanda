using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Panda")
        {
            BoxCollider[] colliders = GetComponents<BoxCollider>();

            foreach (BoxCollider collider in colliders)
            {
                collider.enabled = false;
            }

            Rigidbody[] rbs = GetComponentsInChildren<Rigidbody>();

            foreach (Rigidbody rb in rbs)
            {
                rb.isKinematic = false;
            }
        }
    }
}
