using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShoot : MonoBehaviour {


    public int damagePerShot = 100;
    public float fireRate = 0.25f;
    //how far the ray will be cast into the scene 
    public float gunRange = 50.0f;
    //empty GameObject that'll mark the position at the end of the nebulizer where the shot will begin
    public Transform gunEnd;

    private Camera fpsCamera;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.5f);
    //add audiosource at some point
    private LineRenderer shotLine;
    //nextFire holds the time at which the player can fire again
    private float nextFire;

	
	void Start () {

        //get and store reference for components of nebulizer GameObject
        shotLine = GetComponent<LineRenderer>();
        fpsCamera = GetComponentInParent<Camera>();

	}
	
	
	void Update () {
		if(Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            StartCoroutine(ShotEffect());

            //origin positioned at the center of the camera 
            Vector3 rayOrigin = fpsCamera.ViewportToWorldPoint(new Vector3 (0.5f, 0.5f, 0.0f));
            RaycastHit hit;

            //need to establish initial position of the line (need 2 points for the line to be drawn)
            //0 below is "position 0" of line 
            shotLine.SetPosition(0, gunEnd.position);

            //if raycast hits something...
            if (Physics.Raycast(rayOrigin, fpsCamera.transform.forward, out hit, gunRange))
            {
                EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
                //if what we shot is an enemy, then we're going to do damage to its health
                if(enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damagePerShot);
                }

                //whether or not we hit an enemy or just an object, the line will be drawn
                shotLine.SetPosition(1, hit.point);
                Debug.Log("PEW - hit object or enemy");

                /*
                if (hit.transform.gameObject.tag == "Enemy")
                {
                    Destroy(hit.transform.gameObject);
                    //here you will want to instantiate some sort of VFX for destruction of enemy
                }*/

            }
            //otherwise...
            else
            {
                shotLine.SetPosition(1, rayOrigin + (fpsCamera.transform.forward * gunRange));
                Debug.Log("No hit");
            }




        }//end of if (for if user is firing AND are allowed to fire again)
	}



    private IEnumerator ShotEffect()
    {
        shotLine.enabled = true;
        //this tells the coroutine to wait (the length of our WaitForSeconds) 
        yield return shotDuration;
        shotLine.enabled = false;
    }




}
