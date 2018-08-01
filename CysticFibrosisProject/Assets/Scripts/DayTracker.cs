using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class DayTracker : MonoBehaviour {

    public static DayTracker instance = null;

    public SO_DayManager so_DayManager;

    private DateTime currentDateTime;
    private DateTime previousDateTime;

	//an invoke repeating for checking the day - will send info to the SO_DayManager to store
	void Awake () {

        if (instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

       // CheckDay();

	}

    public void CheckDay()
    {

        if(previousDateTime != null)
        {
            Debug.Log("prev is currently set to: " + previousDateTime.ToString());
        }

        //previouseDateTime = currentDateTime;
        currentDateTime = DateTime.Now;
        Debug.Log("current date/time is: " + currentDateTime.ToString());

        int year = currentDateTime.Year;
        int month = currentDateTime.Month;
        int day = currentDateTime.Day;

        //Debug.Log("Year: " + year + "\nMonth: " + month + "\nDay: " + day);


        //if previous year is less than current year, then day MUST have changed
        if(previousDateTime.Year < currentDateTime.Year)
        {
            //call a method of the day manager to change day? 
            
        }
        //otherwise, if the year didn't change, then look at the month
        //if the the previous MONTH is less than the current month, then the day MUST HAVE changed
        else if(previousDateTime.Month < currentDateTime.Month)
        {
            //call method of day manager b/c day has changed
        }

        //otherwise, if year and month didnt change, then check diff between Days of the two DateTime structs
        else if(previousDateTime.Day < currentDateTime.Day)
        {
            //call the method
        }


        previousDateTime = currentDateTime;

        Debug.Log("previous date/time just var set to: " + previousDateTime.ToString());

    }




}


/*Singleton pattern:
 * https://unity3d.com/learn/tutorials/projects/2d-roguelike-tutorial/writing-game-manager
 */
