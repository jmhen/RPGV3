using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : NetworkBehaviour
{
    Transform target;    // Target to follow
    NavMeshAgent agent;  // Reference to our agent
    
    // Start is called before the first frame update
    void Start()
    {
        if (!isLocalPlayer)
        {
            Destroy(this);
            return;
        }
        agent = GetComponent<NavMeshAgent>();
    }

         
    public void MoveToPoint(Vector3 point)
    {
        agent.enabled = true;
        agent.updatePosition = true;
        agent.SetDestination(point);
    }


    public void FollowTarget (Interactable newTarget)
    {
        agent.enabled = true;
        agent.updatePosition = true;
        agent.stoppingDistance = newTarget.radius * .8f;
        agent.updateRotation = false;
        target = newTarget.interactionTransform;
    }

    public void StopFollowingTarget()
    {
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;
        target = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            agent.enabled = true;
            agent.updatePosition = true;
            agent.SetDestination(target.position);
            FaceTarget();
        }
    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

    }

    public void Teleport(Vector3 newLocation)
    {
        Debug.Log("Teleporint to new location: " + newLocation + ".....");
        agent.updatePosition = false;
        agent.enabled = false;
        target = null;
        transform.position = newLocation;



    }

}
