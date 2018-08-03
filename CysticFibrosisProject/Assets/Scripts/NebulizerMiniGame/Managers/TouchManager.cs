using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchManager : MonoBehaviour {

    //public Text touchText;
    public Transform gunEnd;
    public Camera fpsCamera;
    public GameObject gun;
    public Button fireButton;

    //private Touch myTouch;

    public float rotSpeed = 0.5f;
    public float dir = -1;


    private Touch initTouch = new Touch();
    private float rotX = 0.0f;
    private float rotY = 0.0f;
    //vector3 will store current rotation
    private Vector3 originRot;

    private RaycastShoot raycastShoot;
  
    void Start()
    {
        //multitouch is false because want to be able to aim then shoot - if true then aiming while shooting will cause glitch
        Input.multiTouchEnabled = false;
        raycastShoot = gun.GetComponent<RaycastShoot>();
       
        //store original rotation
        originRot = fpsCamera.transform.eulerAngles;
        rotX = originRot.x;
        rotY = originRot.y;
    }

    void Update()
    {

        foreach (Touch touch in Input.touches)
        {

            //fireButton.spriteState 
            //if touch is on the fire button??????? then shoot? 
          /* if (fireButton.)
            {

            }*/

            //if touch has just begun
            if(touch.phase == TouchPhase.Began)
            {
                //initialize touch 
                initTouch = touch;
            }
            //if we have moved the current touch
            else if(touch.phase == TouchPhase.Moved){

                //we want difference between initial position and current position
                float deltaX = initTouch.position.x - touch.position.x;
                float deltaY = initTouch.position.y - touch.position.y;

                //subrated current rotations by 
                rotX -= deltaY * Time.deltaTime * rotSpeed * dir;
                rotY += deltaX * Time.deltaTime * rotSpeed * dir;
                //clamp rotation so it can't go past certain angles in each direction (only want them to look forward and to sides)
                rotX = Mathf.Clamp(rotX, -60.0f, 65.0f);
                rotY = Mathf.Clamp(rotY, -75.0f, 75.0f);

                fpsCamera.transform.eulerAngles = new Vector3(rotX, rotY, 0.0f);
            }
            else if(touch.phase == TouchPhase.Ended){

                initTouch = new Touch();
            }

            //if fire1 (if we want to shoot) then CALL the shoot function of the gun????
            //if (Input.GetButton("Fire1"))
            //{
            //    Debug.Log("test");
            //}



        }

    }



    public void OnFireButtonPressed()
    {
       //Debug.Log("PEW");
       raycastShoot.Shoot();
    }





}

/* Tutorial used for swipe touch camera movement:
 * https://www.youtube.com/watch?v=zW1lxrgHgG8&t=1081s
 * https://unity3d.com/learn/tutorials/topics/mobile-touch/multi-touch-input
 * Tutorials on touch input:
 * https://www.youtube.com/watch?v=uUIXFL2ic7k&t=872s
 * https://www.youtube.com/watch?v=SrCUO46jcxk&t=158s
 * FPS camera aim movement:
 * https://www.youtube.com/watch?v=blO039OzUZc&t=1153s
 */
