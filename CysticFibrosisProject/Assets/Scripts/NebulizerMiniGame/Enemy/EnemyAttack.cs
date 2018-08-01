using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public float timeBetweenAttacks = 1.0f;
    public int attackDamage = 10;

    Animator anim;
    GameObject player;
    //enemy's reference to the playerHealth script
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;

	// Use this for initialization
	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();

	}
	
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = true;
        }
    }


     void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = false;
        }
    }



    // Update is called once per frame
    void Update()
    {
        //continues to add amount of time by adding the amount of time for last frame passing (continuous) 
        timer += Time.deltaTime;

        if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            Attack();
        }
        if(playerHealth.currentHealth <= 0)
        {
            Debug.Log("Player is dead!");
        }

    }


    void Attack()
    {
        //resets timer that tracks amount of time after an enemy attack
        timer = 0f;

        if(playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }   





}//end of EnemyAttack script
