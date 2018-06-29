using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayViewer : MonoBehaviour {

    public float gunRange = 50f;
    public Camera fpsCamera;


	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 lineOrigin = fpsCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
        Debug.DrawRay(lineOrigin, fpsCamera.transform.forward * gunRange, Color.green);

	}
}
