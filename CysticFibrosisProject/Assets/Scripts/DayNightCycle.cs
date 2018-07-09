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

        //StartCoroutine(RotateSunRoutine());
     

    }
	
	// Update is called once per frame
	void Update () {
        
 
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
            Debug.Log("currentHr var set to zero bc its 12");
        }

        if (timeOfDay.Equals("AM"))
        {
            Debug.Log("time of day evaluated to am!");
            amOrPm = 12;

        }
        else
        {
            Debug.Log("time of day evaluated to pm!");
            amOrPm = 0;
            //if its PM, but NOT 12pm, need to subtract 12 from the hr - that way 13pm will be 1pm etc.
            if (currentHr != 0)
            {
                currentHr -= 12;
            }

        }

        float degreesOfRotation = 90f + (15f * (currentHr + amOrPm)) + (0.25f * currentMin);
        Debug.Log("degrees rotation: " + degreesOfRotation);
        sunTransform.eulerAngles = new Vector3(degreesOfRotation, 90f, 0f);



    }

    IEnumerator RotateSunRoutine()
    {
        timeOfDay = System.DateTime.Now.ToString("tt");
        currentHr = System.DateTime.Now.Hour;
        currentMin = System.DateTime.Now.Minute;

        int amOrPm;
        //if it is 12 (midnight or noon) we want the hr variable set to zero for equation
        if (currentHr == 12)
        {
            currentHr = 0;
            Debug.Log("currentHr var set to zero bc its 12");
        }

        if (timeOfDay.Equals("AM"))
        {
            Debug.Log("time of day evaluated to am!");
            amOrPm = 12;

        }
        else
        {
            Debug.Log("time of day evaluated to pm!");
            amOrPm = 0;
            //if its PM, but NOT 12pm, need to subtract 12 from the hr - that way 13pm will be 1pm etc.
            if (currentHr != 0)
            {
                currentHr -= 12;
            }

        }

        float degreesOfRotation = 90f + (15f * (currentHr + amOrPm)) + (0.25f * currentMin);
        Debug.Log("degrees rotation: " + degreesOfRotation);
        sunTransform.eulerAngles = new Vector3(degreesOfRotation, 90f, 0f);


        yield return new WaitForSeconds(timeToWait);

    }





    //Debug.Log("ToSHortTimeString: " + System.DateTime.Today.ToShortTimeString());
    //Debug.Log("Time of day: " + System.DateTime.Today.TimeOfDay.ToString());
    //       myTimeSpan = new TimeSpan();

    //Debug.Log("Time: " + myTimeSpan.ToString());
    //StartCoroutine(WaitForSomeTime());
    //Debug.Log("Time2: " + myTimeSpan.ToString());

    //Debug.Log("Time: " + timeSpan.ToString());

    //Debug.Log(System.DateTime.Now.ToString());


    //get string stating am or pm
    //      timeOfDay = System.DateTime.Now.ToString("tt");
    //Debug.Log("Time of Day: " + timeOfDay);
    // Debug.Log("Current date and time: " + myDateTime);        
    //      currentHr = System.DateTime.Now.Hour;
    //      currentMin = System.DateTime.Now.Minute;


    // Debug.Log("Hour: " + currentHr + " and Minute: " + currentMin);
    // RotateSun(currentHr, currentMin, timeOfDay);


    //Debug.Log("Hour: " + hour + " and Minute: " + minute);


    //Debug.Log("Time: " + myTimeSpan.ToString());
    //StartCoroutine(WaitForSomeTime());





}
