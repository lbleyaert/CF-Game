using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class DayNightCycle : MonoBehaviour {


    private float timeToWait = 60f;

    private Transform sunTransform;
    
    private string timeOfDay;
    private int currentHr;
    private int currentMin;
    

	// Use this for initialization
	void Start () {

        //get the sun's transform so that we can make changes to its rotation
        sunTransform = GetComponent<Transform>();

        //the method RotateSun is invoked every 60 seconds 
        InvokeRepeating("RotateSun", 0.0f, 60f);
     
    }


        public void RotateSun()
    {
        timeOfDay = System.DateTime.Now.ToString("tt");
        currentHr = System.DateTime.Now.Hour;
        currentMin = System.DateTime.Now.Minute;

        int amOrPm;
        //if it is 12 (midnight or noon) we want the hr variable set to zero for equation
        if (currentHr == 12)
        {
            currentHr = 0;
            //Debug.Log("its 12! (am or pm)");
            //Debug.Log("currentHr var set to zero bc its 12");
        }

        if (timeOfDay.Equals("AM"))
        {
            //Debug.Log("time of day evaluated to am!");
            amOrPm = 12;

        }
        else
        {
            //Debug.Log("time of day evaluated to pm!");
            amOrPm = 0;
            //if its PM, but NOT 12pm, need to subtract 12 from the hr - that way 13pm will be 1pm etc.
            if (currentHr != 0)
            {
                currentHr -= 12;
            }

        }

        float degreesOfRotation = 90f + (15f * (currentHr + amOrPm)) + (0.25f * currentMin);
        //Debug.Log("degrees rotation: " + degreesOfRotation);
        sunTransform.eulerAngles = new Vector3(degreesOfRotation, 90f, 0f);

    }

}


/* Used tutorial for the idea of using 2 directional lights ("sun" and "moon")
 * https://www.youtube.com/watch?v=K_F9aYkEBtc
 */
