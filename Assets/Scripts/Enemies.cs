using UnityEngine;
using UnityEngine.AI;

public class Enemies : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent Agent;
    public Animator anim;

    readonly private float AgentSpeed = 5f;

    // Runs at the First Frame
    private void Start()
    {
        Agent.velocity *= AgentSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Agent.destination = target.position;

        if(Agent.velocity != Vector3.zero)
            anim.SetBool("IsMoving", true);
        else
            anim.SetBool("IsMoving", false);
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
}
