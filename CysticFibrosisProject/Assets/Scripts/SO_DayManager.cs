using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SO_DayManager : ScriptableObject {

    public SO_TaskManager so_TaskManager;


    [SerializeField]
    private int totalDaysPlayed;
    //number of days in a row that the player has completed the tasks
    [SerializeField]
    private int dayStreak;
    public int DayStreak
    {
        get { return dayStreak; }
    }
    [SerializeField]
    private int longestStreak = 0;
    public int LongestStreak
    {
        get { return longestStreak; }
    }


    /// <summary>
    /// When this method is called, the totalDaysPlayed variable is increased by 1.  The following if statement checks to
    /// see if they have completed all of their tasks (the number completed equals the total number), then they will 
    /// </summary>
    public void DayHasChanged()
    {
        totalDaysPlayed++;
        //if the player completes all of the tasks, then a day gets added to their dayStreak.  
        if(so_TaskManager.NumOfTasksComplete == so_TaskManager.taskList.Count)
        {
            Debug.Log("you completed all tasks today (notification from daymanager!");
            dayStreak++;
            if(dayStreak > longestStreak)
            {
                longestStreak = dayStreak;
            }
            //some sort of "good job" notification
        }
        else
        {
            Debug.Log("Day streak back to 0!");
            dayStreak = 0;
        }

        
        so_TaskManager.ResetTasks();
        Debug.Log("tasks should be reset for the new day");

        
    }




}

/*Tutorial used to learn about the use of properties:
 * https://unity3d.com/learn/tutorials/topics/scripting/properties
 */
