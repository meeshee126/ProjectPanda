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
        if (panda == null)
            return;

        if(Vector3.Distance(this.transform.position, panda.transform.position) > 220)
        {
            Destroy(this.gameObject);
        }

    }
}
