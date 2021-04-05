using UnityEngine;
using UnityEngine.AI;

public class Enemies : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent Agent;
    public GameObject GameOverScreen;
    public Animator anim;

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

        anim.SetFloat("Movement", Agent.velocity.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            Debug.Log("Hit Player");

            anim.SetBool("Hit", true);

            Agent.isStopped = true;

            // @TODO Game Over Screen
            GameOverScreen.SetActive(true);
        }
    }
}
