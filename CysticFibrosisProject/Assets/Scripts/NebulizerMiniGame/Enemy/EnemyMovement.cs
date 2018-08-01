using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

    private Transform player;
    private PlayerHealth playerHealth;
    private EnemyHealth enemyHealth;
    private NavMeshAgent nav;


	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {

        //before setting the enemy's destination to the player each update, this checks first if the enemy AND the player are both alive
        if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            nav.SetDestination(player.position);
        }
        else
        {
            nav.enabled = false;
        }

        

	}
}
