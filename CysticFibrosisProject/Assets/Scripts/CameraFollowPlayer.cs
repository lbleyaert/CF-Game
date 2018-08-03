using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {

    public Transform playerTransform;
    [Range(0.01f, 1.0f)]
    public float smoothFactor = 0.5f;
    //public bool lookAtPlayer = false;

    private Vector3 cameraOffset;



	// Use this for initialization
	void Start () {

        cameraOffset = transform.position - playerTransform.position;

	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newPos = playerTransform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);

	}
}

/*Tutorial used for camera following player:
 * https://www.youtube.com/watch?v=urNrY7FgMao
 */
