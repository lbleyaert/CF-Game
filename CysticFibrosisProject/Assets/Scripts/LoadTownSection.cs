using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadTownSection : MonoBehaviour {

    //[SerializeField] private Image houseDialogueImg;
   // public Dialogue dialogue;
    

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        /*
        foreach(Touch touch in Input.touches)
        {
            
            if(touch.phase == TouchPhase.Began)
            {
                //Debug.Log("Position: " + touch.position.x + " " + touch.position.y);
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
         
                RaycastHit hit;

                if(Physics.Raycast(ray, out hit))
                {
                    if(hit.transform.name == "House")
                    {
                        //Debug.Log("hit the house!");
                        TriggerDialogue();

                    }
                    //else if.... hit other places... pharmacy etc


                }

            }//end of touchphase if


        }//end of foreach
        */



		
	}


    


    public void TriggerDialogue()
    {
       // FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }







}
