using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToTown : MonoBehaviour {
    private const string SceneName = "TownPersistent";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("you've entered the door!");
            SceneManager.LoadScene(SceneName);
        }
    }
}
