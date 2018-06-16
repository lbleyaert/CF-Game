﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour {

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
        }		
	}
}
