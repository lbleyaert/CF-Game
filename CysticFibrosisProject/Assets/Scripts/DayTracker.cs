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

        //call the CheckDay() method every 60 seconds
        InvokeRepeating("CheckDay", 30.0f, 60.0f);

	}

    /// <summary>
    /// This method compares the previousDateTime var (stored on the last iteration of CheckDay) with the currentDateTime var, which is populated
    /// by DateTime.Now.  if the previous date is less than the current date (checking year, then month, then date), then it will trigger the 
    /// DayHasChanged() method of the SO_DayManager.  After this check, the previousDateTime is set to the currentDateTime that was pulled during
    /// this iteration of the method
    /// </summary>
    public void CheckDay()
    {

        if(previousDateTime != null)
        {
            Debug.Log("prev is currently set to: " + previousDateTime.ToString());
        }

        currentDateTime = DateTime.Now;
        Debug.Log("current date/time is: " + currentDateTime.ToString());

       
     
        //if previous year is less than current year, then day MUST have changed
        if(previousDateTime.Year < currentDateTime.Year)
        {
            so_DayManager.DayHasChanged();
            
        }
        //otherwise, if the year didn't change, then look at the month
        //if the the previous MONTH is less than the current month, then the day MUST HAVE changed
        else if(previousDateTime.Month < currentDateTime.Month)
        {
           so_DayManager.DayHasChanged();
        }

        //otherwise, if year and month didnt change, then check diff between Days of the two DateTime structs
        else if(previousDateTime.Day < currentDateTime.Day)
        {
           so_DayManager.DayHasChanged();
           Debug.Log("DAY CHANGED :D :D :D :D");
        }
       

        previousDateTime = currentDateTime;

        Debug.Log("previous date/time just var set to: " + previousDateTime.ToString());

    }




}


/*Singleton pattern tutorial:
 * https://unity3d.com/learn/tutorials/projects/2d-roguelike-tutorial/writing-game-manager
 */
