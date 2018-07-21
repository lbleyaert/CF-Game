using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[CreateAssetMenu]
public class DialogueManagerSO : ScriptableObject
{
    private Queue<string> queuedSentences = new Queue<string>();
    private string sceneName;

    //takes a dialogue, scene name, and an image/text for displaying the dialogue
    //will first play the dialogue and then will transition to the next scene
    public void StartADialogue(Dialogue dialogue, string sceneName, Image dialogueBox, Text dialogueText)
    {
        //Debug.Log("Dialogue Started! Scene name: " + sceneName);
        this.sceneName = sceneName;
        dialogueBox.gameObject.SetActive(true);

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

        DisplayNextSentence(dialogueText);
    }


    /// <summary>
    /// Displays the sentences of the dialogue one at a time - if there are no sentences left, the indicated scene will load
    /// </summary>
    /// <param name="dialogueText">Text object where the sentences will be shown</param>
    /// <param name="sceneName">Name of the scene that should be transitioned to</param>
    public void DisplayNextSentence(Text dialogueText)
    {
        if (queuedSentences.Count == 0)
        {
            SceneManager.LoadScene(this.sceneName);
            //Debug.Log("end of dialogue!");
            return;
        }
        string sentence = queuedSentences.Dequeue();
        //Debug.Log(sentence);
        dialogueText.text = sentence;

    }



}
