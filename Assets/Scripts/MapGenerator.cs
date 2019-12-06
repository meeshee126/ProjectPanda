using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField]
    List<GameObject> ramps = new List<GameObject>();

    Mesh mesh;

    public Vector3 size;

    void Start()
    {
        mesh = ramps[0].GetComponent<MeshFilter>().mesh;

        size =  new Vector3 (mesh.bounds.extents.x * 2, mesh.bounds.extents.y * 2, mesh.bounds.extents.z * 2);
        
        //Instantiate(ramps[Random.Range(0, ramps.Count)]);
    }

    void Update()
    {
        
    }
}
