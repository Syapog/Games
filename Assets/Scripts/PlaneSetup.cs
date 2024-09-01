using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSetup : MonoBehaviour
{
    public bool show=true;
    public bool solid=true;

    void Start()
    {
        if (!show)  { GetComponent<MeshRenderer>().enabled = false; }
        if (!solid) { GetComponent<MeshCollider>().enabled = false; }
    }
    void Update()
    {
        
    }
}
