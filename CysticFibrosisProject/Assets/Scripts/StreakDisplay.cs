using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StreakDisplay : MonoBehaviour {

    public SO_DayManager so_DayManager;
    private Text streakText;

	// Use this for initialization
	void Start () {

        streakText = GetComponent<Text>();

	}
	
	//will be called by the 
	void Update () {
        streakText.text = "Streak: " + so_DayManager.DayStreak.ToString() + "\nMy Best: " + so_DayManager.LongestStreak.ToString();

    }
}
