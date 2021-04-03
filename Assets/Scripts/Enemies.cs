using UnityEngine;
using UnityEngine.AI;

public class Enemies : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent Agent;

    readonly private float initSpeed = 3f;

    // Runs at the First Frame
    private void Start()
    {
        Agent.velocity *= initSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Agent.destination = target.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0.5f;
            Debug.Log("Hit Player");

            Agent.isStopped = true;

            // @TODO Game Over Screen
        }
    }
}
