using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Enemies : MonoBehaviour
{
    public Transform init;
    public Transform target;
    public NavMeshAgent Agent;
    public Animator anim;

    readonly private float AgentSpeed = 5f;
    readonly private float AgentMaxSpeed = 20f;
    private bool isTargetInRange = false;
    private float distance = 100f;


    // Runs at the First Frame
    private void Start()
    {
        init = Agent.transform;

        //Check for target in range
        StartCoroutine(FindTarget());
    }

    // Update is called once per frame
    void Update()
    {
        // if in range
        if(isTargetInRange) {
            StopCoroutine(FindTarget());
            MoveAgent();
        }

        if(Agent.velocity != Vector3.zero)
            anim.SetBool("IsMoving", true);
        else
            anim.SetBool("IsMoving", false);
    }

    private void MoveAgent() {
        Agent.destination = target.position;
        if(Agent.speed > AgentMaxSpeed) {
            Agent.speed = AgentMaxSpeed;
        }
        else {
            Agent.velocity += Vector3.forward * AgentSpeed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit Player");

            anim.SetTrigger("Hit");

            Agent.isStopped = true;

            Level_Handler.enemyHit = true;
        }
    }

    private IEnumerator FindTarget() {

        Debug.Log("Waiting");

        //every five seconds, it will search for the enemy
        yield return new WaitForSeconds(5f);

        Debug.Log("Searching for Target");

        NavMeshHit navMeshHit;

        //if target in within checking distance
        if ((transform.position - target.position).sqrMagnitude <= distance) {

            Debug.Log("Target in distance range");

            Agent.Raycast(target.position, out navMeshHit);

            //if hit is successfull
            if (navMeshHit.hit) {
                isTargetInRange = true;

                Debug.Log("Target found and locked");

                //break out of coroutine
                yield break;
            } else {

                Debug.Log("Target not found");

                isTargetInRange = false;
            }

        } else {

            Debug.Log("Target not in distance range");
        }

    }
        
}
