using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public enum States
{
    wanderState, seekState, fleeState, resting, startoverState
}
public class DemoStates : MonoBehaviour {

    Wander wander;
    Seek seek;
    Flee flee;

    public States currentState;
    NavMeshAgent agent;
    float timer;
    public float transitionTimer;
    float restingTimer;
    public float restingTime;
    // Use this for initialization
    void Start()
    {
        restingTimer = restingTime;
        timer = transitionTimer;
        agent = GetComponent<NavMeshAgent>();
        wander = GetComponent<Wander>();
        seek = GetComponent<Seek>();
        flee = GetComponent<Flee>();
    }
    void switchStates()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            currentState++;
            if (currentState == States.startoverState)
            {
                currentState = States.wanderState;
            }

            timer = transitionTimer;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case States.wanderState:
                agent.destination = wander.WanderingPoints();
                break;
            case States.seekState:
                agent.destination = seek.returnTarget();
                break;
            case States.fleeState:
                agent.destination = flee.returnFlee();
                break;
            case States.resting:
                if (currentState == States.wanderState)
                {
                    restingTimer -= Time.deltaTime;
                    if (restingTimer <= 0)
                    {
                        currentState = States.wanderState;
                    }
                }
                break;
        }
        switchStates();

    }
}
