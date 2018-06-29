using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerArrowMove : MonoBehaviour {

    public Animator animator;
    //public NavMeshAgent agent;
    public float speed = 5f;
    float dirZ, dirX;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        dirZ = CrossPlatformInputManager.GetAxis("Vertical") * speed * Time.deltaTime;
        dirX = CrossPlatformInputManager.GetAxis("Horizontal") * speed * Time.deltaTime;

        transform.position = new Vector3(transform.position.x + dirX, transform.position.y, transform.position.z + dirZ);

	}








}
