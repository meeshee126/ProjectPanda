using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject destroyed;

    public Vector3 position;
    public Vector3 rotation;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        position = this.transform.position;
        rotation = this.transform.eulerAngles;
    }
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Panda")
        {
          // this.gameObject.SetActive(false);

            

            BoxCollider[] colliders = GetComponents<BoxCollider>();

            foreach (BoxCollider collider in colliders)
            {
                collider.enabled = false;
            }
            Instantiate(destroyed, transform.position, Quaternion.Euler(rotation));
            Destroy(this.gameObject);
        }
    }
    */

   /* private void OnCollisionEnter(Collision collision)
    {

        if(collision.collider.name == "Panda")
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
    */

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
