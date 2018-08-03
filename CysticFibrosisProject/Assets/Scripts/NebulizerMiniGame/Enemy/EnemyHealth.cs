using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 1.5f;
    public int scoreValue = 1;

    private Animator anim;
    private CapsuleCollider capsuleCollider;
    private bool isDead;
    private bool isSinking;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {

        if (isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }

	}


    public void TakeDamage(int amount)
    {
        if (isDead)
            return;

        currentHealth -= amount;

        if(currentHealth <= 0)
        {
            Death();
        }

    }


    void Death()
    {
        isDead = true;
        //when it dies, it will not be an obstacle for other enemies to get around - just a trigger
        capsuleCollider.isTrigger = true;
        anim.SetTrigger("Dead");
    }


    public void StartSinking()
    {
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;
        ScoreManager.score += scoreValue;
        //destroy the game object after 1 second
        Destroy(gameObject, 1f);

    }



}//end of EnemyHealth script

/*Unity tutorial used for enemy scripts: 
 * https://unity3d.com/learn/tutorials/projects/survival-shooter/harming-enemies?playlist=17144
 */
