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
  

    // Use this for initialization
    void Start()
    {

        raycastShoot = gun.GetComponent<RaycastShoot>();
       
        //store original rotation
        originRot = fpsCamera.transform.eulerAngles;
        rotX = originRot.x;
        rotY = originRot.y;
    }

    // Update is called once per frame
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
                //clamp rotation so it can't go past certain angles in each direction
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



        /*
        if (Input.touchCount > 0)
        {

            myTouch = Input.GetTouch(0);
            //strTouchPosition = myTouch.position.ToString();
            //touchText.text = "Touch x Position: " + myTouch.position.x
            //touchText.text = "Touch Position: " + myTouch.position.ToString();

            Vector3 touchPosFar = new Vector3(myTouch.position.x,
                                   myTouch.position.y,
                                   Camera.main.farClipPlane);
            Vector3 touchPosNear = new Vector3(myTouch.position.x,
                                               myTouch.position.y,
                                               Camera.main.nearClipPlane);

            Vector3 worldPosFar = Camera.main.ScreenToWorldPoint(touchPosFar);
            Vector3 worldPosNear = Camera.main.ScreenToWorldPoint(touchPosNear);

            Debug.DrawRay(worldPosNear, worldPosFar - worldPosNear, Color.green);

            //rotate camera to look at where you're touching?
            //fpsCamera.transform.LookAt(worldPosFar);
            
            fpsCamera.transform.rotation = Quaternion.LookRotation(worldPosFar);


        }
        */
    }



    public void OnFireButtonPressed()
    {

        Debug.Log("PEW PEW");
       raycastShoot.Shoot();
    }





}
