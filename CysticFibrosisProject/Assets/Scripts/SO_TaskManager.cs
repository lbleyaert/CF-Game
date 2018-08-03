using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SO_TaskManager : ScriptableObject {

    //currently there is only one task (the nebulizer game)
    //when a task (minigame) is added, increase list size and add the SO task instance
    public List<SO_Task> taskList;

    //access coin manager so you can add coins when tasks are completed
    public SO_CoinManager so_CoinManager;

    [SerializeField]
    private int numOfTasksComplete = 0;
    public int NumOfTasksComplete
    {
        get { return numOfTasksComplete; }
    }


    public void TaskComplete()
    {
        Debug.Log("Task Completed! var incremented by 1");
        numOfTasksComplete++;
        so_CoinManager.AddCoins(10);
       // Debug.Log("PROGRESS: " + NumOfTasksComplete + " out of " + taskList.Count);
    }
	

    public void ResetTasks()
    {
        numOfTasksComplete = 0;
        //iterate through the list of tasks - return their isCompleteToday booleans to false
        foreach (SO_Task task in taskList)
        {
            task.isCompleteToday = false;
        }
    }
}

