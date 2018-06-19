using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverManager : MonoBehaviour {

    private float pauseSeconds = 3.0f;

    public PlayerHealth playerHealth;

    Animator anim;


	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if(playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("GameOver");
            //wait a few seconds, then go to next scene
            StartCoroutine(BackToTownScene());
        }		
	}


    IEnumerator BackToTownScene()
    {
        yield return new WaitForSeconds(pauseSeconds);
        SceneManager.LoadScene("Town");
    }





}
