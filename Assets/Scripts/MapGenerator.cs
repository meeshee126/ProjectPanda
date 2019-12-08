using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    RampList rampList;

    List<GameObject> ramps;

    Mesh mesh;

    public Vector3 spawnPostion;

    GameObject ramp;

    void Start()
    {
        rampList = GameObject.Find("GameManager").GetComponent<RampList>();
        ramps = rampList.ramps;
        mesh = GetComponent<MeshFilter>().sharedMesh;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Panda" && this.gameObject.name == "TutorialTerrain")
        {
            spawnPostion = new Vector3(-141.8f, 4.48f, 0);
            ramp = Instantiate(ramps[Random.Range(0, ramps.Count)], this.transform.position + spawnPostion, Quaternion.Euler(0f,0, -15f), GameObject.Find("Ramps").transform);
            ramp.AddComponent<MapGenerator>();
            Destroy(this);
        }

        else if (other.name == "Panda")
        {
            spawnPostion = new Vector3(-127.74f, 0, 0);
            ramp = Instantiate(ramps[Random.Range(0, ramps.Count)], this.transform.position + spawnPostion, Quaternion.Euler(0f, 0, -15f), GameObject.Find("Ramps").transform);
            ramp.AddComponent<MapGenerator>();
          //  Destroy(this);
        }
    }
}
