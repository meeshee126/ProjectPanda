using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScene : MonoBehaviour
{
    CameraManager cameraManager;

    void Start()
    {
        cameraManager = GameObject.Find("Main Camera").GetComponent<CameraManager>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Panda")
        {
            cameraManager.lerpSpeed = 0f;
            cameraManager.xOffset = 8;
            cameraManager.yOffset = 14;
        }
    }
}
