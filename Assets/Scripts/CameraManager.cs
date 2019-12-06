using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    Transform panda;

    [SerializeField]
    float lerpSpeed, xOffset, yOffset, zOffset;

    void Start()
    {
      

        panda = GameObject.Find("Panda").GetComponent<Transform>();

        this.transform.position = panda.position;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPanda();
    }

    public void FollowPanda()
    {
        Vector3 offset = new Vector3(xOffset, yOffset, zOffset);

        Vector3 lerp = Vector3.Lerp(transform.position, panda.position + offset, lerpSpeed * Time.deltaTime);

        transform.position = lerp;

        transform.LookAt(panda.position);
    }
}
