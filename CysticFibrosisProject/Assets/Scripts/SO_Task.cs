using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SO_Task : ScriptableObject {

    public SO_TaskManager so_TaskManager;

    public string taskName;
    public bool isCompleteToday = false;
    //a "coins to add" field and method that does that for you?

    //public delegate void MyAction();
    //public static event MyAction OnTaskCompletion;

    //when a task is complete, this method should be called.  It will change the boolean var to true (the task IS complete today) 
    //it will also call the OnTaskCompletion event - this 
    public void TaskComplete()
    {
        //if isCompleteToday is false when this method is called.. then the event and change to the boolean will occur
        //if it's already evaluated to true, we don't need to notify the SO_TaskManager - it's already aware that the task was completed
        if (!isCompleteToday)
        {
            isCompleteToday = true;
            so_TaskManager.TaskComplete();
            Debug.Log("you completed a task! Now calling the TaskComplete method of the " + taskName + " task!");

            /*
            if (OnTaskCompletion != null)
            {
                //OnTaskCompletion();
                Debug.Log("OnTaskCompletion event was just invoked!");
            }
            */
        }

    }


}

/*Tutorial used to learn about events and event subscription:
 * https://unity3d.com/learn/tutorials/topics/scripting/events?playlist=17117
 */
