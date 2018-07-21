using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class DoorToHouse : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("you've entered the door!");
            SceneManager.LoadScene("House");
        }
    }
}
