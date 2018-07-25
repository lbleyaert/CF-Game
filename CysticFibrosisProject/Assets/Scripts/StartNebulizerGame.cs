using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartNebulizerGame : MonoBehaviour {

    public Text dialogueText;
    public SO_Dialogue nebulizerDialogue;
    public DialogueManagerSO dialogManagerSO;

    //will need to have one of these in each scene... need to ref in each scene
    [SerializeField] private Image dialogueBox;

    //if player comes into contact with the box
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("you've touched the nebulizer!");
            dialogManagerSO.StartADialogue(nebulizerDialogue, dialogueBox, dialogueText);
          
        }
    }

}
