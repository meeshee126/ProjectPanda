using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScene : MonoBehaviour
{
   public CameraManager cameraManager;
   public Panda panda;


    void Start()
    {
        panda = GameObject.Find("Panda").GetComponent<Panda>();
        cameraManager = GameObject.Find("Main Camera").GetComponent<CameraManager>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Panda")
        {
            cameraManager.lerpSpeed = 0.1f;
            cameraManager.xOffset = 8;
            cameraManager.yOffset = 30;

            other.gameObject.GetComponent<Panda>().enabled = false;
        }
    }
}
