using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int startHealth = 90;
    public int currentHealth;
    public Slider healthSlider;

    private RaycastShoot raycastShoot;
    private bool isDead;
    private bool damaged;


	// Use this for initialization
	void Awake () {
        raycastShoot = GetComponentInChildren<RaycastShoot>();
        currentHealth = startHealth;
	}
	
	// Update is called once per frame
	void Update () {
        if (damaged)
        {
            //Debug.Log("Player was hit!!");
        }

	}

    //public method - so other scripts and other components call this function - ENEMY CALLS THIS FUNCTION
    public void TakeDamage(int amount)
    {
        damaged = true;
        currentHealth -= amount;
        healthSlider.value = currentHealth;

        //if the health is less than or equal to zero AND the player is not already dead then...
        if(currentHealth <= 0 && !isDead)
        {
            Death();
        }

    }


    void Death()
    {
        isDead = true;
        Debug.Log("Game Over");
        raycastShoot.enabled = false;
        //disable the players ability to move/shoot???? access the script that does this an disable that script
    }




}//end of PlayerHealth script


/*Unity tutorial used for player health:
 * https://unity3d.com/learn/tutorials/projects/survival-shooter/player-health?playlist=17144
 */
