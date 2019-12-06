using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject destroyed;

    public Vector3 position;
    public Vector3 rotation;

    private void Update()
    {
        position = this.transform.position;
        rotation = this.transform.eulerAngles;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Panda")
        {
            Instantiate(destroyed, transform.position, Quaternion.Euler(rotation));
            Destroy(this.gameObject);
        }
    }
}
