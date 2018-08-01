using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueNamespace
{
    [CreateAssetMenu]
    public class SO_StartDialogue : ScriptableObject
    {

        private Dialogue dialogue;
        private GameObject dialogueWindow;

        public GameObject nodeText;

        public GameObject responsePanel;

        public GameObject btnOptionOne;
        public GameObject btnOptionTwo;
        public GameObject btnOptionThree;

        //set to 'currently no option selected'
        private int selectedOption = -2;

        //string of path for the specific dialogue
        private string dialogueDataFilePath;

        public GameObject dialogueWindowPrefab;

        //take string file path
        //load the dialogue into the _Dialogue field of the SO_StartDialogue

        public void StartSpecificDialogue(string path)
        {
            dialogue = Dialogue.LoadDialogue("Assets/DialogueXMLs/" + path);


            //Debug.Log("gonna create a _dialogue using the path: " + path);
            
            
            GameObject canvas = GameObject.Find("Canvas");

            /*
             * maybe check here if the dialogueWindow has already been instantiated? could get error if so
             */

            dialogueWindow = Instantiate<GameObject>(dialogueWindowPrefab);

            dialogueWindow.transform.SetParent(canvas.transform, false);

            dialogueWindow.transform.localPosition = new Vector3(0, 0, 0);

            nodeText = GameObject.Find("DialogueText");
            responsePanel = GameObject.Find("ResponsePanel");
            btnOptionOne = GameObject.Find("BtnOption1");
            btnOptionTwo = GameObject.Find("BtnOption2");
            btnOptionThree = GameObject.Find("BtnOption3");

            responsePanel.transform.localPosition = new Vector3(0, -115, 0);

            //int nodeID = 0;

            Debug.Log("number of nodes in this dialogue: " + dialogue.nodes.Count);
            DisplayNode(dialogue.nodes[0]);




            // dialogueWindow.SetActive(false); 
            //call run dialogue method 
        }

        public void RunDialogue()
        {
            //can't do coroutine in a scriptable object!!!!
            //need to find other way
        }

        private void SetSelectedOption(int x)
        {
            selectedOption = x;
            Debug.Log("integer passed into SetSelectedOption is: " + selectedOption);
            if (selectedOption != -1)
            {
                // selectedOption = x;
                Debug.Log("destination node JUST SET TO: " + selectedOption);
                DisplayNode(dialogue.nodes[selectedOption]);
                //return selected option to -2 (no selection)
                selectedOption = -2;
            }
            else
            {
                //if it is equal to -1, means we're done with the dialogue 
                Debug.Log("end of the dialogue :D :D :D");

            }

        }

        /*
        public IEnumerator DialogueCoroutine()
        {
            //dialogueWindow.SetActive(true);
            int nodeID = 0;

            //while you're referencing an actual node and (and not the exit node indicated by id of -1)
            while (nodeID != -1)
            {
                //display node function
                DisplayNode(dialogue.Nodes[nodeID]);
                //selectedOption is set to int that doesn't represent a node ID (-2) 
                selectedOption = -2;
                //while the selectedOption is -2 (meaning while the user hasn't inputted a selection)
                while(selectedOption == -2)
                {
                    yield return new WaitForSeconds(0.25f);
                }
            }

            //once an exit node (-1) has been selected, the dialogue is done and you'll leave the above while loop
            //want to hide the dialogueWindow
            dialogueWindow.SetActive(false);

        }
        */

        public void DisplayNode(DialogueNode node)
        {
            nodeText.GetComponent<Text>().text = node.sentence;
            Debug.Log("number of options in the current node's options array: " + node.options.Count);

            //clear all listeners from the previous 
            btnOptionOne.GetComponent<Button>().onClick.RemoveAllListeners();
            btnOptionTwo.GetComponent<Button>().onClick.RemoveAllListeners();
            btnOptionThree.GetComponent<Button>().onClick.RemoveAllListeners();

            //set all to false - following for loop will loop through the number of options in the current node
            //depending on how many options are available, it will set up the correct amount of buttons and connect
            //them with their corresponding option
            btnOptionOne.SetActive(false);
            btnOptionTwo.SetActive(false);
            btnOptionThree.SetActive(false);

            //max number of option buttons is 3, so the highest your index could be is 2 - OR statement checks that
            for (int i = 0; i < node.options.Count; i++)
            {
                //  Debug.Log("i is currently: " + i);
                switch (i)
                {
                    case 0:
                        SetOptionButton(btnOptionOne, node.options[i]);
                        break;
                    case 1:
                        SetOptionButton(btnOptionTwo, node.options[i]);
                        break;
                    case 2:
                        SetOptionButton(btnOptionThree, node.options[i]);
                        break;
                }
            }

        }


        private void SetOptionButton(GameObject button, DialogueOption option)
        {
            Debug.Log("Destination node of " + button.name + "is :" + option.destinationNodeID);
            button.SetActive(true);
            button.GetComponentInChildren<Text>().text = option.response;
            //button.GetComponent<Button>.onClick

            button.GetComponent<Button>().onClick.AddListener(delegate { SetSelectedOption(option.destinationNodeID); });
        }



    }
}



/*Used a tutorial for dialogue structure: 
 * LarsIsGaming 
 * https://www.youtube.com/watch?v=wnhvu99A1tg
 * https://www.youtube.com/watch?v=ILQND0Mb9TQ
 * Used classes (Dialogue, DialogueOption, and DialogueNode) as shown as well as the xml file structure, but created a 
 * scriptable object for controlling the dialogue rather 
 */
