using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGate : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Panda")
        {
            Transform[] trees = GetComponentsInChildren<Transform>();

            foreach (Transform tree in trees)
            {
                if (tree.name.Contains("_tree"))
                {
                    tree.localScale = new Vector3(0.01f, 0.01f, 0.01f);
                }
            }

            Destroy(this);
        }
    }
}
