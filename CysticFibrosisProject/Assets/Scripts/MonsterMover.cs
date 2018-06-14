using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMover : MonoBehaviour {


    private float minTarX = -20;
    private float maxTarX = 20;
    private float tarX;

    private Rigidbody rb;


	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0.0f, 0.0f, -3.0f);

	}
	
	// Update is called once per frame
	void Update () {
		


	}
}
