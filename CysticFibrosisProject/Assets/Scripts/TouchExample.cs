using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchExample : MonoBehaviour {

    public Text touchText;

    private Touch myTouch;
   

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.touchCount > 0)
        {

            myTouch = Input.GetTouch(0);
            //strTouchPosition = myTouch.position.ToString();

            //touchText.text = "Touch x Position: " + myTouch.position.x;

            touchText.text = "Touch Position: " + myTouch.position.ToString();




        }

    }
}
