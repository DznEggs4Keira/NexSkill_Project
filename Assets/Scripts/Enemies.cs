using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Enemies : MonoBehaviour
{
    public Vector3 initPos;
    public Transform target;
    public NavMeshAgent Agent;
    public Animator anim;

    readonly private float enemyDamage = 25f;
    
    private bool isTargetInRange = false;
    private float radius = 10f;
    private float maxDist = 5f;


    // Runs at the First Frame
    private void Start()
    {
        initPos = Agent.transform.position;

        //Check for target in range
        StartCoroutine(FindTarget());
    }

    // Update is called once per frame
    void Update()
    {
        MoveAgent();

        if (Agent.velocity != Vector3.zero)
            anim.SetBool("IsMoving", true);
        else
            anim.SetBool("IsMoving", false);
    }

    private void MoveAgent() {

        if(isTargetInRange) {
            Agent.destination = target.position;

            //StopCoroutine(FindTarget());
        }

        //if agent is too far from init position. send them back
        /*if((Agent.transform.position - initPos).sqrMagnitude > maxDist) {
            Agent.destination = initPos;

            //check if enemy has reached initial position
            if(Agent.transform.position == initPos) {
                StartCoroutine(FindTarget());
            }
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit Player");

            anim.SetTrigger("Hit");

            Agent.velocity = Vector3.zero;

            //Health component to handle damage dealt to player
            PlayerHealth H = other.gameObject.GetComponent<PlayerHealth>();

            if (H == null) return;

            H.HealthPoints -= enemyDamage;
        }
    }

    private IEnumerator FindTarget() {

        Debug.Log("Waiting");

        //every five seconds, it will search for the enemy
        yield return new WaitForSeconds(5f);

        Debug.Log("Searching for Target");

        if(Physics.SphereCast(Agent.transform.position, radius, Vector3.forward, out _)) {
            
            Debug.Log("Target in radius");

            isTargetInRange = true;

            Debug.Log("Target found and locked");

        } else {
            Debug.Log("Target not found");

            isTargetInRange = false;
        }

    }
        
}
