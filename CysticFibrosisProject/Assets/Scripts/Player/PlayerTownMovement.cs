using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;


public class PlayerTownMovement : MonoBehaviour {

    public Animator animator;
    public NavMeshAgent agent;
    public float inputHoldDelay = 0.5f;
    public float turnSpeedThreshold = 0.5f;
    //amount of time overwhich the speed will change
    public float speedDampTime = 0.1f;
    public float slowingSpeed = 0.175f;
    public float turnSmoothing = 15f;

    private WaitForSeconds inputHoldWait;
    private Vector3 destinationPosition;

    //when within 10% of the stopping distance, then you're stopping
    private const float stopDistanceProportion = 0.1f;
    //distance overwhich this hit can happen
    private const float navMeshSampleDistance = 4f;
    
    private readonly int hashSpeedParam = Animator.StringToHash("Speed");
    

    private void Start()
    {
        agent.updateRotation = false;

        //pause before character interacts with object 
        inputHoldWait = new WaitForSeconds(inputHoldDelay);

        //set destination to current position so they don't move on start
        destinationPosition = transform.position;

    }


    private void OnAnimatorMove()
    {
        //the NavMeshAgent will move the character, but at a rate determined by animator
        // agent.velocity = animator.deltaPosition / Time.deltaTime;


    }


    private void Update()
    {
        //don't want to do anything if the path is currently being calculated
        if(agent.pathPending)
        {
            return;
        }

        float speed = agent.desiredVelocity.magnitude;
        //Debug.Log("remaining distance: " + agent.remainingDistance);
        //want to stop if close to destination

        if (agent.remainingDistance <= agent.stoppingDistance * stopDistanceProportion)
        {
            Stopping(out speed);
        }
        else if(agent.remainingDistance <= agent.stoppingDistance)
        {
            Slowing(out speed, agent.remainingDistance);
        }
        else if (speed > turnSpeedThreshold)
        {
            Moving();
        }

       /* if(agent.remainingDistance > 0)
        {
            
        }*/

        animator.SetFloat(hashSpeedParam, speed, speedDampTime,Time.deltaTime);


    }


    //out because we're affecting the speed within the function
    private void Stopping(out float speed)
    {
        agent.isStopped = true;
        //snap to final place you're aiming for 
        transform.position = destinationPosition;
        speed = 0f;

    }

    private void Slowing(out float speed, float distanceToDestination)
    {
        agent.isStopped = true;
        transform.position = Vector3.MoveTowards(transform.position, destinationPosition, slowingSpeed * Time.deltaTime);
        float proportionalDistance = 1f - distanceToDestination / agent.stoppingDistance;
        speed = Mathf.Lerp(slowingSpeed, 0f, proportionalDistance);

    }
    
    //moving deals with TURNING
    private void Moving()
    {
        Quaternion targetRotation = Quaternion.LookRotation(agent.desiredVelocity);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSmoothing * Time.deltaTime);
    }


    public void OnGroundTouch(BaseEventData data)
    {
        //typecast your BaseEventData to PointerEventData
        PointerEventData pData = (PointerEventData)data;
        NavMeshHit hit;
        if(NavMesh.SamplePosition(pData.pointerCurrentRaycast.worldPosition,out hit, navMeshSampleDistance, NavMesh.AllAreas))
        {
            destinationPosition = hit.position;
            Debug.Log("Destination: " + destinationPosition); 
        }
        else
        {   
            //have player just move towards where was clicked
            destinationPosition = pData.pointerCurrentRaycast.worldPosition;
        }

        agent.SetDestination(destinationPosition);
        agent.isStopped = false;


    }



}
