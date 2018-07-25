using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[CreateAssetMenu]
public class DialogueManagerSO : ScriptableObject
{

    public Button continueButton;
    public Button yesButton;
    public Button noButton;
    public Button soonButton;

    private Queue<string> queuedSentences = new Queue<string>();
    [SerializeField]
    private string sceneName;
    [SerializeField]
    private bool hasQuestionAtEnd;
    [SerializeField]
    private Image dialogueBox;
    [SerializeField]
    private Text dialogueText;


    //takes a dialogue, scene name, and an image/text for displaying the dialogue
    //will first play the dialogue and then will transition to the next scene
    public void StartADialogue(SO_Dialogue dialogue, Image myDialogueBox, Text myDialogueText)
    {
        //Debug.Log("Dialogue Started! Scene name: " + sceneName);
        this.hasQuestionAtEnd = dialogue.hasQuestionAtEnd;
        if (dialogue.hasSceneChange)
        {
            sceneName = dialogue.nextSceneName;
        }
        else
        {
            sceneName = "";
        }
        
        myDialogueBox.gameObject.SetActive(true);

        

        queuedSentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            queuedSentences.Enqueue(sentence);
        }
        /*
        while(queuedSentences.Count != 0)
        {
            string sentence = queuedSentences.Dequeue();
            dialogueText.text = sentence;
        }
        */

        DisplayNextSentence(myDialogueText);
    }


    //use of scriptable object that utilizes the DialogueManager SO properties!! try startADialogue without having to pass 
    //in the different UI parts :D 
    public void StartADialogueSolo(SO_Dialogue dialogue)
    {
        //Debug.Log("Dialogue Started! Scene name: " + sceneName);
        //if there is a scene change, the name of the scene will be placed in the sceneName var of the DialogueManager
        if (dialogue.hasSceneChange)
        {
            sceneName = dialogue.nextSceneName;
        }
        //if there is no scene change, the sceneName var is set to an empty string
        else
        {
            sceneName = "";
        }
        dialogueBox.gameObject.SetActive(true);


        queuedSentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            queuedSentences.Enqueue(sentence);
        }
  

        DisplayNextSentence(dialogueText);
    }





    /// <summary>
    /// Displays the sentences of the dialogue one at a time - if there are no sentences left, the indicated scene will load
    /// </summary>
    /// <param name="dialogueText">Text object where the sentences will be shown</param>
    /// <param name="sceneName">Name of the scene that should be transitioned to</param>
    public void DisplayNextSentence(Text dialogueText)
    {
        //if there's one sentence left . . . want to open up the y/n button option????
        if (queuedSentences.Count == 1)
        {
            Debug.Log("there's one sentence left in the queue");
            if (hasQuestionAtEnd)
            {
                //set continue btn active to FALSE 
                //continueButton.gameObject.SetActive(false);
                //yesButton.gameObject.SetActive(true);
                //noButton.gameObject.SetActive(true);
                //soonButton.gameObject.SetActive(true);
                //set the other buttons active to TRUE
                
            }
        }
        //if there are no sentences left and there's a scene to transition to (not an empty string)
        //then transition to the scene
        if (queuedSentences.Count == 0 && this.sceneName != "")
        {
            SceneManager.LoadScene(this.sceneName);
            //Debug.Log("end of dialogue!");
            return;
        }
        else if(queuedSentences.Count == 0 && this.sceneName == "")
        {
            dialogueBox.gameObject.SetActive(false);
        }

        string sentence = queuedSentences.Dequeue();
        //Debug.Log(sentence);
        dialogueText.text = sentence;

    }



}
