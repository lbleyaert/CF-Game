using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Text dialogueText;
    public Dialogue houseDialogue;

    [SerializeField] private Image dialogBox;
    

    private Queue<string> queuedSentences;



	// Use this for initialization
	void Start () {
        queuedSentences = new Queue<string>();
	}


    public void StartHouseDialog()
    {
        //show the dialogue box for the house option
        dialogBox.gameObject.SetActive(true);

        queuedSentences.Clear();

        foreach (string sentence in houseDialogue.sentences)
        {
            queuedSentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    /*
	public void StartDialogue(Dialogue dialogue)
    {
       // dialogBox.enabled = true;
        Debug.Log("Starting the following dialogue: " + dialogue.dialogueName);

        queuedSentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            queuedSentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }
    */

    public void DisplayNextSentence()
    {
        if(queuedSentences.Count == 0)
        {
            //once dialog is done (no more sentences left), enter the game scene
            //EndDialogue();
            SceneManager.LoadScene("Nebulizer3");
            return;
        }
        string sentence = queuedSentences.Dequeue();
        //Debug.Log(sentence);
        dialogueText.text = sentence;

    }

    public void EndDialogue()
    {
        Debug.Log("end of dialogue");
    }




}
