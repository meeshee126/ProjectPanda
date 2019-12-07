using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRamp : MonoBehaviour
{
    GameObject panda;

    void Start()
    {
        panda = GameObject.Find("Panda");
    }

    void Update()
    {
        if(Vector3.Distance(this.transform.position, panda.transform.position) > 190)
        {
            Destroy(this.gameObject);
        }

    }
}
