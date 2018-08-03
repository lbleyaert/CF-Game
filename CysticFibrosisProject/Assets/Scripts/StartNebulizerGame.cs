using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DialogueNamespace;

public class StartNebulizerGame : MonoBehaviour
{
    public SO_StartDialogue so_StartDialogue;
    public string xmlFileName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("you've touched the nebulizer!");
            so_StartDialogue.StartSpecificDialogue(xmlFileName);
        }
    }

}
