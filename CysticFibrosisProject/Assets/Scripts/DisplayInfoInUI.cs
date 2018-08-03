using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInfoInUI : MonoBehaviour {

    /******NOT OPTIMAL SOLUTION****** 
     *not efficient to have have these UI elements updated using the Update() method
     *Would be better to tie events to the changes of these values - only update when a change occurs
     */

    //needs to communicate with the SO_DayManager to get information about streaks
    public SO_DayManager so_DayManager;
    //needs to communicate with the SO_TaskManager to get information about how many tasks are complete (and total num of tasks)
    public SO_TaskManager so_TaskManager;
    public SO_CoinManager so_CoinManager;

    public Text streakText;
    public Text coinText;
    public Image progressWheelFill;
    public Text progressText;

    private int percentage;

	//will update the UI info such as the streak numbers and day progress 
	void Update () {

        streakText.text = "Streak: " + so_DayManager.DayStreak.ToString() + "\nMy Best: " + so_DayManager.LongestStreak.ToString();
        
        progressWheelFill.fillAmount =  (float)so_TaskManager.NumOfTasksComplete / so_TaskManager.taskList.Count;

        percentage = (int) (((float)so_TaskManager.NumOfTasksComplete / so_TaskManager.taskList.Count) * 100.00);
        progressText.text = percentage + "% Done Today!";
        Debug.Log(percentage + "% of tasks completed");

        coinText.text = "Coins: " + so_CoinManager.numOfCoins;
    }
}


/*Tutorial used for the task wheel UI element:
 * https://www.youtube.com/watch?v=f6dEj7-G-Fw
 */
