using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SO_TaskManager : ScriptableObject {

    //currently there is only one task (the nebulizer game)
    //when a task (minigame) is added, this number should be increased MANUALLY by 1 in the inspector 
    //public int totalNumTasks;
    public List<SO_Task> taskList;
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
        Debug.Log("PROGRESS: " + NumOfTasksComplete + " out of " + taskList.Count);
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

