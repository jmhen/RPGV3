using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class CharactorAnimator : MonoBehaviour
{
    const float locomotionAnimationSmoothTime = .1f;
    Animator animator;
    NavMeshAgent agent; //a reference to navmeshagent will help us get current speed of character
    // Start is called before the first frame update
    void Start()
    {
        //if (!isLocalPlayer)
        //{
        //    Destroy(this);
        //    return;
        //}
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>(); //on graphic object(child of player object)
    }

    // Update is called once per frame
    void Update()
    {
        float speedPercent = agent.velocity.magnitude / agent.speed; //current speed/max speed   
        animator.SetFloat("speedPercent", speedPercent, locomotionAnimationSmoothTime, Time.deltaTime); //

    }
}
