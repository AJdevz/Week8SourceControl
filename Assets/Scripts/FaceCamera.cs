using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    public Transform theCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(theCamera.position);
    }
}